using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Editor
{
	public abstract class AExtendedPropertyDrawer : PropertyDrawer
	{
		protected virtual bool DrawDefault { get { return false; } }

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginChangeCheck();
			if(DrawDefault)
			{
				base.OnGUI(position, property, label);
			}
			Draw(position, property, label);
			if(EditorGUI.EndChangeCheck())
			{
				property.serializedObject.ApplyModifiedProperties();
				ChangesOccured();
			}
		}

		protected abstract void Draw(Rect position, SerializedProperty property, GUIContent label);

		protected virtual void ChangesOccured() { }
	}
}
