using System.IO;
using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	[CustomPropertyDrawer(typeof(FolderReferenceAttribute))]
	public class FolderReferenceAttributeDrawer : APropertyAttributeDrawer<FolderReferenceAttribute>
	{
		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			Object oldValue = property.objectReferenceValue;
			EditorGUI.PropertyField(position, property);
			Object newValue = property.objectReferenceValue;
			if(newValue != oldValue && newValue != null)
			{
				string path = AssetDatabase.GetAssetPath(newValue);
				if(!Directory.Exists(path))
				{
					property.objectReferenceValue = oldValue;
				}
			}
		}
	}
}
