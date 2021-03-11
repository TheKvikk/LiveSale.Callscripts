using System;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class RangeDto : WidgetDto, IWidgetExtra<RangeExtraDto>
	{
		public override string Type => "range";

		public RangeExtraDto Extra { get; set; } = new();
	}

	public class RangeExtraDto
	{
		public RangeValueDto Value { get; set; } = new();

		public RangeValueDto? Answer { get; set; }
	}

	public class RangeValueDto : BaseValue
	{
		public string[] Parts { get; set; } = Array.Empty<string>();

		public int[] Values { get; set; } = {50, 50};
	}
}