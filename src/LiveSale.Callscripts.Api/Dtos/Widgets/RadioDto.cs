using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class RadioDto : WidgetDto, IWidgetExtra<RadioExtraDto>
	{
		public override string Type => "radio";

		public RadioExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<RadioExtraDto>))]
	public class RadioExtraDto
	{
		public RadioValueDto[] Values { get; set; } = Array.Empty<RadioValueDto>();

		[Required]
		public RadioValueDto? Answer { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<CheckboxValueDto>))]
	public class RadioValueDto : BaseValue
	{
		public string Text { get; set; } = "";
		public string Icon { get; set; } = "";
	}
}