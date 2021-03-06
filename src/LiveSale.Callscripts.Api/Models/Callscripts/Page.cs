using System.Collections.Generic;
using LiveSale.Callscripts.Api.Models.Widgets;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Api.Models.Callscripts
{
	public class Page
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;

		public int Order { get; set; } = 1;

		public string Headline { get; set; } = "";

		public List<Widget> Widgets { get; } = new();
	}
}