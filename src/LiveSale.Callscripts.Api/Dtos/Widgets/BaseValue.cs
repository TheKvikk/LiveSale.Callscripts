using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Converters;

namespace LiveSale.Callscripts.Api.Dtos.Widgets
{
	[JsonConverter(typeof(WidgetExtraDtoConverter<BaseValue>))]
	public class BaseValue
	{
		[Required]
		public string Id { get; init; } = null!;

		[Required]
		public int Order { get; init; } = 1;
	}
}