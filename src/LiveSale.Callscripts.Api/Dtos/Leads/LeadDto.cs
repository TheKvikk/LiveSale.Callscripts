using System;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Dtos.Callscripts;

namespace LiveSale.Callscripts.Api.Dtos.Leads
{
	public class LeadDto : CallscriptShared
	{
		public string Id { get; init; } = null!;

		public DateTime DateCreated { get; set; }

		public DateTime DateUpdated { get; set; }

		public DateTime DateDue { get; set; }

		[JsonIgnore] public State State { get; set; } = State.Created;

		public int ActiveWidgetIndex { get; set; } = 0;

		public ContactDto Contact { get; set; } = new();

		public bool Started => State == State.Started;

		public bool Completed => State == State.Completed;
	}
}