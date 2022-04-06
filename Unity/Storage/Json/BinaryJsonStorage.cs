using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
{
	public class BinaryJsonStorage<TData> : APersistentStorage<TData>
	{
		public BinaryJsonStorage(UnityPath path, bool useBackup = true)
			: base(path, useBackup)
		{
		}

		protected override TData OnLoad(byte[] saveData)
		{
			JsonSerializer serializer = GetSerializer();
			using(MemoryStream ms = new MemoryStream(saveData))
			{
#pragma warning disable CS0618 // Type or member is obsolete
				using(BsonReader jsonReader = new BsonReader(ms))
#pragma warning restore CS0618 // Type or member is obsolete
				{
					return serializer.Deserialize<TData>(jsonReader);
				}
			}
		}

		protected override byte[] OnFlush(TData data)
		{
			JsonSerializer serializer = new JsonSerializer();
			using(MemoryStream ms = new MemoryStream())
			{
#pragma warning disable CS0618 // Type or member is obsolete
				using(BsonWriter jsonWriter = new BsonWriter(ms))
#pragma warning restore CS0618 // Type or member is obsolete
				{
					serializer.Serialize(jsonWriter, data);
				}
				return ms.ToArray();
			}
		}

		private JsonSerializer GetSerializer()
		{
			JsonSerializer serializer = new JsonSerializer();
			serializer.ObjectCreationHandling = ObjectCreationHandling.Reuse;
			return serializer;
		}
	}
}
