using Newtonsoft.Json;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	public abstract class AEditorSettings
	{
		public static FileDataPersistence Persistence = new FileDataPersistence();

		private static JsonSerializerSettings m_Settings = new JsonSerializerSettings()
		{
			DefaultValueHandling = DefaultValueHandling.Populate
		};

		[JsonIgnore]
		public readonly UnityPath Path;

		public AEditorSettings(string name)
		{
			Path = new UnityPath(EUnityPathType.Project, $"EditorSettings/{name}.json");
		}

		public void Save()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			Path.EnsureDirectory(Persistence);
			Persistence.WriteString(Path, json);
			OnSave();
		}

		public void Load()
		{
			string strPath = Path;
			string json = Persistence.TryReadString(strPath);
			if(string.IsNullOrEmpty(json))
			{
				return;
			}

			JsonConvert.PopulateObject(json, this, m_Settings);
			OnLoad();
		}

		protected virtual void OnSave()
		{

		}

		protected virtual void OnLoad()
		{

		}
	}
}
