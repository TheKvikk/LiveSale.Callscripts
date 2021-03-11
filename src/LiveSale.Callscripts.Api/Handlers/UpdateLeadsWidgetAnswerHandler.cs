using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Api.Dtos.Widgets;
using LiveSale.Callscripts.Api.Dtos.Widgets.Visual;
using LiveSale.Callscripts.Api.Problems;
using LiveSale.Callscripts.Core.Converters;
using LiveSale.Callscripts.Core.Models.Widgets;
using LiveSale.Callscripts.Core.Models.Widgets.Visual;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Handlers
{
	public class
		UpdateLeadsWidgetAnswerHandler : IRequestHandler<UpdateLeadsWidgetAnswerCommand, Either<ProblemDetails, bool>>
	{
		private static readonly JsonSerializerOptions _dtoSerializerOptions = new()
			{PropertyNameCaseInsensitive = true};

		private static readonly JsonSerializerOptions _serializerOptions = new()
			{PropertyNameCaseInsensitive = true, Converters = {new WidgetConverter()}};

		private static readonly IReadOnlyDictionary<string, Type> _widgetDtoExtras = new ReadOnlyDictionary<string, Type>(
			new Dictionary<string, Type>
			{
				{"simpletext", typeof(SimpleTextExtraDto)},
				{"imagetext", typeof(ImageWithTextExtraDto)},
				{"image", typeof(ImageExtraDto)},
				{"range", typeof(RangeExtraDto)}
			});

		private static readonly IReadOnlyDictionary<string, Type> _widgetExtras = new ReadOnlyDictionary<string, Type>(
			new Dictionary<string, Type>
			{
				{"simpletext", typeof(SimpleTextExtra)},
				{"imagetext", typeof(ImageWithTextExtra)},
				{"image", typeof(ImageExtra)},
				{"range", typeof(RangeExtra)}
			});

		private readonly LeadRepository _leadRepository;

		private readonly IMapper _mapper;

		public UpdateLeadsWidgetAnswerHandler(IMapper mapper, LeadRepository leadRepository)
		{
			_mapper = mapper;
			_leadRepository = leadRepository;
		}

		public async Task<Either<ProblemDetails, bool>> Handle(UpdateLeadsWidgetAnswerCommand request,
			CancellationToken cancellationToken)
		{
			// lead existence is validated even before this handler is called, no need to test again
			var lead = (await _leadRepository.GetLeadByIdAsync(request.LeadId)).ValueUnsafe();

			var widget = lead.Pages.SelectMany(page => page.Widgets)
				.SingleOrDefault(w => w.Id == request.WidgetId);

			if (widget == default)
			{
				return new InvalidWidgetIdProblemDetails(request.WidgetId);
			}

			if (!_widgetDtoExtras.TryGetValue(widget.Type, out var dtoExtraType) ||
			    !_widgetExtras.TryGetValue(widget.Type, out var extraType))
			{
				return new UnsupportedWidgetTypeProblemDetails(widget.Type);
			}

			var targetsTypeAnswerProperty = extraType.GetProperties()
				.SingleOrDefault(property => property.Name.Contains("Answer")); // this also checks for "Answers"

			// lead's widget doesn't have answer/s
			if (targetsTypeAnswerProperty == default)
			{
				return new MissingAnswerPropertyProblemDetails(widget.Type);
			}

			var extra = new object();

			try
			{
				extra = JsonSerializer.Deserialize(request.Extra, dtoExtraType, _dtoSerializerOptions);
			}
			catch
			{
				// TODO this is never thrown even when sending "{ "aaa": 12 }" into range type
				return new InvalidIncomingExtraTypeProblemDetails(dtoExtraType.Name);
			}

			// incoming extra doesn't have answer/s
			var extrasAnswerProperty = extra.GetType()
				.GetProperties()
				.SingleOrDefault(property => property.Name.Contains("Answer")); // this also checks for "Answers"

			// get value of Answer/s from incoming extra property
			var extrasAnswerValue = extrasAnswerProperty.GetValue(extra);

			if (extrasAnswerProperty == default || extrasAnswerValue == null)
			{
				return new MissingIncomingAnswerPropertyProblemDetails();
			}

			// get value of Extra from lead's widget 
			var widgetExtraValue = widget.GetType().GetProperty("Extra").GetValue(widget);
			// get property of Answer/s from lead's widget extra
			var widgetsExtraTypeOfAnswer = widgetExtraValue.GetType()
				.GetProperty(targetsTypeAnswerProperty.Name);

			var widgetsExtraTypeOfAnswerValue = widgetsExtraTypeOfAnswer.GetValue(widgetExtraValue);
			var finalValueToSet = _mapper.Map(
				extrasAnswerValue,
				extrasAnswerValue.GetType(),
				widgetsExtraTypeOfAnswerValue.GetType()
			);

			widgetsExtraTypeOfAnswer.SetValue(widgetExtraValue, finalValueToSet);

			_leadRepository.Update(lead);

			return true;
		}
	}
}