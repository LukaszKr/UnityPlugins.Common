using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class GUILayoutExt
	{
		public static bool ConditionalButton(string label, bool condition, params GUILayoutOption[] options)
		{
			bool clicked = false;

			EditorGUI.BeginDisabledGroup(!condition);
			{
				if(options.Length > 0)
				{
					clicked = GUILayout.Button(label, options);
				}
				else
				{
					clicked = GUILayout.Button(label);
				}
			}
			EditorGUI.EndDisabledGroup();

			return clicked;
		}
	}
}
