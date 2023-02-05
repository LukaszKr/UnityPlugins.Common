using System;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
{
	public abstract class APersistentStorage<TData>
		where TData : class
	{
		private readonly UnityPath m_Path;
		private readonly bool m_UseBackup;

		private readonly string m_FilePath;
		private readonly string m_BackupFilePath;

		protected APersistentStorage(UnityPath path, bool useBackup)
		{
			m_Path = path;
			m_UseBackup = useBackup;

			m_FilePath = m_Path.ToString();
			m_BackupFilePath = m_Path.Append(StorageConsts.BackupSufix).ToString();
		}

		public void Delete(bool deleteBackup = true)
		{
			if(StorageConsts.InMemory)
			{
				return;
			}

			DataPersistence.Instance.Delete(m_FilePath);

			if(m_UseBackup && deleteBackup)
			{
				DataPersistence.Instance.Delete(m_BackupFilePath);
			}
		}

		public TData Load(TData current)
		{
			if(StorageConsts.InMemory)
			{
				return current;
			}

			TData loaded = TryLoadPersistent(current, false);
			if(loaded == null && m_UseBackup)
			{
				return TryLoadPersistent(current, true);
			}
			return loaded;
		}

		private TData TryLoadPersistent(TData current, bool backup)
		{
			string filePath = (backup? m_BackupFilePath: m_FilePath);
			try
			{
				byte[] rawData = DataPersistence.Instance.ReadBytes(filePath);
				if(rawData != null && rawData.Length > 0)
				{
					return OnLoad(current, rawData);
				}
				return null;
			}
			catch(Exception e)
			{
				Debug.LogError(string.Format("Exception while loading '{0}'.", filePath));
				Debug.LogException(e);
			}
			return null;
		}

		public void Save(TData data)
		{
			if(StorageConsts.InMemory)
			{
				return;
			}

			m_Path.EnsureFolder();

			if(m_UseBackup)
			{
				CreateCopy(StorageConsts.BackupSufix);
			}

			byte[] saveData = OnFlush(data);
			DataPersistence.Instance.WriteBytes(m_FilePath, saveData);
		}

		protected abstract TData OnLoad(TData current, byte[] saveData);
		protected abstract byte[] OnFlush(TData data);

		public void CreateCopy(string sufix)
		{
			if(StorageConsts.InMemory)
			{
				return;
			}

			byte[] data = DataPersistence.Instance.ReadBytes(m_FilePath);
			if(data != null)
			{
				DataPersistence.Instance.WriteBytes(m_BackupFilePath, data);
			}
		}
	}
}
