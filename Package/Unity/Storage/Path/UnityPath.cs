using System;

namespace ProceduralLevel.Common.Unity.Storage
{
	[Serializable]
	public struct UnityPath
	{
		public EUnityPathType Type;
		public string Path;

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

		public void EnsureFolder()
		{
			string directoryPath = System.IO.Path.GetDirectoryName(ToString());
			ADataPersistence.Instance.EnsureDirectory(directoryPath);
		}

		public bool Exists()
		{
			return ADataPersistence.Instance.PathExists(ToString());
		}

		public UnityPath Append(string sufix)
		{
			return new UnityPath(Type, Path+sufix);
		}

		public UnityPath Format(params string[] args)
		{
			return new UnityPath(Type, string.Format(Path, args));
		}

		public override string ToString()
		{
			string prefix = ADataPersistence.Instance.ToFolder(Type);
			return $"{prefix}{Path}";
		}
	}
}
