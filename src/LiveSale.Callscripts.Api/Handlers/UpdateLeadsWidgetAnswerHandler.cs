using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Api.Dtos.Widgets;
using LiveSale.Callscripts.Api.Problems;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Handlers
{
	public class
		UpdateLeadsWidgetAnswerHandler : IRequestHandler<UpdateLeadsWidgetAnswerCommand, Either<ProblemDetails, bool>>
	{
		private const string AnswerPropertyName = "Answer";
		private const string ValuePropertyName = "Value";
		private const string ExtraPropertyName = "Extra";
		private static readonly IReadOnlyDictionary<string, Type> _widgetDtoExtras = new Dictionary<string, Type>
			{
				{ "range", typeof(RangeExtraDto) },
				{ "slider", typeof(SliderExtraDto) },
				{ "text", typeof(TextBoxExtraDto) },
				{ "checkbox", typeof(CheckboxExtraDto) },
				{ "radio", typeof(RadioExtraDto) },
				{ "autocomplete", typeof(AutocompleteExtraDto) },
				{ "ratingmatrix", typeof(MatrixExtraDto) },
				{ "simplechoice", typeof(SimpleChoiceExtraDto) },
				{ "contacts", typeof(ContactsExtraDto) },
				{ "agreements", typeof(AgreementsExtraDto) }
			};

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

			var dtoExtraType = _widgetDtoExtras[widget.Type];
			var leadsWidgetExtra = widget.GetType()
				.GetProperty(ExtraPropertyName)!
				.GetValue(widget)!;

			var leadsWidgetAnswerType = leadsWidgetExtra.GetType()
				.GetProperty(AnswerPropertyName)!;

			var extraDto = JsonSerializer.Deserialize(request.Extra, dtoExtraType)!;
			var extrasAnswerProperty = GetAnswerProperty(extraDto.GetType());
			var extrasAnswerValue = extrasAnswerProperty.GetValue(extraDto)!;
			var leadsWidgetAnswerValue = leadsWidgetAnswerType.GetValue(leadsWidgetExtra)!;

			// TODO check if answer Id is among values Ids (values is an array most of the time, answer is only sometimes an array)
			_mapper.Map(
				extrasAnswerValue,
				leadsWidgetAnswerValue,
				extrasAnswerValue.GetType(),
				leadsWidgetAnswerValue.GetType()
			);

			_leadRepository.Update(lead);

			return true;
		}

		private static PropertyInfo GetAnswerProperty(Type type)
		{
			return type.GetProperties()
				.Single(property => property.Name.Contains(AnswerPropertyName))!;
		}

		private void WidgetValueIds(object widgetExtra, Type typeOfExtra)
		{
			typeOfExtra.GetProperties()
				.Single(property => property.Name.Contains(ValuePropertyName));
		}
	}
}