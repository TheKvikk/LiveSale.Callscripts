using AutoMapper;
using LiveSale.Callscripts.Api.Dtos.Leads;
using LiveSale.Callscripts.Core.Models.Leads;

namespace LiveSale.Callscripts.Api.Configurations.Profiles
{
	public class LeadProfile : Profile
	{
		public LeadProfile()
		{
			Configure();
		}

		private void Configure()
		{
			CreateMap<Lead, LeadDto>()
				.ReverseMap();

			CreateMap<Contact, ContactDto>()
				.ReverseMap();

			CreateMap<CompanyContact, CompanyContactDto>()
				.ReverseMap();

			CreateMap<Company, CompanyDto>()
				.ReverseMap();

			CreateMap<ContactValue, ContactValueDto>()
				.ReverseMap();
		}
	}
}