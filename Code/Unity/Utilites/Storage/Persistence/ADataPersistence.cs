using System.Text;

namespace UnityPlugins.Common.Unity
{
	public abstract class ADataPersistence
	{
		public void WriteString(string path, string data)
		{
			WriteBytes(path, Encoding.UTF8.GetBytes(data));
		}
		
		public string ReadString(string path)
		{
			byte[] rawData = ReadBytes(path);
			return Encoding.UTF8.GetString(rawData);
		}

		public abstract bool Delete(string path);
		public abstract bool PathExists(string path);
		public abstract void EnsureDirectory(string directoryPath);
		public abstract void WriteBytes(string path, byte[] bytes);
		public abstract byte[] ReadBytes(string path);
		public abstract void CreateCopy(string sourceFileName, string destinationFileName);
	}
}
