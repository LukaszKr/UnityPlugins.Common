using System;
using System.Collections.Generic;
using System.IO;

namespace UnityPlugins.Common.Unity
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

		public override void WriteBytes(string path, byte[] bytes)
		{
			byte[] bytesCopy = new byte[bytes.Length];
			Array.Copy(bytes, bytesCopy, bytes.Length);
			m_Storage[path] = bytesCopy;
		}

		public override byte[] ReadBytes(string path)
		{
			if(!m_Storage.ContainsKey(path))
			{
				throw new FileNotFoundException(path);
			}
			return m_Storage[path];
		}

		public override void CreateCopy(string sourceFileName, string destinationFileName)
		{
			byte[] bytes = m_Storage[sourceFileName];
			byte[] copied = new byte[bytes.Length];
			Array.Copy(bytes, copied, bytes.Length);
			m_Storage[destinationFileName] = copied;
		}

		public override string ToBasePath(EUnityPathType pathType)
		{
			return $"{pathType}/";
		}
	}
}
