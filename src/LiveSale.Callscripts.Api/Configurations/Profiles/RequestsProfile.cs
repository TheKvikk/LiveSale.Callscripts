using AutoMapper;
using LiveSale.Callscripts.Api.Commands;
using LiveSale.Callscripts.Api.Dtos.Requests;

namespace LiveSale.Callscripts.Api.Configurations.Profiles
{
	public class RequestsProfile : Profile
	{
		public RequestsProfile()
		{
			Configure();
		}

		private void Configure()
		{
			CreateMap<UpdateLeadsWidgetAnswerDto, UpdateLeadsWidgetAnswerCommand>();
			
			CreateMap<UpdateLeadsStateDto, UpdateLeadsStateCommand>();
			
			CreateMap<InsertLeadDto, InsertLeadCommand>();
		}
	}
}