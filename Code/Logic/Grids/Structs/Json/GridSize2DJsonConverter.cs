using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnityPlugins.Common.Logic
{
	public class GridSize2DJsonConverter : JsonConverter<GridSize2D>
	{
		public override GridSize2D ReadJson(JsonReader reader, Type objectType, GridSize2D existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			int x = 0;
			int y = 0;

			if(reader.TokenType == JsonToken.StartArray)
			{
				x = reader.ReadAsInt32().Value;
				y = reader.ReadAsInt32().Value;
				reader.Read(); //end of array
			}
			else if(reader.TokenType == JsonToken.StartObject)
			{
				JObject obj = JObject.Load(reader);
				x = obj.Value<int>(nameof(GridSize2D.X));
				y = obj.Value<int>(nameof(GridSize2D.Y));
			}
			else
			{
				throw new NotSupportedException();
			}
			return new GridSize2D(x, y);
		}

		public override void WriteJson(JsonWriter writer, GridSize2D value, JsonSerializer serializer)
		{
			writer.WriteStartArray();
			writer.WriteValue(value.X);
			writer.WriteValue(value.Y);
			writer.WriteEndArray();
		}
	}
}
