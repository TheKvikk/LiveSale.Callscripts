using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Api.Models.Widgets
{
	public class BaseValue
	{
		[BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; } = null!;

    public int Order { get; init; } = 1;
	}
}