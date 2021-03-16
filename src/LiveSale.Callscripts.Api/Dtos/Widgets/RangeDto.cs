using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;
using LiveSale.Callscripts.Api.Validation.Attributes;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class RangeDto : WidgetDto, IWidgetExtra<RangeExtraDto>
	{
		public override string Type => "range";

		public RangeExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<RangeExtraDto>))]
	public class RangeExtraDto
	{
		public RangeValueDto Value { get; set; } = new();

		[Required]
		public RangeValueDto? Answer { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<RangeValueDto>))]
	public class RangeValueDto : BaseValue
	{
		[ExactLength(2)]
		public string[] Parts { get; set; } = Array.Empty<string>();

		[Required, ExactLength(2), MustSumTo(100)]
		public int[] Values { get; set; } = {50, 50};
	}
}