using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Widgets.Visual
{
	public class ImageWithText : Widget, IWidgetExtra<ImageWithTextExtra>
	{
		public override string Type => "imagetext";

		public ImageWithTextExtra Extra { get; set; } = new();
	}

	public class ImageWithTextExtra
	{
		public List<ImageWithTextValue> Values { get; set; } = new();
	}

	public class ImageWithTextValue : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
		public string ImageUrl { get; set; } = "";
		public string Position { get; set; } = ""; // left | right
	}
}