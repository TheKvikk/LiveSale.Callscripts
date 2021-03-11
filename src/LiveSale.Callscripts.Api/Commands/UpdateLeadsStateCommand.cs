using MediatR;

namespace LiveSale.Callscripts.Api.Commands
{
	public class UpdateLeadsStateCommand : IRequest
	{
		public string LeadId { get; init; } = "";

		public int ActiveWidgetIndex { get; init; }

		public bool Started { get; init; }

		public bool Completed { get; init; }
	}
}