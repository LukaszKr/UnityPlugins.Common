using System;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public abstract class ALogHandler
	{
		public abstract void Log(ELogLevel level, string message);
		public abstract void Log(Exception e);

		public void LogInfo(string message)
		{
			Log(ELogLevel.Info, message);
		}

		public void LogDebug(string message)
		{
			Log(ELogLevel.Debug, message);
		}

		public void LogWarning(string message)
		{
			Log(ELogLevel.Warning, message);
		}

		public void LogError(string message)
		{
			Log(ELogLevel.Error, message);
		}
	}
}
