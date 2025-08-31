using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityPlugins.Common.Unity
{
	public static class EditorAssetsUtility
	{
#if UNITY_EDITOR
		public static string GetSelectedFolderPath()
		{
			if(Selection.count == 0)
			{
				throw new NotSupportedException("No folder selected.");
			}

			string guid = Selection.assetGUIDs[0];
			string path = AssetDatabase.GUIDToAssetPath(guid);
			if(!AssetDatabase.IsValidFolder(path))
			{
				throw new NotSupportedException($"Selected path is not a folder: '{path}'");
			}

			return path;
		}
#endif
	}
}
