using System;
using Newtonsoft.Json;

namespace ProceduralLevel.Common.Logic
{
	public class IDJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			IGenericID id = (IGenericID)value;
			writer.WriteValue(id.Value);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int rawValue = (int)(long)reader.Value;
			return Activator.CreateInstance(objectType, rawValue);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IGenericID) == objectType;
		}
	}
}