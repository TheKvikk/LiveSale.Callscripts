using LiveSale.Callscripts.Api.Dtos.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Queries.Leads
{
	public class GetLeadQuery : IRequest<LeadDto?>
	{
		public GetLeadQuery(string id)
		{
			Id = id;
		}

		public string Id { get; }
	}
}