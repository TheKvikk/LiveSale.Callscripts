using AutoMapper;
using LiveSale.Callscripts.Api.Dtos.Widgets;
using LiveSale.Callscripts.Api.Dtos.Widgets.Visual;
using LiveSale.Callscripts.Core.Models.Widgets;
using LiveSale.Callscripts.Core.Models.Widgets.Visual;

namespace LiveSale.Callscripts.Api.Configurations.Profiles
{
	public class WidgetProfile : Profile
	{
		public WidgetProfile()
		{
			Configure();
		}

		private void Configure()
		{
			CreateMap<Widget, WidgetDto>()
				.ReverseMap();

			CreateMap<Image, ImageDto>()
				.ReverseMap();

			CreateMap<ImageExtra, ImageExtraDto>()
				.ReverseMap();

			CreateMap<ImageValue, ImageValueDto>()
				.ReverseMap();

			CreateMap<ImageWithText, ImageWithTextDto>()
				.ReverseMap();

			CreateMap<ImageWithTextExtra, ImageWithTextExtraDto>()
				.ReverseMap();

			CreateMap<ImageWithTextValue, ImageWithTextValueDto>()
				.ReverseMap();

			CreateMap<SimpleText, SimpleTextDto>()
				.ReverseMap();

			CreateMap<SimpleTextExtra, SimpleTextExtraDto>()
				.ReverseMap();

			CreateMap<SimpleTextValue, SimpleTextValueDto>()
				.ReverseMap();

			CreateMap<Range, RangeDto>()
				.ReverseMap();

			CreateMap<RangeExtra, RangeExtraDto>()
				.ReverseMap();

			CreateMap<RangeValue, RangeValueDto>()
				.ReverseMap();
		}
	}
}