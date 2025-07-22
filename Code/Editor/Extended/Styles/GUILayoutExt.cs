using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class GUILayoutExt
	{
		public static bool Button(string label, bool disabled)
		{
			bool clicked = false;

			EditorGUI.BeginDisabledGroup(disabled);
			{
				if(GUILayout.Button(label))
				{
					clicked = true;
				}
			}
			EditorGUI.EndDisabledGroup();

			return clicked;
		}
	}
}
