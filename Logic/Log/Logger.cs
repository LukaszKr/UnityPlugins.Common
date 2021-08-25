using System;
using System.Collections.Generic;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class Logger
	{
		public static readonly Logger Default = new Logger();
		private readonly List<ALogHandler> m_Handlers = new List<ALogHandler>();

		public void AddHandler(ALogHandler handler)
		{
			m_Handlers.Add(handler);
		}

		public void Log(ELogLevel level, string message)
		{
			int count = m_Handlers.Count;
			for(int x = 0; x < count; ++x)
			{
				ALogHandler handler = m_Handlers[x];
				handler.Log(level, message);
			}
		}

		public void Log(Exception e)
		{
			int count = m_Handlers.Count;
			for(int x = 0; x < count; ++x)
			{
				ALogHandler handler = m_Handlers[x];
				handler.Log(e);
			}
		}

		public void LogException(Exception e)
		{
			Log(e);
		}

		public void LogDebug(string message)
		{
			Log(ELogLevel.Debug, message);
		}

		public void LogInfo(string message)
		{
			Log(ELogLevel.Info, message);
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
