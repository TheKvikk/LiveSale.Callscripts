using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Widgets.Visual
{
	public class Image : Widget, IWidgetExtra<ImageExtra>
	{
		public override string Type => "image";

		public ImageExtra Extra { get; set; } = new();
	}

	public class ImageExtra
	{
		public List<ImageValue> Values { get; set; } = new();
	}

	public class ImageValue : BaseValue
	{
		public string ImageUrl { get; set; } = "";
	}
}