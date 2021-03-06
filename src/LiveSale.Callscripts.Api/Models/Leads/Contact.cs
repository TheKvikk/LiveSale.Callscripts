using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Api.Models.Leads
{
	public class Contact
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; init; } = null!;

		public bool IsCompanyContact { get; set; }

		public Company Company { get; set; } = new();

		public CompanyContact CompanyContact { get; set; } = new();
	}
}