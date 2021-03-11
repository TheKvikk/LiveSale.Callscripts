using System.Threading;
using System.Threading.Tasks;
using LanguageExt.UnsafeValueAccess;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Core.Models.Leads;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;

namespace LiveSale.Callscripts.Api.Handlers
{
	public class UpdateLeadsStateHandler : IRequestHandler<UpdateLeadsStateCommand, Unit>
	{
		private readonly LeadRepository _leadRepository;

		public UpdateLeadsStateHandler(LeadRepository leadRepository)
		{
			_leadRepository = leadRepository;
		}

		public async Task<Unit> Handle(UpdateLeadsStateCommand request, CancellationToken cancellationToken)
		{
			var lead = (await _leadRepository.GetLeadByIdAsync(request.LeadId)).ValueUnsafe();
			lead.ActiveWidgetIndex = request.ActiveWidgetIndex;

			if (request.Started)
			{
				lead.State = State.Started;
			}

			if (request.Completed)
			{
				lead.State = State.Completed;
			}

			_leadRepository.Update(lead);

			return await Task.FromResult(new Unit());
		}
	}
}