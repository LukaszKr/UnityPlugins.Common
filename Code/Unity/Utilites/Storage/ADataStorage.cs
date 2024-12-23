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
		public readonly string BackupFilePath;

		protected ADataStorage(ADataPersistence persistence, UnityPath path, bool useBackup)
		{
			m_Persistence = persistence;
			UseBackup = useBackup;

			FilePath = path.ToString(persistence);
			string extension = Path.GetExtension(FilePath);
			string rawPath = Path.GetFileNameWithoutExtension(FilePath);
			BackupFilePath = $"{rawPath}{BackupSufix}{extension}";
		}

		public void Delete(bool deleteBackup = true)
		{
			m_Persistence.Delete(FilePath);

			if(UseBackup && deleteBackup)
			{
				m_Persistence.Delete(BackupFilePath);
			}
		}

		public TData Load(TData current)
		{
			TData loaded = TryLoadPersistent(current, false);
			if(loaded == null && UseBackup)
			{
				return TryLoadPersistent(current, true);
			}
			return loaded;
		}

		private TData TryLoadPersistent(TData current, bool backup)
		{
			string filePath = (backup? BackupFilePath: FilePath);
			try
			{
				byte[] rawData = m_Persistence.ReadBytes(filePath);
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
				m_Persistence.Copy(FilePath, BackupFilePath);
			}

			byte[] saveData = ToBytes(data);
			m_Persistence.WriteBytes(FilePath, saveData);
		}

		protected abstract TData FromBytes(TData current, byte[] saveData);
		protected abstract byte[] ToBytes(TData data);
	}
}
