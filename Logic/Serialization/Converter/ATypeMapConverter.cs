using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnityPlugins.Common.Logic
{
	public abstract class ATypeMapConverter : JsonConverter
	{
		private const string TYPE_FIELD = "$t";

		private bool _canWrite = true;

		public override bool CanWrite => _canWrite;

		protected abstract TypeMap GetTypeMap();

		private Type GetType(JObject jObject)
		{
			int typeID = (int)jObject.Property(TYPE_FIELD);
			Type simpleType = GetTypeMap().Get(new ID<Type>(typeID));
			return simpleType;
		}

		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			_canWrite = false;
			JObject obj = JObject.FromObject(value);
			obj[TYPE_FIELD] = GetTypeMap().Get(value.GetType()).Value;
			obj.WriteTo(writer);
			_canWrite = true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if(reader.TokenType == JsonToken.Null)
			{
				return null;
			}

			JObject jObject = JObject.Load(reader);
			Type targetType = GetType(jObject);
			object target = Activator.CreateInstance(targetType, true);
			serializer.Populate(jObject.CreateReader(), target);
			return target;
		}
	}
}
