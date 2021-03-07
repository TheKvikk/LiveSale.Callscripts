using System.Collections.Generic;
using LiveSale.Callscripts.Api.Dtos.Widgets;
using LiveSale.Callscripts.Api.Dtos.Widgets.Visual;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WidgetsController : ControllerBase
	{
		private static readonly List<WidgetDto> _widgets = new()
		{
			new SimpleTextDto
			{
				Extra =
				{
					Values =
					{
						new SimpleTextValueDto
						{
							Id = "adsfsdgf",
							Order = 1,
							TextMarkdown = "# Ahoj"
						}
					}
				}
			},
			new ImageDto
			{
				Extra =
				{
					Values =
					{
						new ImageValueDto
						{
							Id = "adfsd",
							ImageUrl =
								"https://images.pexels.com/photos/162140/duckling-birds-yellow-fluffy-162140.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
							Order = 1
						}
					}
				}
			},
			new ImageWithTextDto
			{
				Extra =
				{
					Values =
					{
						new ImageWithTextValueDto
						{
							Id = "asdfsd",
							ImageUrl =
								"https://storage.googleapis.com/replit/images/1593443762535_99794dba97aa8af72260c5aa20c5c9fd.jpeg",
							Order = 1,
							Position = "left",
							TextMarkdown = "# Další nadpis pro test"
						}
					}
				}
			},
			new RangeDto
			{
				Extra =
				{
					Value =
						new()
						{
							Parts = new[] {"Domácnosti", "Firmy"}
						}
				}
			}
		};

		[HttpGet]
		public IEnumerable<WidgetDto> Get()
		{
			return _widgets;
		}
	}
}