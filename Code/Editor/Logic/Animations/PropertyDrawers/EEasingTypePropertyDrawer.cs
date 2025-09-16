using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Logic;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	[CustomPropertyDrawer(typeof(EEasingType))]
	internal class EEasingTypePropertyDrawer : AExtendedPropertyDrawer
	{
		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			EEasingType type = (EEasingType)property.enumValueIndex;
			RectPair pair = position.CutLeft(position.height);

			EasingEditorUtility.DrawPreview(pair.A, type);

			float lineHeight = EditorGUIUtility.singleLineHeight;

			pair = pair.B.CutTop(lineHeight);
			EditorGUI.LabelField(pair.A, label);

			pair = pair.B.CutTop(lineHeight);

			pair = pair.A.CutLeft(lineHeight);

			if(GUI.Button(pair.A, "<"))
			{
				int enumValue = property.enumValueIndex-1;
				if(enumValue < 0)
				{
					enumValue = property.enumNames.Length-1;
				}
				property.enumValueIndex = enumValue;
			}
			pair = pair.B.CutRight(lineHeight);
			EditorGUI.PropertyField(pair.A, property, GUIContent.none);
			if(GUI.Button(pair.B, ">"))
			{
				int enumValue = property.enumValueIndex+1;
				enumValue %= property.enumNames.Length;
				property.enumValueIndex = enumValue;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label)*3;
		}
	}
}
