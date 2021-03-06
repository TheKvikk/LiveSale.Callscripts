using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Models.Widgets.Visual
{
	public class Image : Widget, IWidgetExtra<ImageExtra>
	{
		public override string Type => "image";

		public ImageExtra Extra { get; } = new();
	}
	
	public class ImageExtra
	{
		public List<ImageValue> Values { get; } = new();
	}

	public class ImageValue : BaseValue
	{
		public string ImageUrl { get; set; } = "";
	}
}