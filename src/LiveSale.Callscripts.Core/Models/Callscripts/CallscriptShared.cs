using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Callscripts
{
	public class CallscriptShared
	{
		public string PaginationType { get; set; } = "";

		public Theme Theme { get; set; } = new();

		public SupportPagesSetting SupportPagesSetting { get; set; } = new();

		public List<Icon> IconSet { get; set; } = new();

		public List<Page> Pages { get; set; } = new();
	}
}