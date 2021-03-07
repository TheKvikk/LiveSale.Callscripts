namespace LiveSale.Callscripts.Core.Models.Widgets
{
	public class Range : Widget, IWidgetExtra<RangeExtra>
	{
		public override string Type => "range";

		public RangeExtra Extra { get; set; } = new();
	}

	public class RangeExtra
	{
		public RangeValue Value { get; set; } = new();

		public RangeValue? Answer { get; set; }
	}

	public class RangeValue : BaseValue
	{
		public string[] Parts { get; set; }

		public int[] Values { get; set; } = {50, 50};
	}
}