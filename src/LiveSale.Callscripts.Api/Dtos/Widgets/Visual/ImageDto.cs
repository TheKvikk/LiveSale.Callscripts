using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Dtos.Widgets.Visual
{
	public class ImageDto : WidgetDto, IWidgetExtra<ImageExtraDto>
	{
		public override string Type => "image";

		public ImageExtraDto Extra { get; set; } = new();
	}

	public class ImageExtraDto
	{
		public List<ImageValueDto> Values { get; set; } = new();
	}

	public class ImageValueDto : BaseValue
	{
		public string ImageUrl { get; set; } = "";
	}
}