using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Models.Widgets.Visual
{
	public class ImageWithText : Widget, IWidgetExtra<ImageWithTextExtra>
	{
		public override string Type => "imagetext";

		public ImageWithTextExtra Extra { get; } = new();
	}

	public class ImageWithTextExtra
	{
		public List<ImageWithTextValue> Values { get; } = new();
	}

	public class ImageWithTextValue : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
		public string ImageUrl { get; set; } = "";
		public string Position { get; set; } = ""; // left | right
	}
}