using UnityEditor;

namespace UnityPlugins.Common.Editor
{
	public class DataContainerTool
	{
		[MenuItem("Assets/Create Data Container", priority = 1100)]
		public static void ShowCreateDropdown()
		{
			CreateDataContainerDropdown dropdown = new CreateDataContainerDropdown();
			dropdown.ShowAtCurrentMousePosition();
		}
	}
}
