namespace LiveSale.Callscripts.Api.Dtos.Requests
{
	public class InsertLeadDto
	{
		public string CampaignId { get; set; } = "";

		public string CallscriptId { get; set; } = "";

		public string FirstName { get; set; } = "";

		public string LastName { get; set; } = "";

		public string Phone { get; set; } = "";

		public string Email { get; set; } = "";
	}
}