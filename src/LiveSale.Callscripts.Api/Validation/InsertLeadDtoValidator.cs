using FluentValidation;
using LiveSale.Callscripts.Api.Dtos.Requests;

namespace LiveSale.Callscripts.Api.Validation
{
	public class InsertLeadDtoValidator : AbstractValidator<InsertLeadDto>
	{
		public InsertLeadDtoValidator()
		{
			InitRules();
		}

		private void InitRules()
		{
			RuleFor(p => p.CampaignId)
				.NotEmpty();

			RuleFor(p => p.CallscriptId)
				.NotEmpty();

			RuleFor(p => p.Phone)
				.NotEmpty();
		}
	}
}