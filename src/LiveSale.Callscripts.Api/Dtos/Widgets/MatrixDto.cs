using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class MatrixDto : WidgetDto, IWidgetExtra<MatrixExtraDto>
	{
		public override string Type => "ratingmatrix";

		public MatrixExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<MatrixExtraDto>))]
	public class MatrixExtraDto
	{
		public int MaxRating { get; set; } = 1;
		
		public MatrixRatingValue[] Ratings { get; set;} = Array.Empty<MatrixRatingValue>();
		
		public MatrixValueDto[] Values { get; set; } = Array.Empty<MatrixValueDto>();

		[Required]
		public MatrixValueDto[]? Answers { get; set; }
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<TextBoxValueDto>))]
	public class MatrixValueDto : BaseValue
	{
		public bool Required { get; set; }
		
		public string Text { get; set; }

		[Required]
		public int Value { get; set; }
	}

	public class MatrixRatingValue : BaseValue
	{
		public string Value { get; set; }
		public string Text { get; set; }
	}
}