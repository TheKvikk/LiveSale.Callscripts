namespace LiveSale.Callscripts.Api.Dtos.Leads
{
	public class ContactValueDto
	{
		public bool Show { get; set; }

		public bool Required { get; set; }

		public bool Valid { get; set; }

		public string Value { get; set; } = "";
	}
}