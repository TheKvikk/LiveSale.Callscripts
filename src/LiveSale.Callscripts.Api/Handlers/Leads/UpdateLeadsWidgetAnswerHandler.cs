using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LiveSale.Callscripts.Api.Commands.Leads;
using LiveSale.Callscripts.Api.Converters;
using LiveSale.Callscripts.Api.Dtos.Leads;
using LiveSale.Callscripts.Api.Dtos.Widgets.Visual;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers.Leads
{
	public class UpdateLeadsWidgetAnswerHandler : IRequestHandler<UpdateLeadsWidgetAnswerCommand>
	{
		private readonly JsonSerializerOptions _serializerOptions = new()
			{Converters = {new WidgetConverter()}};
		private readonly Dictionary<string, Type> _widgetExtras = new()
		{
			{"simpletext", typeof(SimpleTextExtraDto)},
			{"imagetext", typeof(ImageWithTextExtraDto)},
			{"image", typeof(ImageExtraDto)}
		};

		// TODO make some null ref validations
		public async Task<Unit> Handle(UpdateLeadsWidgetAnswerCommand request, CancellationToken cancellationToken)
		{
			var lead = new LeadDto(); // TODO load from DB
			var widget = lead.Pages
				.SingleOrDefault(page => page.Id == request.PageId)
				.Widgets
				.SingleOrDefault(widget => widget.Id == request.WidgetId);

			_widgetExtras.TryGetValue(widget.Type, out var type);

			var extra = JsonSerializer.Deserialize(request.Extra, type, _serializerOptions);
			widget.GetType().GetProperty("Extra")?.SetValue(widget, extra);
			
			// TODO save lead

			return await Task.FromResult(new Unit());
		}
	}
}