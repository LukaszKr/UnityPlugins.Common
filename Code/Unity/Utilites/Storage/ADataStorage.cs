using System;
using System.IO;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public abstract class ADataStorage<TData>
		where TData : class
	{
		public static string BackupSufix = "_backup";

		private readonly ADataPersistence m_Persistence;

		public readonly bool UseBackup;
		public readonly string FilePath;
		public readonly string BackupPath;

		protected ADataStorage(ADataPersistence persistence, string filePath, bool useBackup)
		{
			m_Persistence = persistence;
			UseBackup = useBackup;

			FilePath = filePath;
			string extension = Path.GetExtension(FilePath);
			string rawPath = Path.GetFileNameWithoutExtension(FilePath);
			BackupPath = $"{rawPath}{BackupSufix}{extension}";
		}

		public void Delete(bool deleteBackup = true)
		{
			m_Persistence.Delete(FilePath);

			if(UseBackup && deleteBackup)
			{
				m_Persistence.Delete(BackupPath);
			}
		}

		public TData Load(TData current)
		{
			TData loaded = TryLoadPersistent(current, FilePath);
			if(loaded == null && UseBackup)
			{
				loaded = TryLoadPersistent(current, BackupPath);
			}
			if(loaded != null)
			{
				return loaded;
			}
			return current;
		}

		private TData TryLoadPersistent(TData current, string filePath)
		{
			try
			{
				byte[] rawData = m_Persistence.TryReadBytes(filePath);
				if(rawData != null && rawData.Length > 0)
				{
					return FromBytes(current, rawData);
				}
				return null;
			}
			catch(Exception e)
			{
				Debug.LogException(e);
			}
			return null;
		}

		public void Save(TData data)
		{
			m_Persistence.EnsureDirectory(FilePath);

			if(UseBackup && m_Persistence.PathExists(FilePath))
			{
				m_Persistence.CreateCopy(FilePath, BackupPath);
			}

			byte[] saveData = ToBytes(data);
			m_Persistence.WriteBytes(FilePath, saveData);
		}

		protected abstract TData FromBytes(TData current, byte[] saveData);
		protected abstract byte[] ToBytes(TData data);
	}
}
