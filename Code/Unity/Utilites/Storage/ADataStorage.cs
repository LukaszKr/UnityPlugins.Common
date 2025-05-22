using System;
using System.IO;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public abstract class ADataStorage<TData>
		where TData : class
	{
		public static string BackupSufix = "_backup";
		public static string DeletedSufix = "_deleted";

		public readonly ADataPersistence Persistence;

		public readonly bool UseBackup;
		public readonly string FilePath;
		public readonly string BackupPath;
		public readonly string DeletedPath;

		protected ADataStorage(ADataPersistence persistence, string filePath, bool useBackup)
		{
			Persistence = persistence;
			UseBackup = useBackup;

			FilePath = filePath;
			string extension = Path.GetExtension(FilePath);
			string fileName = Path.GetFileNameWithoutExtension(FilePath);
			string directoryName = Path.GetDirectoryName(filePath);
			BackupPath = $"{directoryName}/{fileName}{BackupSufix}{extension}";
			DeletedPath = $"{directoryName}/{fileName}{DeletedSufix}{extension}";
		}

		public void Delete(bool deleteBackup = true, bool createRestoreBackup = true)
		{
			if(createRestoreBackup && Persistence.PathExists(FilePath))
			{
				Persistence.CreateCopy(FilePath, DeletedPath);
			}
			Persistence.Delete(FilePath);

			if(UseBackup && deleteBackup)
			{
				Persistence.Delete(BackupPath);
			}
		}

		public bool Exists()
		{
			return Persistence.PathExists(FilePath);
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
				byte[] rawData = Persistence.TryReadBytes(filePath);
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
			Persistence.EnsureDirectory(FilePath);

			if(UseBackup && Persistence.PathExists(FilePath))
			{
				Persistence.CreateCopy(FilePath, BackupPath);
			}

			byte[] saveData = ToBytes(data);
			Persistence.WriteBytes(FilePath, saveData);
		}

		protected abstract TData FromBytes(TData current, byte[] saveData);
		protected abstract byte[] ToBytes(TData data);
	}
}
