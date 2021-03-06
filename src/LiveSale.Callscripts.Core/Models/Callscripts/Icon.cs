using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Core.Models.Callscripts
{
	public class Icon
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;

		public string Svg { get; set; } = "";
	}
}