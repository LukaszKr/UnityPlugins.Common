using System;
using System.IO;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	[Serializable]
	public struct UnityPath : IEquatable<UnityPath>
	{
		public EUnityPathType Type;
		public string Path;

		public static bool operator ==(UnityPath l, UnityPath r) => l.Equals(r);
		public static bool operator !=(UnityPath l, UnityPath r) => !l.Equals(r);

		public static implicit operator string(UnityPath path) => path.ToString();

		public UnityPath(EUnityPathType type, string path)
		{
			Type = type;
			Path = path;
		}

		public string GetDirectory()
		{
			if(System.IO.Path.HasExtension(Path))
			{
				string directoryPath = System.IO.Path.GetDirectoryName(ToString());
				return directoryPath;
			}

			DirectoryInfo info = new DirectoryInfo(Path);
			return info.FullName;
		}

		public void EnsureDirectory(ADataPersistence persistence)
		{
			persistence.EnsureDirectory(ToString());
		}

		public bool Exists(ADataPersistence persistence)
		{
			return persistence.PathExists(ToString());
		}

		public UnityPath Append(string sufix)
		{
			return new UnityPath(Type, Path+sufix);
		}

		public override bool Equals(object obj)
		{
			if(obj is UnityPath other)
			{
				return Equals(other);
			}

			return false;
		}

		public bool Equals(UnityPath other)
		{
			return Type == other.Type && Path == other.Path;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Path);
		}

		private string GetBasePath()
		{
			switch(Type)
			{
				case EUnityPathType.Streaming:
					return Application.streamingAssetsPath+"/";
				case EUnityPathType.Persistent:
					return Application.persistentDataPath+"/";
				case EUnityPathType.Assets:
					return Application.dataPath+"/";
				case EUnityPathType.Absolute:
					return string.Empty;
				case EUnityPathType.Project:
					string dataPath = Application.dataPath;
					return dataPath.Substring(0, dataPath.Length-7)+"/"; //7 = "Assets/"
				default:
					throw new NotImplementedException(Type.ToString());
			}
		}

		public override string ToString()
		{
			string basePath = GetBasePath();
			return $"{basePath}{Path}";
		}
	}
}
