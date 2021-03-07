using System;
using System.Threading;
using System.Threading.Tasks;
using LiveSale.Callscripts.Api.Dtos.Leads;
using LiveSale.Callscripts.Api.Queries.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers.Leads
{
	public class GetLeadHandler : IRequestHandler<GetLeadQuery, LeadDto?>
	{
		// TODO load from DB
		public async Task<LeadDto?> Handle(GetLeadQuery request, CancellationToken cancellationToken)
		{
			if (new Random().Next(0, 10) > 5)
			{
				return null;
			}

			return await Task.FromResult(new LeadDto());
		}
	}
}