namespace LiveSale.Callscripts.Core.Models.Leads
{
	public class ContactValue
	{
		public bool Show { get; set; } = true;

		public bool Required { get; set; } = true;

		public bool Valid { get; set; }

		public string Value { get; set; } = "";
	}
}