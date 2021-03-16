using System;
using System.Collections.Generic;
using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using LiveSale.Callscripts.Api.Dtos.Requests;
using LiveSale.Callscripts.Api.Dtos.Widgets;

namespace LiveSale.Callscripts.Api.Validation
{
	public class UpdateLeadsWidgetAnswerDtoValidator : AbstractValidator<UpdateLeadsWidgetAnswerDto>
	{
		private static readonly IReadOnlyDictionary<string, Type> _widgetExtraTypes = new Dictionary<string, Type>
		{
			{ "range", typeof(RangeExtraDto) },
			{ "slider", typeof(SliderExtraDto) },
			{ "text", typeof(TextBoxExtraDto) },
			{ "checkbox", typeof(CheckboxExtraDto) },
			{ "radio", typeof(RadioExtraDto) },
			{ "autocomplete", typeof(AutocompleteExtraDto) },
			{ "ratingmatrix", typeof(MatrixExtraDto) },
			{ "simplechoice", typeof(SimpleChoiceExtraDto) },
			{ "contacts", typeof(ContactsExtraDto) },
			{ "agreements", typeof(AgreementsExtraDto) }
		};
		
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

			RuleFor(p => p.WidgetType)
				.NotEmpty();

			RuleFor(p => new {p.WidgetType, p.Extra})
				.Custom((p, context) => ExtraIsDeserializableToType(context, p.WidgetType, p.Extra));
		}

		private void ExtraIsDeserializableToType(CustomContext context, string widgetType, string extra)
		{
			if (!_widgetExtraTypes.TryGetValue(widgetType, out var type))
			{
				context.AddFailure(new ValidationFailure($"{nameof(UpdateLeadsWidgetAnswerDto.WidgetType)}",
					$"'WidgetType' with value '{widgetType}' is not supported."));
			}

			try
			{
				JsonSerializer.Deserialize(extra, type!);
			}
			catch (JsonException e)
			{
				context.AddFailure(new ValidationFailure($"{nameof(UpdateLeadsWidgetAnswerDto.Extra)}",
					e.Message));
			}
		}
	}
}