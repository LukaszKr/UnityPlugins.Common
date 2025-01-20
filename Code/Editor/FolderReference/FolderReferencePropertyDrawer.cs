using System.IO;
using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	[CustomPropertyDrawer(typeof(FolderReference))]
	public class FolderReferencePropertyDrawer : AExtendedPropertyDrawer
	{
		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			SerializedProperty valueProperty = property.FindPropertyRelative(nameof(FolderReference.Value));
			Object oldValue = valueProperty.objectReferenceValue;
			EditorGUI.PropertyField(position, valueProperty);
			Object newValue = valueProperty.objectReferenceValue;
			if(newValue != oldValue && newValue != null)
			{
				string path = AssetDatabase.GetAssetPath(newValue);
				if(!Directory.Exists(path))
				{
					valueProperty.objectReferenceValue = oldValue;
				}
			}
		}
	}
}
