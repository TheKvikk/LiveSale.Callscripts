namespace LiveSale.Callscripts.Api.Dtos.Callscripts
{
	public class SupportPagesSettingDto
	{
		public SupportPageSettingDto Intro { get; set; } = new();

		public SupportPageSettingDto Outro { get; set; } = new();
	}
}