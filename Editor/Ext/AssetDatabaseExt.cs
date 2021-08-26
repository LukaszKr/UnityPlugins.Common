using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Exception = System.Exception;

namespace ProceduralLevel.UnityPlugins.Common.Editor
{
	public static class AssetDatabaseExt
	{
		public static bool PrintReflectionErrors = true;

		public delegate ObjectType GetterDelegate<ObjectType, BaseType>(BaseType obj) where ObjectType : Object where BaseType : Object;

		public static List<ComponentType> GetAllPrefabsOfType<ComponentType>() where ComponentType : Component
		{
			return GetAllOfType<ComponentType, GameObject>("Prefab", (prefab) => prefab.GetComponent<ComponentType>());
		}

		public static List<ScriptableType> GetAllScriptableObjectsOfType<ScriptableType>() where ScriptableType : ScriptableObject
		{
			return GetAllOfType<ScriptableType, ScriptableObject>("ScriptableObject", (obj) => obj as ScriptableType);
		}

		public static List<ObjectType> GetAllOfType<ObjectType, BaseType>(string searchType, GetterDelegate<ObjectType, BaseType> getter) where ObjectType : Object where BaseType : Object
		{
			string[] guids = AssetDatabase.FindAssets("t:"+searchType);
			List<ObjectType> objects = new List<ObjectType>();
			for(int x = 0; x < guids.Length; x++)
			{
				string guid = guids[x];
				string path = AssetDatabase.GUIDToAssetPath(guid);
				BaseType obj = AssetDatabase.LoadAssetAtPath<BaseType>(path);
				ObjectType item = getter(obj);
				if(item != null)
				{
					objects.Add(item);
				}

			}

			return objects;
		}

		public static string GetGUID(Object obj)
		{
			string path = AssetDatabase.GetAssetPath(obj);
			return AssetDatabase.AssetPathToGUID(path);
		}

		public static ObjectType LoadFromGUID<ObjectType>(string guid)
			where ObjectType : Object
		{
			string assetPath = AssetDatabase.GUIDToAssetPath(guid);
			return AssetDatabase.LoadAssetAtPath<ObjectType>(assetPath);
		}

		public static string[] GetAllLabels()
		{
			try
			{
				BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod;
				Dictionary<string, float> dicLabels = (Dictionary<string, float>)typeof(AssetDatabase).InvokeMember("GetAllLabels", flags, null, null, null);
				string[] labels = new string[dicLabels.Count];
				dicLabels.Keys.CopyTo(labels, 0);
				return labels;
			}
			catch(Exception e)
			{
				if(PrintReflectionErrors)
				{
					Debug.LogException(e);
				}
				return new string[0];
			}
		}
	}
}
