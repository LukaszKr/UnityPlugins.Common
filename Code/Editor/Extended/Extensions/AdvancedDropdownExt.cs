using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class AdvancedDropdownExt
	{
		public static void ShowAtCurrentMousePosition(this AdvancedDropdown dropdown)
		{
			Rect rect = GUILayoutUtility.GetLastRect();
			rect.width = Screen.width;
			rect.position = Event.current.mousePosition;
			dropdown.Show(rect);
		}
	}
}
