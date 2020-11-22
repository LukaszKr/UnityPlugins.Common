using System.IO;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public struct UnityPath
	{
		public readonly EUnityPathType Type;
		public readonly string Path;
		public readonly string Ext;

		public UnityPath(EUnityPathType type, string path = default, string ext = default)
		{
			Type = type;
			Path = path;
			if(string.IsNullOrEmpty(ext))
			{
				if(string.IsNullOrEmpty(path))
				{
					Path = "";
				}
				else if(!path.EndsWith("/") && !path.EndsWith("\\"))
				{
					Path += "\\";
				}
				Ext = "";
			}
			else
			{
				if(ext[0] != '.')
				{
					Ext = "."+ext;
				}
				else
				{
					Ext = ext;
				}
			}
		}

		public void EnsureFolder()
		{
			string directoryPath = System.IO.Path.GetDirectoryName(ToString());

			DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
			if(!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
		}

		public UnityPath Append(string sufix)
		{
			return new UnityPath(Type, Path+sufix, Ext);
		}

		public UnityPath Append(string sufix, string ext)
		{
			return new UnityPath(Type, Path+sufix, ext);
		}

		public UnityPath Format(params string[] args)
		{
			return new UnityPath(Type, string.Format(Path, args), Ext);
		}

		public override string ToString()
		{
			string prefix = Type.ToFolder();

			if(string.IsNullOrEmpty(Ext))
			{
				return string.Format("{0}{1}", prefix, Path);
			}
			return string.Format("{0}{1}{2}", prefix, Path, Ext);
		}
	}
}
