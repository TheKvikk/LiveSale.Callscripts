using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Widgets.Visual
{
	public class ImageDto : Widget, IWidgetExtra<ImageExtraDto>
	{
		public override string Type => "image";

		public ImageExtraDto Extra { get; } = new();
	}

	public class ImageExtraDto
	{
		public List<ImageValueDto> Values { get; } = new();
	}

	public class ImageValueDto : BaseValue
	{
		public string ImageUrl { get; set; } = "";
	}
}