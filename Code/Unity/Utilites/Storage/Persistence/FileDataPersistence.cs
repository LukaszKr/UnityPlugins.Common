using System;
using System.IO;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public class FileDataPersistence : ADataPersistence
	{
		public override bool Delete(string path)
		{
			if(PathExists(path))
			{
				File.Delete(path);
				return true;
			}
			return false;
		}

		public override bool PathExists(string path)
		{
			return File.Exists(path);
		}

		public override void EnsureDirectory(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			DirectoryInfo directoryInfo = fileInfo.Directory;
			if(!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
		}

		public override void WriteBytes(string path, byte[] data)
		{
			using(FileStream stream = File.Create(path))
			{
				stream.Write(data, 0, data.Length);
				stream.Flush(true);
			}
		}

		public override byte[] ReadBytes(string path)
		{
			if(!File.Exists(path))
			{
				throw new FileNotFoundException();
			}
			return File.ReadAllBytes(path);
		}

		public override string ToBasePath(EUnityPathType pathType)
		{
			switch(pathType)
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
					throw new NotImplementedException();
			}
		}
	}
}
