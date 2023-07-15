using System;
using Newtonsoft.Json;

namespace ProceduralLevel.Common.Logic
{
	public class GUIDJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			IGenericGUID id = (IGenericGUID)value;
			writer.WriteValue(id.Value.ToString());
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string rawValue = (string)reader.Value;
			return Activator.CreateInstance(objectType, rawValue);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(IGenericGUID) == objectType;
		}
	}
}
