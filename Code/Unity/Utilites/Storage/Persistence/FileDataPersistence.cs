using System.IO;

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

		public override bool MoveFile(string sourceFileName, string destinationFileName)
		{
			if(PathExists(sourceFileName))
			{
				File.Move(sourceFileName, destinationFileName);
				return PathExists(destinationFileName);
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

		public override byte[] TryReadBytes(string path)
		{
			if(!PathExists(path))
			{
				return null;
			}
			return File.ReadAllBytes(path);
		}

		public override void CreateCopy(string sourceFileName, string destinationFileName)
		{
			File.Copy(sourceFileName, destinationFileName, true);
		}
	}
}
