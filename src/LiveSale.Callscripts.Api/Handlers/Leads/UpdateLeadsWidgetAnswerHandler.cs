using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LiveSale.Callscripts.Api.Commands.Leads;
using LiveSale.Callscripts.Api.Converters;
using LiveSale.Callscripts.Core.Models.Widgets;
using LiveSale.Callscripts.Core.Models.Widgets.Visual;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers.Leads
{
	public class UpdateLeadsWidgetAnswerHandler : IRequestHandler<UpdateLeadsWidgetAnswerCommand>
	{
		private static readonly JsonSerializerOptions _serializerOptions = new()
			{PropertyNameCaseInsensitive = true, Converters = {new WidgetDtoConverter()}};

		private static readonly Dictionary<string, Type> _widgetExtras = new()
		{
			{"simpletext", typeof(SimpleTextExtra)},
			{"imagetext", typeof(ImageWithTextExtra)},
			{"image", typeof(ImageExtra)},
			{"range", typeof(RangeExtra)}
		};

		private readonly LeadRepository _leadRepository;

		public UpdateLeadsWidgetAnswerHandler(LeadRepository leadRepository)
		{
			_leadRepository = leadRepository;
		}

		// TODO make some null ref validations
		public async Task<Unit> Handle(UpdateLeadsWidgetAnswerCommand request, CancellationToken cancellationToken)
		{
			var lead = _leadRepository.GetLeadById(request.LeadId);
			var widget = lead.Pages
				.SingleOrDefault(page => page.Id == request.PageId)
				.Widgets
				.SingleOrDefault(widget => widget.Id == request.WidgetId);

			_widgetExtras.TryGetValue(widget.Type, out var type);

			var extra = JsonSerializer.Deserialize(request.Extra, type, _serializerOptions);
			widget.GetType().GetProperty("Extra")?.SetValue(widget, extra);

			_leadRepository.Update(lead);

			return await Task.FromResult(new Unit());
		}
	}
}