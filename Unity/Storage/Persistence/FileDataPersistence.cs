using System;
using System.IO;
using UnityEngine;

namespace ProceduralLevel.Common.Unity.Storage
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

		public override void EnsureDirectory(string directoryPath)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
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
			if(File.Exists(path))
			{
				return File.ReadAllBytes(path);
			}
			return null;
		}

		public override string ToFolder(EUnityPathType pathType)
		{
			switch(pathType)
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
