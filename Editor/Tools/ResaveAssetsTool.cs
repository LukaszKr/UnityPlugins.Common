using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Editor
{
	public static class ResaveAssetsTool
	{
		[MenuItem("Assets/Resave")]
		private static void ResaveSelected()
		{
			Object[] selectedObjects = Selection.GetFiltered<Object>(SelectionMode.DeepAssets);
			Resave(selectedObjects);
		}


		public static void Resave(params Object[] targets)
		{
			AssetDatabase.StartAssetEditing();
			foreach(Object target in targets)
			{
				EditorUtility.SetDirty(target);
				AssetDatabase.SaveAssetIfDirty(target);
			}
			AssetDatabase.StopAssetEditing();
		}
	}
}
