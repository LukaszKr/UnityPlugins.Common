using System;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Storage
{
	public abstract class APersistentStorage<TData>
		where TData : class
	{
		private readonly UnityPath m_Path;
		private readonly bool m_UseBackup;

		protected APersistentStorage(UnityPath path, bool useBackup)
		{
			m_Path = path;
			m_UseBackup = useBackup;
		}

		public void Delete()
		{

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
			string filePath = (backup? m_Path.Append(StorageConsts.BackupSufix): m_Path).ToString();
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

			string filePath = m_Path.ToString();
			m_Path.EnsureFolder();

			if(m_UseBackup)
			{
				CreateCopy(StorageConsts.BackupSufix);
			}

			byte[] saveData = OnFlush(data);
			DataPersistence.Instance.WriteBytes(filePath, saveData);
		}

		protected abstract TData OnLoad(TData current, byte[] saveData);
		protected abstract byte[] OnFlush(TData data);

		public void CreateCopy(string sufix)
		{
			if(StorageConsts.InMemory)
			{
				return;
			}

			string filePath = m_Path.ToString();
			string copyFilePath = m_Path.Append(sufix).ToString();
			byte[] data = DataPersistence.Instance.ReadBytes(filePath);
			if(data != null)
			{
				DataPersistence.Instance.WriteBytes(copyFilePath, data);
			}
		}
	}
}
