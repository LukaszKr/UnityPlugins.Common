using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UnityPlugins.Common.Logic
{
	public class GridPoint2DJsonConverter : JsonConverter<GridPoint2D>
	{
		public override GridPoint2D ReadJson(JsonReader reader, Type objectType, GridPoint2D existingValue, bool hasExistingValue, JsonSerializer serializer)
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
				x = obj.Value<int>(nameof(GridPoint2D.X));
				y = obj.Value<int>(nameof(GridPoint2D.Y));
			}
			else
			{
				throw new NotSupportedException();
			}
			return new GridPoint2D(x, y);
		}

		public override void WriteJson(JsonWriter writer, GridPoint2D value, JsonSerializer serializer)
		{
			writer.WriteStartArray();
			writer.WriteValue(value.X);
			writer.WriteValue(value.Y);
			writer.WriteEndArray();
		}
	}
}
