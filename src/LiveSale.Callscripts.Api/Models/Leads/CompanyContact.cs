namespace LiveSale.Callscripts.Api.Models.Leads
{
	public class CompanyContact
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