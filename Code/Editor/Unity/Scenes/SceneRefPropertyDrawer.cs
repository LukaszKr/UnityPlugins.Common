using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	[CustomPropertyDrawer(typeof(SceneRef))]
	public class SceneRefPropertyDrawer : AExtendedPropertyDrawer
	{
		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			Draw(position, label, 
				property.FindPropertyRelative(nameof(SceneRef.Name)),
				property.FindPropertyRelative(nameof(SceneRef.Guid))
			);
		}

		private void Draw(Rect position, GUIContent label, SerializedProperty sceneName, SerializedProperty assetGuid)
		{
			SceneAsset scene = null;
			string guid = assetGuid.stringValue;
			if(!string.IsNullOrEmpty(guid))
			{
				string path = AssetDatabase.GUIDToAssetPath(assetGuid.stringValue);
				if(!string.IsNullOrEmpty(path))
				{
					scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(path);
				}
			}

			SceneAsset newScene = (SceneAsset)EditorGUI.ObjectField(position, label, scene, typeof(SceneAsset), false);
			if(newScene != null)
			{
				sceneName.stringValue = newScene.name;
				string assetPath = AssetDatabase.GetAssetPath(newScene);
				assetGuid.stringValue = AssetDatabase.GUIDFromAssetPath(assetPath).ToString();
			}
			else
			{
				sceneName.stringValue = string.Empty;
				assetGuid.stringValue = string.Empty;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label);
		}
	}
}
