using MediatR;

namespace LiveSale.Callscripts.Api.Commands.Leads
{
	public class UpdateLeadsWidgetAnswerCommand : IRequest
	{
		public string LeadId { get; set; } = "";

		public string PageId { get; } = "";

		public string WidgetId { get; } = "";

		public string Extra { get; } = "";
	}
}