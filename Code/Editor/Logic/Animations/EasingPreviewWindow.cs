using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Editor
{
	public class EasingPreviewWindow : AExtendedEditorWindow
	{
		private const float PREVIEW_SIZE = 160f;

		public const string TITLE = "Easing Preview";

		public override string Title => TITLE;

		private Vector2 m_Scroll;

		[MenuItem(CommonEditorConsts.MENU+TITLE)]
		public static void GetEditorWindow()
		{
			GetWindow<EasingPreviewWindow>();
		}

		protected override void Initialize()
		{
		}

		protected override void Terminate()
		{
		}

		protected override void Draw()
		{
			m_Scroll = EditorGUILayout.BeginScrollView(m_Scroll);
			{
				DrawTypes();
			}
			EditorGUILayout.EndScrollView();
		}

		private void DrawTypes()
		{
			float width = Screen.width;
			//To prevent horizontal scrolling
			const float MARGIN = 18;
			int perLine = Mathf.FloorToInt(width/(PREVIEW_SIZE+MARGIN));
			perLine = Mathf.Max(1, perLine);
			int offset = 0;
			bool lineStarted = false;

			EEasingType[] types = EEasingTypeExt.Meta.Values;

			for(int x = 0; x < types.Length; ++x)
			{
				EEasingType type = types[x];
				if(offset % perLine == 0)
				{
					if(lineStarted)
					{
						EditorGUILayout.EndHorizontal();
					}
					lineStarted = true;
					EditorGUILayout.BeginHorizontal();
				}
				offset++;
				Draw(type);
			}

			if(lineStarted)
			{
				EditorGUILayout.EndHorizontal();
			}
		}

		private void Draw(EEasingType type)
		{
			GUILayoutOption widthLimit = GUILayout.MaxWidth(PREVIEW_SIZE);
			EditorGUILayout.BeginVertical();
			{
				EditorGUILayout.LabelField(type.ToString(), EditorStyles.boldLabel, widthLimit);
				EditorGUILayout.BeginVertical("helpbox", widthLimit);
				{
					Rect rect = GUILayoutUtility.GetRect(PREVIEW_SIZE, PREVIEW_SIZE, widthLimit);
					EasingEditorUtility.DrawPreview(rect, type);
				}
				EditorGUILayout.EndVertical();
				EditorGUILayout.Space(PREVIEW_SIZE/3f);
			}
			EditorGUILayout.EndVertical();

		}
	}
}
