using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using LiveSale.Callscripts.Api.Models.Widgets;
using LiveSale.Callscripts.Api.Models.Widgets.Visual;

namespace LiveSale.Callscripts.Api.Converters
{
	public class WidgetConverter : JsonConverter<Widget>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeof(Widget).IsAssignableFrom(typeToConvert);
		}

		public override Widget Read(
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

			string? propertyName = reader.GetString();

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
			Widget widget = typeDiscriminator switch
			{
				"simpletext" => new SimpleText(),
				"imagetext" => new ImageWithText(),
				"image" => new Image(),
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
								"simpletext" => typeof(SimpleTextExtra),
								"imagetext" => typeof(ImageWithTextExtra),
								"image" => typeof(ImageExtra),
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
			Widget widget,
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