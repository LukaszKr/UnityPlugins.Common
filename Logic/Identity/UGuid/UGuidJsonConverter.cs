using System;
using Newtonsoft.Json;

namespace UnityPlugins.Common.Logic
{
	public class UGuidJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			string strValue = value.ToString();
			writer.WriteValue(strValue);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string rawValue = (string)reader.Value;
			return Activator.CreateInstance(objectType, rawValue);
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(UGuid<>) == objectType;
		}
	}
}