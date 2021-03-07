using MongoDB.Bson.Serialization.Attributes;

namespace LiveSale.Callscripts.Core.Models.Leads
{
	public class CompanyContact
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";

		[BsonIgnore] public string FullName => $"{FirstName} {LastName}";

		public string Position { get; set; } = "";

		public string Phone { get; set; } = "";

		public string MobilePhone { get; set; } = "";

		public string Email { get; set; } = "";
	}
}