using FluentValidation;
using FluentValidation.Results;
using LiveSale.Callscripts.Api.Dtos.Requests;

namespace LiveSale.Callscripts.Api.Validation
{
	public class UpdateLeadsWidgetAnswerDtoValidator : AbstractValidator<UpdateLeadsWidgetAnswerDto>
	{
		public UpdateLeadsWidgetAnswerDtoValidator()
		{
			InitRules();
		}

		private void InitRules()
		{
			RuleFor(p => p.LeadId)
				.NotEmpty();

			RuleFor(p => p.WidgetId)
				.NotEmpty();

			RuleFor(p => p.Extra)
				.NotEmpty()
				.Custom((value, context) =>
				{
					if (value == "{}")
					{
						context.AddFailure(new ValidationFailure($"{nameof(UpdateLeadsWidgetAnswerDto.Extra)}",
							"'Extra' must not be empty JavaScript object."));
					}
				});
		}
	}
}