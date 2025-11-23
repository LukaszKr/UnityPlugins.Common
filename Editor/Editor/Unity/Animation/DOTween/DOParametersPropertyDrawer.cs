using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	[CustomPropertyDrawer(typeof(DOParameters))]
	public class DOParametersPropertyDrawer : AExtendedPropertyDrawer
	{
		private const float DASH_LENGTH = 1f;
		private const float PREVIEW_LINES = 5f;

		private static readonly Rect[] rectLines = new Rect[3];

		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			Draw(position, label,
			property.FindPropertyRelative(nameof(DOParameters.Duration)),
			property.FindPropertyRelative(nameof(DOParameters.Ease)));
		}

		private void Draw(Rect rect, GUIContent label, SerializedProperty duration, SerializedProperty ease)
		{
			RectPair columns = rect.CutLeft(rect.height);
			columns.B.CutTop(EditorGUIUtility.singleLineHeight*rectLines.Length).A.SplitVertical(rectLines);

			EditorGUI.LabelField(rectLines[0], label);
			EditorGUI.PropertyField(rectLines[1], duration, GUIContent.none);
			EditorGUI.PropertyField(rectLines[2], ease, GUIContent.none);
			DrawPreview(columns.A, (Ease)ease.intValue);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label)*PREVIEW_LINES;
		}

		private static void DrawPreview(Rect rect, Ease ease)
		{
			rect = new Rect(rect.x, rect.y, rect.height, rect.height);
			int steps = (int)Mathf.Max(rect.width/DASH_LENGTH);
			GraphUtility.DrawGraph(rect, steps, false, (stepIndex, interpolated) => DOVirtual.EasedValue(0f, 1f, interpolated, ease), Color.red);
		}
	}
}
