using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Api.Dtos.Leads;
using LiveSale.Callscripts.Core.Models.Leads;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers
{
	public class InsertLeadHandler : IRequestHandler<InsertLeadCommand, LeadDto>
	{
		private readonly LeadRepository _leadRepository;
		private readonly IMapper _mapper;

		public InsertLeadHandler(IMapper mapper, LeadRepository leadRepository)
		{
			_mapper = mapper;
			_leadRepository = leadRepository;
		}

		public async Task<LeadDto> Handle(InsertLeadCommand request, CancellationToken cancellationToken)
		{
			var lead = new Lead(new()); // GET callscript from DB by request.CampaignId/CallscriptId
			var insertedLead = await _leadRepository.InsertLeadAsync(lead);

			return _mapper.Map<LeadDto>(insertedLead);
		}
	}
}