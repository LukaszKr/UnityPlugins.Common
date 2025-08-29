using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityPlugins.Common.Editor
{
	public static class AdvancedDropdownExt
	{
		public static void ShowAtCurrentMousePosition(this AdvancedDropdown dropdown)
		{
			Rect rect;
			if(Event.current != null)
			{
				rect = GUILayoutUtility.GetLastRect();
				rect.width = Screen.width;
				rect.position = Event.current.mousePosition;
			}
			else
			{
				rect = new Rect(0, 0, Screen.width/4f, Screen.height/2f);

				Vector2 mousePosition = Mouse.current.position.ReadValue();
				//Unity! Left most corner is on 0, BUT vertical 0 is in middle of height.
				rect.position = new Vector2(mousePosition.x, -Screen.height/2f+mousePosition.y);
			}

			dropdown.Show(rect);
		}
	}
}
