using UnityEditor;

namespace UnityPlugins.Common.Editor
{
	public class ExtendedSOTool
	{
		[MenuItem("Assets/Create Scriptable Object", priority = 1100)]
		public static void ShowCreateDropdown()
		{
			CreateExtendedSODropdown dropdown = new CreateExtendedSODropdown();
			dropdown.ShowAtCurrentMousePosition();
		}
	}
}
