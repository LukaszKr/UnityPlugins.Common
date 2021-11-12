using System;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public abstract class ALogHandler
	{
		public abstract void Log(ELogType level, string message);
		public abstract void Log(Exception e);

		public void LogInfo(string message)
		{
			Log(ELogType.Info, message);
		}

		public void LogWarning(string message)
		{
			Log(ELogType.Warning, message);
		}

		public void LogError(string message)
		{
			Log(ELogType.Error, message);
		}
	}
}
