using System.Text;
using Newtonsoft.Json;

namespace ProceduralLevel.Common.Unity.Storage
{
	public class TextJsonStorage<TData> : APersistentStorage<TData>
		where TData : class
	{

		public TextJsonStorage(UnityPath path, bool useBackup = true)
			: base(path, useBackup)
		{
		}

		protected override TData OnLoad(TData current, byte[] saveData)
		{
			string content = Encoding.UTF8.GetString(saveData);
			if(current == null)
			{
				return JsonConvert.DeserializeObject<TData>(content);
			}
			JsonConvert.PopulateObject(content, current);
			return current;
		}

		protected override byte[] OnFlush(TData data)
		{
			string text = JsonConvert.SerializeObject(data, Formatting.Indented);
			return Encoding.UTF8.GetBytes(text);
		}
	}
}
