using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class AutocompleteDto : WidgetDto, IWidgetExtra<AutocompleteExtraDto>
	{
		public override string Type => "autocomplete";

		public AutocompleteExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<AutocompleteExtraDto>))]
	public class AutocompleteExtraDto
	{
		public string Placeholder { get; set; }
		
		public AutocompleteValueDto[] Values { get; set; } = Array.Empty<AutocompleteValueDto>();

		[Required]
		public AutocompleteValueDto? Answer { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<AutocompleteValueDto>))]
	public class AutocompleteValueDto : BaseValue
	{
		public string Value { get; set; } = "";
	}
}