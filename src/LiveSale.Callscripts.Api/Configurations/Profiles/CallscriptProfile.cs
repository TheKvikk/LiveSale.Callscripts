using AutoMapper;
using LiveSale.Callscripts.Api.Dtos.Callscripts;
using LiveSale.Callscripts.Core.Models.Callscripts;

namespace LiveSale.Callscripts.Api.Configurations.Profiles
{
	public class CallscriptProfile : Profile
	{
		public CallscriptProfile()
		{
			Configure();
		}

		private void Configure()
		{
			CreateMap<Callscript, CallscriptDto>()
				.ReverseMap();

			CreateMap<Icon, IconDto>()
				.ReverseMap();

			CreateMap<Page, PageDto>()
				.ReverseMap();

			CreateMap<SupportPagesSetting, SupportPagesSettingDto>()
				.ReverseMap();

			CreateMap<SupportPageSetting, SupportPageSettingDto>()
				.ReverseMap();

			CreateMap<Theme, ThemeDto>()
				.ReverseMap();
		}
	}
}