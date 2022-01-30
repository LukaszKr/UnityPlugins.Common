using System;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
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
			DataPersistence.Instance.EnsureDirectory(directoryPath);
		}

		public bool Exists()
		{
			return DataPersistence.Instance.PathExists(ToString());
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
			string prefix = Type.ToFolder();
			if(!string.IsNullOrEmpty(prefix))
			{
				prefix = prefix+"\\";
			}
			return string.Format("{0}{1}", prefix, Path);
		}
	}
}
