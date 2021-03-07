using System;
using System.Collections.Generic;

namespace LiveSale.Callscripts.Api.Dtos.Campaigns
{
	public class CampaignDto
	{
		public string Id { get; init; } = null!;

		public DateTime DateCreated { get; init; }

		public DateTime DateUpdated { get; set; }

		public bool IsDeleted { get; set; }

		public string Name { get; set; } = "";

		public State State { get; set; } = State.Draft;

		public IEnumerable<CallscriptDto> Callscripts { get; set; } = new List<CallscriptDto>();
	}
}