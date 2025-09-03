﻿using System;
using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	public class CreateScriptableObjectDropdown<TAsset> : ACreateDropdown<TAsset>
		where TAsset : ScriptableObject
	{
		protected override void CreateSelected(Type assetType)
		{
			ScriptableObject so = ScriptableObject.CreateInstance(assetType);
			string path = EditorAssetsUtility.GetSelectedFolderPath();
			path = $"{path}/{assetType.Name}.asset";
			AssetDatabase.CreateAsset(so, path);
		}
	}
}
