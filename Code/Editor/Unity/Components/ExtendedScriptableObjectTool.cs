using UnityEditor;

namespace UnityPlugins.Common.Editor
{
	public class ExtendedScriptableObjectTool
	{
		[MenuItem("Assets/Create Scriptable Object", priority = 1100)]
		public static void ShowCreateDropdown()
		{
			CreateExtendedScriptableObjectDropdown dropdown = new CreateExtendedScriptableObjectDropdown();
			dropdown.ShowAtCurrentMousePosition();
		}
	}
}
