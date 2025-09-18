using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnityPlugins.Common.Logic
{
	public class GridPoint3DJsonConverter : JsonConverter<GridPoint3D>
	{
		public override GridPoint3D ReadJson(JsonReader reader, Type objectType, GridPoint3D existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			int x = 0;
			int y = 0;
			int z = 0;

			if(reader.TokenType == JsonToken.StartArray)
			{
				x = reader.ReadAsInt32().Value;
				y = reader.ReadAsInt32().Value;
				z = reader.ReadAsInt32().Value;
				reader.Read(); //end of array
			}
			else if(reader.TokenType == JsonToken.StartObject)
			{
				JObject obj = JObject.Load(reader);
				x = obj.Value<int>(nameof(GridPoint3D.X));
				y = obj.Value<int>(nameof(GridPoint3D.Y));
				z = obj.Value<int>(nameof(GridPoint3D.Z));
			}
			else
			{
				throw new NotSupportedException();
			}
			return new GridPoint3D(x, y, z);
		}

		public override void WriteJson(JsonWriter writer, GridPoint3D value, JsonSerializer serializer)
		{
			writer.WriteStartArray();
			writer.WriteValue(value.X);
			writer.WriteValue(value.Y);
			writer.WriteValue(value.Z);
			writer.WriteEndArray();
		}
	}
}
