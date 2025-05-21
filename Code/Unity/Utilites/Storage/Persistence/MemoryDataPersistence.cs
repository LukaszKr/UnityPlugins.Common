using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Unity
{
	public class MemoryDataPersistence : ADataPersistence
	{
		private readonly Dictionary<string, byte[]> m_Storage = new Dictionary<string, byte[]>();

		public override bool MoveFile(string sourceFileName, string destinationFileName)
		{
			if(PathExists(sourceFileName))
			{
				m_Storage[destinationFileName] = m_Storage[sourceFileName];
				return true;
			}
			return false;
		}

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

		public override byte[] TryReadBytes(string path)
		{
			if(!m_Storage.ContainsKey(path))
			{
				return null;
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
	}
}
