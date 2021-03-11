using FluentValidation;
using LiveSale.Callscripts.Api.Dtos.Requests;

namespace LiveSale.Callscripts.Api.Validation
{
	public class UpdateLeadsStateDtoValidator : AbstractValidator<UpdateLeadsStateDto>
	{
		public UpdateLeadsStateDtoValidator()
		{
			InitRules();
		}

		private void InitRules()
		{
			RuleFor(p => p.LeadId)
				.NotEmpty();
		}
	}
}