using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class AssetsUtility
	{
		public static void Save(this Object target)
		{
			EditorUtility.SetDirty(target);
			AssetDatabase.SaveAssetIfDirty(target);
		}

		public static TAsset[] LoadAllOfType<TAsset>(params string[] searchInFolders)
			where TAsset : Object
		{
			string[] guids;
			string filter = $"t:{typeof(TAsset)}";
			if(searchInFolders != null)
			{
				guids = AssetDatabase.FindAssets(filter, searchInFolders);
			}
			else
			{
				guids = AssetDatabase.FindAssets(filter);
			}
			TAsset[] assets = new TAsset[guids.Length];
			for(int x = 0; x < guids.Length; ++x)
			{
				string path = AssetDatabase.GUIDToAssetPath(guids[x]);
				assets[x] = AssetDatabase.LoadAssetAtPath<TAsset>(path);
			}
			return assets;
		}

		public static TContainer CreateSubAssetIfNull<TContainer>(this ScriptableObject owner, TContainer current, string suffix)
			where TContainer : ScriptableObject
		{
			if(current == null)
			{
				current = ScriptableObject.CreateInstance<TContainer>();
				AssetDatabase.AddObjectToAsset(current, owner);
				EditorUtility.SetDirty(owner);
			}

			string expectedName = $"{owner.name}_{suffix}";
			if(current.name != expectedName)
			{
				current.name = expectedName;
				EditorUtility.SetDirty(owner);
			}
			return current;
		}
	}
}
