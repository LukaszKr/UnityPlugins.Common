using System;
#if UNITY_SWITCH
using nn.fs;
using nn;
using File = nn.fs.File;
#endif
using System.IO;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public abstract class APersistentStorage
	{
		private readonly UnityPath m_Path;
		private readonly bool m_UseBackup;

		protected APersistentStorage(UnityPath path, bool useBackup)
		{
			m_Path = path;
			m_UseBackup = useBackup;
		}

		public bool Load()
		{
			if(StorageConsts.InMemory)
			{
				return true;
			}
			else if(!TryLoadPersistent(false) && m_UseBackup)
			{
				return TryLoadPersistent(true);
			}
			return true;
		}

		private bool TryLoadPersistent(bool backup)
		{
			string filePath = (backup? m_Path.Append(StorageConsts.BackupSufix): m_Path).ToString();
			try
			{
				byte[] rawData = ReadBytes(filePath);
				OnLoad(rawData);
				return true;
			}
			catch(Exception e)
			{
				Debug.LogError(string.Format("Exception while loading '{0}'.", filePath));
				Debug.LogException(e);
			}
			return false;
		}

		public void Save()
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

			byte[] saveData = OnFlush();
			WriteBytes(filePath, saveData);
		}

		protected abstract void OnLoad(byte[] saveData);
		protected abstract byte[] OnFlush();

		public void CreateCopy(string sufix)
		{
			if(StorageConsts.InMemory)
			{
				return;
			}

			string filePath = m_Path.ToString();
			string copyFilePath = m_Path.Append(sufix).ToString();
			byte[] data = ReadBytes(filePath);
			if(data != null)
			{
				WriteBytes(copyFilePath, data);
			}
		}

		public static void WriteBytes(string path, byte[] data)
		{
#if UNITY_SWITCH
			if(!TargetConsts.IsEditor)
			{
				// Nintendo Switch Guideline 0080
				UnityEngine.Switch.Notification.EnterExitRequestHandlingSection();

				Result result = File.Delete(path);
				if(!FileSystem.ResultPathNotFound.Includes(result))
				{
					result.abortUnlessSuccess();
				}

				result = File.Create(path, data.Length);
				result.abortUnlessSuccess();

				FileHandle fileHandle = new FileHandle();
				result = File.Open(ref fileHandle, path, OpenFileMode.Write);
				result.abortUnlessSuccess();

				result = File.Write(fileHandle, 0, data, data.Length, WriteOption.Flush);
				result.abortUnlessSuccess();

				result = File.Flush(fileHandle);
				result.abortUnlessSuccess();

				File.Close(fileHandle);
				result = FileSystem.Commit(StorageConsts.MountName);
				result.abortUnlessSuccess();

				// Nintendo Switch Guideline 0080
				UnityEngine.Switch.Notification.LeaveExitRequestHandlingSection();
				return;
			}
#else
			using(FileStream stream = File.Create(path))
			{
				stream.Write(data, 0, data.Length);
				stream.Flush(true);
			}
#endif
		}

		public static byte[] ReadBytes(string path)
		{
#if UNITY_SWITCH
			if(!TargetConsts.IsEditor)
			{
				EntryType entry = 0;
				Result result = FileSystem.GetEntryType(ref entry, path);
				if(result.IsSuccess() && entry == EntryType.File)
				{
					FileHandle fileHandle = new FileHandle();
					result = File.Open(ref fileHandle, path, OpenFileMode.Read);
					result.abortUnlessSuccess();

					long fileSize = 0;
					result = File.GetSize(ref fileSize, fileHandle);
					result.abortUnlessSuccess();

					byte[] data = new byte[fileSize];
					result = File.Read(fileHandle, 0, data, fileSize);
					result.abortUnlessSuccess();

					File.Close(fileHandle);
					return data;
				}
			}
#else
			if(File.Exists(path))
			{
				return File.ReadAllBytes(path);
			}
#endif
			return null;
		}
	}
}
