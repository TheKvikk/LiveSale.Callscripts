using System.Collections.Generic;
using LiveSale.Callscripts.Api.Dtos.Widgets;

namespace LiveSale.Callscripts.Api.Dtos.Callscripts
{
	public class PageDto
	{
		public string Id { get; init; } = null!;

		public int Order { get; set; } = 1;

		public string Headline { get; set; } = "";

		public List<WidgetDto> Widgets { get; set; } = new();
	}
}