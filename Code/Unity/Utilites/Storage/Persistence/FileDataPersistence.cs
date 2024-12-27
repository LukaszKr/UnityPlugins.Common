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

		public override void WriteBytes(string path, byte[] bytes)
		{
			EnsureDirectory(path);
			using(FileStream stream = File.Create(path))
			{
				stream.Write(bytes, 0, bytes.Length);
				stream.Flush(true);
			}
		}

		public override byte[] ReadBytes(string path)
		{
			if(!PathExists(path))
			{
				throw new FileNotFoundException(path);
			}
			return File.ReadAllBytes(path);
		}

		public override void CreateCopy(string sourceFileName, string destinationFileName)
		{
			File.Copy(sourceFileName, destinationFileName);
		}
	}
}
