﻿using System.IO;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
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
	}
}