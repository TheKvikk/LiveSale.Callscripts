using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Dtos.Callscripts
{
	public class CallscriptShared
	{
		public string PaginationType { get; set; } = "";

		public ThemeDto Theme { get; set; } = new();

		public SupportPagesSettingDto SupportPagesSetting { get; set; } = new();

		public List<IconDto> IconSet { get; set; } = new();

		public List<PageDto> Pages { get; set; } = new();
	}
}