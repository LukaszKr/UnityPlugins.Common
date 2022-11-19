using Newtonsoft.Json;
using System;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class UIDJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteValue(value.GetHashCode());
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			int intValue = int.Parse(reader.Value.ToString());
			return Activator.CreateInstance(objectType, intValue);
		}

		public override bool CanConvert(Type objectType)
		{
			return true;
		}
	}
}