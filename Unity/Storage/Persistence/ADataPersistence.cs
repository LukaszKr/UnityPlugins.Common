using System.Text;

namespace ProceduralLevel.Common.Unity.Storage
{
	public abstract class ADataPersistence
	{
		public static ADataPersistence Instance = new FileDataPersistence();

		public static void SetInMemory()
		{
			Instance = new MemoryDataPersistence();
		}

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

		public abstract void WriteBytes(string path, byte[] data);
		public abstract byte[] ReadBytes(string path);

		public abstract string ToFolder(EUnityPathType pathType);
	}
}
