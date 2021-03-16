using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class ImageWithTextDto : WidgetDto, IWidgetExtra<ImageWithTextExtraDto>
	{
		public override string Type => "imagetext";

		public ImageWithTextExtraDto Extra { get; set; } = new();
	}

	public class ImageWithTextExtraDto
	{
		public List<ImageWithTextValueDto> Values { get; set; } = new();
	}

	public class ImageWithTextValueDto : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
		public string ImageUrl { get; set; } = "";
		public string Position { get; set; } = ""; // left | right
	}
}