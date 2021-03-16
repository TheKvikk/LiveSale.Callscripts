using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class SliderDto : WidgetDto, IWidgetExtra<SliderExtraDto>
	{
		public override string Type => "slider";

		public SliderExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<SliderExtraDto>))]
	public class SliderExtraDto
	{
		public int Step { get; set; } = 1;
		
		public SliderValueDto[] Values { get; set; } = Array.Empty<SliderValueDto>();

		[Required]
		public SliderValueDto? Answer { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<SliderValueDto>))]
	public class SliderValueDto : BaseValue
	{
		public string Text { get; set; } = "";

		[Required]
		public int Value { get; set; }
	}
}