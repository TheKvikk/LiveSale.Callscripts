using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	public class ContactsDto : WidgetDto, IWidgetExtra<ContactsExtraDto>
	{
		public override string Type => "contacts";

		public ContactsExtraDto Extra { get; set; } = new();
	}

	[JsonConverter(typeof(WidgetExtraDtoConverter<ContactsExtraDto>))]
	public class ContactsExtraDto
	{
		[Required]
		public ContactValueDto IsCompanyContact { get; set; } = new();

		public CompanyDto Company { get; set; } = new();

		public PersonDto Person { get; set; } = new();
	}

	public class CompanyDto
	{
		public string Id { get; set; } = null!;

		public ContactValueDto Name { get; set; } = new();

		public ContactValueDto IdentificationNumber { get; set; } = new();
		
		public ContactValueDto Vat { get; set; } = new();
		
		public ContactValueDto Phone { get; set; } = new();
		
		public ContactValueDto Mobile { get; set; } = new();
		
		public ContactValueDto Email { get; set; } = new();
		
		public ContactValueDto Email2 { get; set; } = new();
		
		public ContactValueDto GroupMail { get; set; } = new();
		
		public ContactValueDto WebUrl { get; set; } = new();
	}

	public class PersonDto : BaseValue
	{
		public ContactValueDto FirstName { get; set; } = new();
		
		public ContactValueDto LastName { get; set; } = new();
		
		public ContactValueDto Position { get; set; } = new();
		
		public ContactValueDto Phone { get; set; } = new();
		
		public ContactValueDto Mobile { get; set; } = new();
		
		public ContactValueDto Email { get; set; } = new();
		
		public ContactValueDto Email2 { get; set; } = new();
	}

	public class ContactValueDto
	{
		public bool Show { get; set; }

		public bool Required { get; set; }
		
		public bool Valid { get; set; }
		
		public string Value { get; set; }
	}
}