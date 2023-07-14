using Newtonsoft.Json;
using ProceduralLevel.Common.Identity;
using System;

namespace ProceduralLevel.Common.Logic
{
	public class IDJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			int rawValue = int.Parse(value.ToString());
			writer.WriteValue(rawValue);

		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int rawValue = int.Parse(reader.Value.ToString());
			return Activator.CreateInstance(objectType, rawValue);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(ID<>) == objectType;
		}
	}
}