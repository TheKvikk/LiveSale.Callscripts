using LiveSale.Callscripts.Api.Dtos.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Commands
{
	public class InsertLeadCommand : IRequest<LeadDto>
	{
		public string CampaignId { get; init; } = "";

		public string CallscriptId { get; init; } = "";

		public string FirstName { get; init; } = "";

		public string LastName { get; init; } = "";

		public string Phone { get; init; } = "";

		public string Email { get; init; } = "";
	}
}