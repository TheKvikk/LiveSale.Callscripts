using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Models.Widgets.Visual
{
	public class SimpleText : Widget, IWidgetExtra<SimpleTextExtra>
	{
		public override string Type => "simpletext";

		public SimpleTextExtra Extra { get; } = new();
	}

	public class SimpleTextExtra
	{
		public List<SimpleTextValue> Values { get; } = new();
	}

	public class SimpleTextValue : BaseValue
	{
		public string TextMarkdown { get; set; } = "";
	}
}