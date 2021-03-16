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

			RuleFor(p => p.WidgetId)
				.NotEmpty();

			RuleFor(p => p.ActiveWidgetIndex)
				.NotEqual(0);

			RuleFor(p => new {p.Started, p.Completed})
				.Must(p => !p.Started && p.Completed)
				.WithMessage("Lead can not be completed without starting.")
				.Must(p => !p.Started && !p.Completed)
				.WithMessage("Lead has to start or compete.");
		}
	}
}