namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
{
	public abstract class ADataPersistence
	{
		public static ADataPersistence Instance = new FileDataPersistence();

		public static void SetInMemory()
		{
			Instance = new MemoryDataPersistence();
		}

		public abstract bool Delete(string path);
		public abstract bool PathExists(string path);
		public abstract void EnsureDirectory(string directoryPath);

		public abstract void WriteBytes(string path, byte[] data);
		public abstract byte[] ReadBytes(string path);

		public abstract string ToFolder(EUnityPathType pathType);
	}
}
