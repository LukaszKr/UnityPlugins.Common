using System.IO;
#if UNITY_SWITCH
using nn;
using nn.fs;
#endif

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public struct UnityPath
	{
		public readonly EUnityPathType Type;
		public readonly string Path;

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
			bool fileHandled = false;
			string directoryPath = System.IO.Path.GetDirectoryName(ToString());

#if UNITY_SWITCH
			if(!TargetConsts.IsEditor)
			{
				fileHandled = true;
				if(!PathExists(directoryPath))
				{
					Result result = nn.fs.Directory.Create(directoryPath);
					result.abortUnlessSuccess();
				}
			}
#endif
			if(!fileHandled)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
				if(!directoryInfo.Exists)
				{
					directoryInfo.Create();
				}
			}
		}

		public bool Exists()
		{
			return PathExists(ToString());
		}

		private bool PathExists(string path)
		{
#if UNITY_SWITCH
			if(!TargetConsts.IsEditor)
			{
				EntryType entryType = EntryType.Directory;
				Result result = FileSystem.GetEntryType(ref entryType, path);
				return result.IsSuccess();
			}
#endif
			return System.IO.File.Exists(path);
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
