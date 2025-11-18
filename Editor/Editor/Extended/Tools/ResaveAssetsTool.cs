using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class ResaveAssetsTool
	{
		[MenuItem("Assets/Resave Selected Assets", priority = 1100)]
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
				target.SaveAsset();
			}
			AssetDatabase.StopAssetEditing();
		}
	}
}
