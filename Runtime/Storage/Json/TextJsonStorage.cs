using System.Text;
using Newtonsoft.Json;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public class TextJsonStorage<TData> : APersistentStorage
		where TData : class
	{
		public readonly TData Target;

		public TextJsonStorage(TData target, UnityPath path, bool useBackup = true)
			: base(path, useBackup)
		{
			Target = target;
		}

		protected override void OnLoad(byte[] saveData)
		{
			string content = Encoding.UTF8.GetString(saveData);
			JsonConvert.PopulateObject(content, Target);
		}

		protected override byte[] OnFlush()
		{
			string text = JsonConvert.SerializeObject(Target, Formatting.Indented);
			return Encoding.UTF8.GetBytes(text);
		}
	}
}
