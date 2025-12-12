using UnityEditor;

namespace UnityPlugins.Common.Editor
{
	public class CommonEditorSettingsWindow : AExtendedEditorWindow
	{
		public const string TITLE = "Common Editor Settings";

		public override string Title => TITLE;

		private CommonEditorSettingsDrawer m_SettingsDrawer = new CommonEditorSettingsDrawer();

		[MenuItem(CommonEditorConsts.MENU + TITLE)]
		public static void GetEditorWindow()
		{
			GetWindow<CommonEditorSettingsWindow>();
		}

		protected override void Initialize()
		{
		}

		protected override void Terminate()
		{
		}

		protected override void Draw()
		{
			m_SettingsDrawer.Draw(CommonEditorSettings.Instance);
		}
	}
}
