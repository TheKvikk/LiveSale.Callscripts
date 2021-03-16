using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class TextBoxDto : WidgetDto, IWidgetExtra<TextBoxExtraDto>
	{
		public override string Type => "text";

		public TextBoxExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<TextBoxExtraDto>))]
	public class TextBoxExtraDto
	{
		public TextBoxValueDto[] Values { get; set; } = Array.Empty<TextBoxValueDto>();

		[Required]
		public TextBoxValueDto? Answer { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<TextBoxValueDto>))]
	public class TextBoxValueDto : BaseValue
	{
		public string Placeholder { get; set; } = "";

		[Required]
		public int Value { get; set; }
	}
}