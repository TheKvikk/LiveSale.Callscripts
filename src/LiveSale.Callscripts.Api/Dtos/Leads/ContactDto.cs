namespace LiveSale.Callscripts.Api.Dtos.Leads
{
	public class ContactDto
	{
		public string Id { get; init; } = null!;

		public bool IsCompanyContact { get; set; }

		public CompanyDto Company { get; set; } = new();

		public CompanyContactDto CompanyContact { get; set; } = new();
	}
}