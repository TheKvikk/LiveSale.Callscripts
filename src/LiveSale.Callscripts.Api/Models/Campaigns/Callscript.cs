using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Api.Models.Campaigns
{
	public class Callscript
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;
		
		public string Name { get; set; } = "";
		
		public string Url { get; set; } = "";
	}
}