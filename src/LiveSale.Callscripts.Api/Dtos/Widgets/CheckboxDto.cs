using System;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class CheckboxDto : WidgetDto, IWidgetExtra<CheckboxExtraDto>
	{
		public override string Type => "checkbox";

		public CheckboxExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<CheckboxExtraDto>))]
	public class CheckboxExtraDto
	{
		public CheckboxValueDto[] Values { get; set; } = Array.Empty<CheckboxValueDto>();

		public CheckboxValueDto[]? Answers { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<CheckboxValueDto>))]
	public class CheckboxValueDto : BaseValue
	{
		public string Text { get; set; } = "";
		public string Icon { get; set; } = "";
		public bool HasCounter { get; set; }
		public int Counter { get; set; }
		public string? CounterPrefix { get; set; }
		public string? CounterSuffix { get; set; }
	}
}