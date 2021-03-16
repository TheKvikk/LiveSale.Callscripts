namespace LiveSale.Callscripts.Api.Dtos.Requests
{
	public class UpdateLeadsWidgetAnswerDto
	{
		public string LeadId { get; init; } = "";

		public string WidgetId { get; init; } = "";

		public string WidgetType { get; set; } = "";

		public string Extra { get; init; } = "";
	}
}