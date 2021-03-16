using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Api.Problems;
using LiveSale.Callscripts.Core.Models.Leads;
using LiveSale.Callscripts.Core.Repositories.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Unit = MediatR.Unit;

namespace LiveSale.Callscripts.Api.Handlers
{
	public class UpdateLeadsStateHandler : IRequestHandler<UpdateLeadsStateCommand, Either<ProblemDetails, Unit>>
	{
		private readonly LeadRepository _leadRepository;

		public UpdateLeadsStateHandler(LeadRepository leadRepository)
		{
			_leadRepository = leadRepository;
		}

		public async Task<Either<ProblemDetails, Unit>> Handle(UpdateLeadsStateCommand request, CancellationToken cancellationToken)
		{
			var lead = (await _leadRepository.GetLeadByIdAsync(request.LeadId)).ValueUnsafe();

			if (lead.ActiveWidgetIndex >= request.ActiveWidgetIndex || request.ActiveWidgetIndex - 1 != lead.ActiveWidgetIndex)
			{
				return new InvalidNewActiveWidgetIndexProblemDetails(request.ActiveWidgetIndex);
			}

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