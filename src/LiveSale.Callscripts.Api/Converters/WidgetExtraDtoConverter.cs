using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LiveSale.Callscripts.Api.Converters
{
	public class WidgetExtraDtoConverter<T> : JsonConverter<T>
	{
		private const string RequiredAttributeName = "Required";
		private const BindingFlags FlagsToGetValue =
			BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

		public override bool CanConvert(Type typeToConvert)
		{
			return true;
		}

		public override T Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			var properties = typeToConvert.GetProperties()
				.Select(p => p.Name.ToLowerInvariant()).ToList();

			if (reader.TokenType != JsonTokenType.StartObject)
			{
				throw new JsonException();
			}

			var returnObject = (T) Activator.CreateInstance(typeToConvert)!;

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
				{
					return returnObject;
				}

				if (reader.TokenType != JsonTokenType.PropertyName)
				{
					throw new JsonException();
				}

				var propertyName = reader.GetString()!;

				if (!properties.Contains(propertyName))
				{
					throw new JsonException();
				}

				reader.Read();

				var property = typeToConvert.GetProperty(propertyName, FlagsToGetValue)!;
				var value = JsonSerializer.Deserialize(ref reader, property.PropertyType, options);
				var attributes = property.GetCustomAttributes();
				var hasRequiredAttribute = attributes.FirstOrDefault(a => a.GetType().Name.Contains(RequiredAttributeName));
				if (hasRequiredAttribute is RequiredAttribute requiredAttribute && IsNullEmpty(value, property.PropertyType))
				{
					throw new JsonException(requiredAttribute.FormatErrorMessage(propertyName));
				}
				var allNonRequiredAttributes = attributes.Where(attribute => !attribute.GetType().Name.Contains(RequiredAttributeName))
					.ToList();

				if (allNonRequiredAttributes.Count > 0)
				{
					foreach (var notRequired in allNonRequiredAttributes)
					{
						if (notRequired is ValidationAttribute validationAttribute && !validationAttribute.IsValid(value))
						{
							throw new JsonException(validationAttribute.FormatErrorMessage(propertyName));
						}
					}
				}
				
				returnObject.GetType().GetProperty(propertyName, FlagsToGetValue)?.SetValue(returnObject, value);
			}

			throw new JsonException();
		}

		public override void Write(
			Utf8JsonWriter writer,
			T typeToConvert,
			JsonSerializerOptions options)
		{
			writer.WriteStartObject();

			var policy = options.PropertyNamingPolicy;
			var properties = typeToConvert!.GetType().GetProperties();

			foreach (var property in properties)
			{
				var value = property.GetValue(typeToConvert);

				if (value == null)
				{
					writer.WriteNull(policy?.ConvertName(property.Name) ?? property.Name);
					continue;
				}

				if (value.GetType().IsPrimitive)
				{
					writer.WriteString(policy?.ConvertName(property.Name) ?? property.Name, value.ToString());
					continue;
				}

				writer.WritePropertyName(policy?.ConvertName(property.Name) ?? property.Name);
				JsonSerializer.Serialize(writer, value, options);
			}

			writer.WriteEndObject();
		}

		private bool IsNullEmpty(object? testedValue, Type testedType)
		{
			if (testedValue == null)
			{
				return true;
			}

			if (testedType.IsArray)
			{
				return (testedValue as Array)!.Length == 0;
			}

			if (typeof(string) == testedType)
			{
				return string.IsNullOrEmpty(testedValue as string);
			}
			
			return Activator.CreateInstance(testedType)!.Equals(testedValue);
		}
	}
}