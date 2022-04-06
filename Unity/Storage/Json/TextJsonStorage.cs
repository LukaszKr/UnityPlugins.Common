using System.Text;
using Newtonsoft.Json;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
{
	public class TextJsonStorage<TData> : APersistentStorage<TData>
	{

		public TextJsonStorage(UnityPath path, bool useBackup = true)
			: base(path, useBackup)
		{
		}

		protected override TData OnLoad(byte[] saveData)
		{
			string content = Encoding.UTF8.GetString(saveData);
			return JsonConvert.DeserializeObject<TData>(content);
		}

		protected override byte[] OnFlush(TData data)
		{
			string text = JsonConvert.SerializeObject(data, Formatting.Indented);
			return Encoding.UTF8.GetBytes(text);
		}
	}
}
