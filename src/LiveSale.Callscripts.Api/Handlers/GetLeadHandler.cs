using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LanguageExt;
using LiveSale.Callscripts.Api.Dtos.Leads;
using LiveSale.Callscripts.Api.Queries.Leads;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers
{
	public class GetLeadHandler : IRequestHandler<GetLeadQuery, Option<LeadDto>>
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

		public async Task<Option<LeadDto>> Handle(GetLeadQuery request, CancellationToken cancellationToken)
		{
			return await _leadRepository.GetLeadByIdAsync(request.Id)
				.Match(lead => _mapper.Map<LeadDto>(lead), () => null!);
		}
	}
}