using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public abstract class AEditorSettingsDrawer<TSettings>
		where TSettings : AEditorSettings
	{
		public void Draw(TSettings settings)
		{
			DrawOptions(settings);

			EditorGUI.BeginChangeCheck();
			{
				OnDraw(settings);
			}
			bool changed = EditorGUI.EndChangeCheck();
			if(changed)
			{
				settings.Save();
			}
		}

		protected void DrawOptions(TSettings settings)
		{
			EditorGUILayout.BeginHorizontal("helpbox");
			{
				if(GUILayout.Button("Save"))
				{
					settings.Save();
				}
				if(GUILayout.Button("Load"))
				{
					settings.Load();
				}
			}
			EditorGUILayout.EndHorizontal();
		}

		protected abstract void OnDraw(TSettings settings);
	}
}
