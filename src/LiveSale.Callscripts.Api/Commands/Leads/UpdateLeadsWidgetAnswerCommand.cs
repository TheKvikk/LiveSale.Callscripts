using MediatR;

namespace LiveSale.Callscripts.Api.Commands.Leads
{
	public class UpdateLeadsWidgetAnswerCommand : IRequest
	{
		public string LeadId { get; init; } = "";

		public string PageId { get; init; } = "";

		public string WidgetId { get; init; } = "";

		public string Extra { get; init; } = "";
	}
}