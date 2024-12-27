using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace UnityPlugins.Common.Unity
{
	public class BinaryJsonStorage<TData> : ADataStorage<TData>
		where TData : class
	{
		public BinaryJsonStorage(ADataPersistence persistence, string filePath, bool useBackup = true)
			: base(persistence, filePath, useBackup)
		{
		}

		public BinaryJsonStorage(ADataPersistence persistence, UnityPath filePath, bool useBackup = true)
			: base(persistence, filePath, useBackup)
		{
		}

		protected override TData FromBytes(TData current, byte[] saveData)
		{
			JsonSerializer serializer = GetSerializer();
			using(MemoryStream ms = new MemoryStream(saveData))
			{
				using(BsonReader jsonReader = new BsonReader(ms))
				{
					if(current == null)
					{
						return serializer.Deserialize<TData>(jsonReader);
					}
					serializer.Populate(jsonReader, current);
					return current;
				}
			}
		}

		protected override byte[] ToBytes(TData data)
		{
			JsonSerializer serializer = new JsonSerializer();
			using(MemoryStream ms = new MemoryStream())
			{
				using(BsonWriter jsonWriter = new BsonWriter(ms))
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
