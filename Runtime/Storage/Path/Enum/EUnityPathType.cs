using System;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public enum EUnityPathType
	{
		Streaming = 0,
		Persistent = 1,
		Assets = 2,
		Absolute = 3,
		Project = 4
	}

	public static class EUnityPathTypeExt
	{
		public static string ToFolder(this EUnityPathType type)
		{
			switch(type)
			{
				case EUnityPathType.Streaming:
					return Application.streamingAssetsPath+"\\";
				case EUnityPathType.Persistent:
					return Application.persistentDataPath+"\\";
				case EUnityPathType.Assets:
					return Application.dataPath+"\\";
				case EUnityPathType.Absolute:
					return string.Empty;
				case EUnityPathType.Project:
					string dataPath = Application.dataPath;
					return dataPath.Substring(0, dataPath.Length-7)+"\\"; //7 = "Assets/"
				default:
					throw new NotImplementedException();
			}
		}
	}
}
