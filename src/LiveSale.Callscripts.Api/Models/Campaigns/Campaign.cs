using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Api.Models.Campaigns
{
	public class Campaign
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;

		public DateTime DateCreated { get; init; }
		
		public DateTime DateUpdated { get; set; }

		public bool IsDeleted { get; set; }

		public string Name { get; set; } = "";

		public State State { get; set; } = State.Draft;

		public IEnumerable<Callscript> Callscripts { get; set; }
	}
}