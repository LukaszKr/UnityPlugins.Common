using UnityEditor;

namespace UnityPlugins.Common.Editor
{
	[InitializeOnLoad]
	public class CommonEditorSettings : AEditorSettings
	{
		public static readonly CommonEditorSettings Instance = new CommonEditorSettings();

		static CommonEditorSettings()
		{
			Instance.Load();
		}

		private CommonEditorSettings()
			: base("Common")
		{

		}

		public void Apply()
		{
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			Apply();
		}

		protected override void OnSave()
		{
			base.OnSave();
			Apply();
		}
	}
}
