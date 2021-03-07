namespace LiveSale.Callscripts.Api.Dtos.Leads
{
	public class CompanyContactDto
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";

		public string FullName => $"{FirstName} {LastName}";

		public string Position { get; set; } = "";

		public string Phone { get; set; } = "";

		public string MobilePhone { get; set; } = "";

		public string Email { get; set; } = "";
	}
}