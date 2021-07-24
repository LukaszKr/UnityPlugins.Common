using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public class BinaryJsonStorage<TData> : APersistentStorage
		where TData : class
	{
		public readonly TData Target;

		public BinaryJsonStorage(TData target, UnityPath path, bool useBackup = true)
			: base(path, useBackup)
		{
			Target = target;
		}

		protected override void OnLoad(byte[] saveData)
		{
			JsonSerializer serializer = GetSerializer();
			using(MemoryStream ms = new MemoryStream(saveData))
			{
#pragma warning disable CS0618 // Type or member is obsolete
				using(BsonReader jsonReader = new BsonReader(ms))
#pragma warning restore CS0618 // Type or member is obsolete
				{
					serializer.Populate(jsonReader, Target);
				}
			}
		}

		protected override byte[] OnFlush()
		{
			JsonSerializer serializer = new JsonSerializer();
			using(MemoryStream ms = new MemoryStream())
			{
#pragma warning disable CS0618 // Type or member is obsolete
				using(BsonWriter jsonWriter = new BsonWriter(ms))
#pragma warning restore CS0618 // Type or member is obsolete
				{
					serializer.Serialize(jsonWriter, Target);
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
