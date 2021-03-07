using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Widgets.Visual
{
	public class ImageWithTextDto : Widget, IWidgetExtra<ImageWithTextExtraDto>
	{
		public override string Type => "imagetext";

		public ImageWithTextExtraDto Extra { get; } = new();
	}

	public class ImageWithTextExtraDto
	{
		public List<ImageWithTextValueDto> Values { get; } = new();
	}

	public class ImageWithTextValueDto : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
		public string ImageUrl { get; set; } = "";
		public string Position { get; set; } = ""; // left | right
	}
}