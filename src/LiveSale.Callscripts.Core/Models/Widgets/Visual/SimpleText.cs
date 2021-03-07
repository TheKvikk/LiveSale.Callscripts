using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Widgets.Visual
{
	public class SimpleText : Widget, IWidgetExtra<SimpleTextExtra>
	{
		public override string Type => "simpletext";

		public SimpleTextExtra Extra { get; set; } = new();
	}

	public class SimpleTextExtra
	{
		public List<SimpleTextValue> Values { get; set; } = new();
	}

	public class SimpleTextValue : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
	}
}