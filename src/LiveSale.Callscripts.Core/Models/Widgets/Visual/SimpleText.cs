using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Widgets.Visual
{
	public class SimpleTextDto : Widget, IWidgetExtra<SimpleTextExtraDto>
	{
		public override string Type => "simpletext";

		public SimpleTextExtraDto Extra { get; } = new();
	}

	public class SimpleTextExtraDto
	{
		public List<SimpleTextValueDto> Values { get; } = new();
	}

	public class SimpleTextValueDto : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
	}
}