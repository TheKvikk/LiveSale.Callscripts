namespace LiveSale.Callscripts.Api.Dtos.Requests
{
	public class UpdateLeadsStateDto
	{
		public string LeadId { get; set; } = "";

		public int ActiveWidgetIndex { get; set; }

		public bool Started { get; set; }

		public bool Completed { get; set; }
	}
}