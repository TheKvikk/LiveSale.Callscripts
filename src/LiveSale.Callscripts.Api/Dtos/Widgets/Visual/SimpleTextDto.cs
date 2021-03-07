using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Dtos.Widgets.Visual
{
	public class SimpleTextDto : WidgetDto, IWidgetExtra<SimpleTextExtraDto>
	{
		public override string Type => "simpletext";

		public SimpleTextExtraDto Extra { get; set; } = new();
	}

	public class SimpleTextExtraDto
	{
		public List<SimpleTextValueDto> Values { get; set; } = new();
	}

	public class SimpleTextValueDto : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
	}
}