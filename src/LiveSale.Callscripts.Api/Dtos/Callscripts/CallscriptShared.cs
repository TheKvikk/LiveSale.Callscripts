using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Dtos.Callscripts
{
	public class CallscriptShared
	{
		public string Name { get; set; } = "";

		public string PaginationType { get; set; } = "";

		public ThemeDto Theme { get; } = new();

		public SupportPagesSettingDto SupportPagesSetting { get; } = new();

		public List<IconDto> IconSet { get; } = new();

		public List<PageDto> Pages { get; } = new();
	}
}