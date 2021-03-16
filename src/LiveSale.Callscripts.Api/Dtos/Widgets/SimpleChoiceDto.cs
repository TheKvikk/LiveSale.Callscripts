using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class SimpleChoiceDto : WidgetDto, IWidgetExtra<SimpleChoiceExtraDto>
	{
		public override string Type => "simplechoice";

		public SimpleChoiceExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<SimpleChoiceExtraDto>))]
	public class SimpleChoiceExtraDto
	{
		public SimpleChoiceValueDto[] Values { get; set; } = Array.Empty<SimpleChoiceValueDto>();

		[Required]
		public SimpleChoiceValueDto? Answer { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<SimpleChoiceValueDto>))]
	public class SimpleChoiceValueDto : BaseValue
	{
		public int Text { get; set; }
	}
}