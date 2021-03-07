namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class WidgetDto : BaseValue
	{
		public virtual string Type { get; set; } = "";

		public string Subtype { get; set; } = "";

		public bool Required { get; set; } = true;

		public bool Valid { get; set; }

		public string HeaderText { get; set; } = "";

		public string NoteText { get; set; } = "";
	}
}