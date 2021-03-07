namespace LiveSale.Callscripts.Api.Dtos.Callscripts
{
	public class SupportPagesSettingDto
	{
		public SupportPageSettingDto Intro { get; } = new();
		public SupportPageSettingDto Outro { get; } = new();
	}
}