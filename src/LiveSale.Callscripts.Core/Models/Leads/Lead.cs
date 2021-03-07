using System;
using LiveSale.Callscripts.Core.Models.Callscripts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Core.Models.Leads
{
	public class Lead : CallscriptShared
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;

		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string CallscriptId { get; init; }

		public DateTime DateCreated { get; set; }

		public DateTime DateUpdated { get; set; }

		public DateTime DateDue { get; set; }

		public State State { get; set; } = State.Created;

		public int ActiveWidgetIndex { get; set; } = 0;

		public Contact Contact { get; set; } = new();
	}
}