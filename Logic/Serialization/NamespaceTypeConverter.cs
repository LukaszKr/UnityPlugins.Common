using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProceduralLevel.Common.Logic
{
	public class NamespaceTypeConverter : JsonConverter
	{
		public const string TYPE_FIELD = "$type";

		public readonly string Namespace;
		public readonly string AssemblyName;
		private bool _canWrite = true;

		public override bool CanWrite => _canWrite;

		public NamespaceTypeConverter(string namespaceAndAssembly)
		{
			Namespace = namespaceAndAssembly;
			AssemblyName = namespaceAndAssembly;
		}
		public NamespaceTypeConverter(string @namespace, string assembly)
		{
			Namespace = @namespace;
			AssemblyName = assembly;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			_canWrite = false;
			JObject obj = JObject.FromObject(value);
			obj[TYPE_FIELD] = value.GetType().Name;
			obj.WriteTo(writer);
			_canWrite = true;
		}

		private Type GetType(JObject jObject)
		{
			string typeName = (string)jObject.Property(TYPE_FIELD);
			string fullTypeName = $"{Namespace}.{typeName}, {AssemblyName}";
			Type simpleType = Type.GetType(fullTypeName);
			return simpleType;
		}

		public override bool CanConvert(Type objectType)
		{
			// return typeof(T).IsAssignableFrom(objectType);
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType,
			object existingValue, JsonSerializer serializer)
		{
			if(reader.TokenType == JsonToken.Null)
			{
				return null;
			}

			JObject jObject = JObject.Load(reader);
			Type targetType = GetType(jObject);
			if(targetType == null)
			{
				return null;
			}

			object target = Activator.CreateInstance(targetType, true);
			serializer.Populate(jObject.CreateReader(), target);
			return target;
		}
	}
}
