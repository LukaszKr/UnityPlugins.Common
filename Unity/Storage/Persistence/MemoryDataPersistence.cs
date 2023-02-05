using System.Collections.Generic;
using System.IO;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
{
	public class MemoryDataPersistence : ADataPersistence
	{
		private readonly Dictionary<string, byte[]> m_Storage = new Dictionary<string, byte[]>();

		public override bool Delete(string path)
		{
			return m_Storage.Remove(path);
		}

		public override bool PathExists(string path)
		{
			return m_Storage.ContainsKey(path);
		}

		public override void EnsureDirectory(string directoryPath)
		{
			//Do nothing
		}

		public override void WriteBytes(string path, byte[] data)
		{
			m_Storage[path] = data;
		}

		public override byte[] ReadBytes(string path)
		{
			if(!m_Storage.ContainsKey(path))
			{
				throw new FileNotFoundException();
			}
			return m_Storage[path];
		}
	}
}
