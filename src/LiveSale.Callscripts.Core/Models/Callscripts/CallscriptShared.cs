using System.Collections.Generic;

namespace LiveSale.Callscripts.Core.Models.Callscripts
{
	public class CallscriptShared
	{
		public string Name { get; set; } = "";

		public string PaginationType { get; set; } = "";

		public Theme Theme { get; } = new();

		public SupportPagesSetting SupportPagesSetting { get; } = new();

		public List<Icon> IconSet { get; } = new();

		public List<Page> Pages { get; } = new();
	}
}