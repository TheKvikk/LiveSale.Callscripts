using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LiveSale.Callscripts.Api.Dtos.Leads;
using LiveSale.Callscripts.Api.Queries.Leads;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers.Leads
{
	public class GetLeadHandler : IRequestHandler<GetLeadQuery, LeadDto?>
	{
		private readonly LeadRepository _leadRepository;
		private readonly IMapper _mapper;

		public GetLeadHandler(
			IMapper mapper,
			LeadRepository leadRepository)
		{
			_mapper = mapper;
			_leadRepository = leadRepository;
		}

		// TODO load from DB
		public async Task<LeadDto?> Handle(GetLeadQuery request, CancellationToken cancellationToken)
		{
			var lead = _leadRepository.GetLeadById(request.Id);

			if (lead == null)
			{
				return null;
			}

			return await Task.FromResult(_mapper.Map<LeadDto>(lead));
		}
	}
}