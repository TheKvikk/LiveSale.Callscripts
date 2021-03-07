using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Core.Models.Callscripts
{
	public class Callscript : CallscriptShared
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;

		public bool IsDeleted { get; set; }

		public State State { get; set; } = State.Draft;
	}
}