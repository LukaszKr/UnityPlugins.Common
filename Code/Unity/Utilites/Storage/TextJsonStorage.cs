using System.Text;
using Newtonsoft.Json;

namespace UnityPlugins.Common.Unity
{
	public class TextJsonStorage<TData> : ADataStorage<TData>
		where TData : class
	{
		public TextJsonStorage(ADataPersistence persistence, string filePath, bool useBackup = true)
			: base(persistence, filePath, useBackup)
		{
		}

		public TextJsonStorage(ADataPersistence persistence, UnityPath filePath, bool useBackup = true)
			: base(persistence, filePath, useBackup)
		{
		}

		protected override TData FromBytes(TData current, byte[] saveData)
		{
			string content = Encoding.UTF8.GetString(saveData);
			if(current == null)
			{
				return JsonConvert.DeserializeObject<TData>(content);
			}
			JsonConvert.PopulateObject(content, current);
			return current;
		}

		protected override byte[] ToBytes(TData data)
		{
			string text = JsonConvert.SerializeObject(data, Formatting.Indented);
			return Encoding.UTF8.GetBytes(text);
		}
	}
}
