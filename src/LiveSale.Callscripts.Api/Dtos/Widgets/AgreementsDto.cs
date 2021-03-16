using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class AgreementsDto : WidgetDto, IWidgetExtra<AgreementsExtraDto>
	{
		public override string Type => "agreements";

		public AgreementsExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<AgreementsExtraDto>))]
	public class AgreementsExtraDto
	{
		public AgreementsValueDto[] Values { get; set; } = Array.Empty<AgreementsValueDto>();

		[Required]
		public AgreementsValueDto[]? Answers { get; set; }
	}

	public class AgreementsValueDto : BaseValue
	{
		public bool Required { get; set; }
		
		public bool Valid { get; set; }

		public string Text { get; set; } = null!;
		
		public string? Url { get; set; }
	}
}