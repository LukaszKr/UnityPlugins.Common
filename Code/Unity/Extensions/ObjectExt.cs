using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Object = UnityEngine.Object;

namespace UnityPlugins.Common.Unity
{
	public static class ObjectExt
	{
#if UNITY_EDITOR
		public static string GetEditorGUID(this Object target)
		{
			if(target == null)
			{
				throw new NullReferenceException();
			}
			string path = AssetDatabase.GetAssetPath(target);
			return AssetDatabase.AssetPathToGUID(path);
		}
#endif
	}
}
