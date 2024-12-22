using System;

namespace UnityPlugins.Common.Unity
{
	[Serializable]
	public struct UnityPath : IEquatable<UnityPath>
	{
		public EUnityPathType Type;
		public string Path;

		public static bool operator ==(UnityPath l, UnityPath r) => l.Equals(r);
		public static bool operator !=(UnityPath l, UnityPath r) => !l.Equals(r);

		public UnityPath(EUnityPathType type, string path)
		{
			Type = type;
			Path = path;

			string ext = System.IO.Path.GetExtension(path);
			if(string.IsNullOrEmpty(ext))
			{
				if(!path.EndsWith("/") && !path.EndsWith("\\"))
				{
					Path += "/";
				}
			}
		}

		public string GetDirectory()
		{
			string directoryPath = System.IO.Path.GetDirectoryName(ToString());
			return directoryPath;
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

		public override string ToString()
		{
			return Path;
		}

		public string ToString(ADataPersistence persistence)
		{
			string prefix = persistence.ToBasePath(Type);
			return $"{prefix}{Path}";
		}
	}
}
