using UnityEditor;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	public static class FolderRefEditorExt
	{
		public static string GetPath(this FolderRef folder)
		{
			return AssetDatabase.GetAssetPath(folder.Value);
		}
	}
}
