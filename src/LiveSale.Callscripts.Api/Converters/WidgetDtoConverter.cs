using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Dtos.Widgets;
using LiveSale.Callscripts.Api.Dtos.Widgets.Visual;

namespace LiveSale.Callscripts.Api.Converters
{
	public class WidgetDtoConverter : JsonConverter<WidgetDto>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeof(WidgetDto).IsAssignableFrom(typeToConvert);
		}

		public override WidgetDto Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject)
			{
				throw new JsonException();
			}

			reader.Read();

			if (reader.TokenType != JsonTokenType.PropertyName)
			{
				throw new JsonException();
			}

			var propertyName = reader.GetString();

			if (propertyName != "Type")
			{
				throw new JsonException();
			}

			reader.Read();

			if (reader.TokenType != JsonTokenType.String)
			{
				throw new JsonException();
			}

			var typeDiscriminator = reader.GetString();
			WidgetDto widget = typeDiscriminator switch
			{
				"simpletext" => new SimpleTextDto(),
				"imagetext" => new ImageWithTextDto(),
				"image" => new ImageDto(),
				_ => throw new JsonException()
			};

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					return widget;
				}

				if (reader.TokenType == JsonTokenType.PropertyName)
				{
					propertyName = reader.GetString();
					reader.Read();

					switch (propertyName)
					{
						case "Extra":
							var type = widget.Type switch
							{
								"simpletext" => typeof(SimpleTextExtraDto),
								"imagetext" => typeof(ImageWithTextExtraDto),
								"image" => typeof(ImageExtraDto),
								_ => throw new ArgumentOutOfRangeException()
							};

							var extra = JsonSerializer.Deserialize(ref reader, type, options);
							widget.GetType().GetProperty("Extra")?.SetValue(widget, extra);
							break;
					}
				}
			}

			throw new JsonException();
		}

		public override void Write(
			Utf8JsonWriter writer,
			WidgetDto widget,
			JsonSerializerOptions options)
		{
			writer.WriteStartObject();

			var policy = options.PropertyNamingPolicy;

			writer.WriteString(policy?.ConvertName("Type") ?? "Type", widget.Type);
			writer.WriteString(policy?.ConvertName("Subtype") ?? "Subtype", widget.Subtype);
			writer.WriteString(policy?.ConvertName("Id") ?? "Id", widget.Id);
			writer.WriteNumber(policy?.ConvertName("Order") ?? "Order", widget.Order);
			writer.WriteBoolean(policy?.ConvertName("Required") ?? "Required", widget.Required);
			writer.WriteBoolean(policy?.ConvertName("Valid") ?? "Valid", widget.Valid);
			writer.WriteString(policy?.ConvertName("HeaderText") ?? "HeaderText", widget.HeaderText);
			writer.WriteString(policy?.ConvertName("NoteText") ?? "NoteText", widget.NoteText);

			var extraProperty = widget.GetType().GetProperties().SingleOrDefault(property => property.Name == "Extra");

			if (extraProperty != null)
			{
				writer.WritePropertyName(policy?.ConvertName("Extra") ?? "Extra");
				JsonSerializer.Serialize(writer, extraProperty.GetValue(widget), options);
			}

			writer.WriteEndObject();
		}
	}
}