using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnityPlugins.Common.Logic
{
	public class GridSize3DJsonConverter : JsonConverter<GridSize3D>
	{
		public override GridSize3D ReadJson(JsonReader reader, Type objectType, GridSize3D existingValue, bool hasExistingValue, JsonSerializer serializer)
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
				x = obj.Value<int>(nameof(GridSize3D.X));
				y = obj.Value<int>(nameof(GridSize3D.Y));
				z = obj.Value<int>(nameof(GridSize3D.Z));
			}
			else
			{
				throw new NotSupportedException();
			}
			return new GridSize3D(x, y, z);
		}

		public override void WriteJson(JsonWriter writer, GridSize3D value, JsonSerializer serializer)
		{
			writer.WriteStartArray();
			writer.WriteValue(value.X);
			writer.WriteValue(value.Y);
			writer.WriteValue(value.Z);
			writer.WriteEndArray();
		}
	}
}
