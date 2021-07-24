using System.IO;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public class DataPersistence
	{
		public static DataPersistence Instance = new DataPersistence();

		public virtual bool PathExists(string path)
		{
			return File.Exists(path);
		}

		public virtual void EnsureDirectory(string directoryPath)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
			if(!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
		}

		public virtual void WriteBytes(string path, byte[] data)
		{
			using(FileStream stream = File.Create(path))
			{
				stream.Write(data, 0, data.Length);
				stream.Flush(true);
			}
		}

		public virtual byte[] ReadBytes(string path)
		{
			if(File.Exists(path))
			{
				return File.ReadAllBytes(path);
			}
			return null;
		}
	}
}
