using System.Collections.Generic;
using LiveSale.Callscripts.Api.Models.Widgets;
using LiveSale.Callscripts.Api.Models.Widgets.Visual;
using Microsoft.AspNetCore.Mvc;

namespace LiveSale.Callscripts.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WidgetsController : ControllerBase
	{
		private static readonly List<Widget> _widgets = new()
		{
			new SimpleText
			{
				Extra =
				{
					Values =
					{
						new SimpleTextValue
						{
							Id = "adsfsdgf",
							Order = 1,
							TextMarkdown = "# Ahoj"
						}
					}
				}
			},
			new Image
			{
				Extra =
				{
					Values =
					{
						new ImageValue
						{
							Id = "adfsd",
							ImageUrl =
								"https://images.pexels.com/photos/162140/duckling-birds-yellow-fluffy-162140.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
							Order = 1
						}
					}
				}
			},
			new ImageWithText
			{
				Extra =
				{
					Values =
					{
						new ImageWithTextValue
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
			}
		};

		[HttpGet]
		public IEnumerable<Widget> Get()
		{
			return _widgets;
		}
	}
}