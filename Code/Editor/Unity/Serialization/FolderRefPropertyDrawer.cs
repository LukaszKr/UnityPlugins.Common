using System.IO;
using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	[CustomPropertyDrawer(typeof(FolderRef))]
	public class FolderRefPropertyDrawer : AExtendedPropertyDrawer
	{
		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			SerializedProperty valueProperty = property.FindPropertyRelative(nameof(FolderRef.Value));
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
