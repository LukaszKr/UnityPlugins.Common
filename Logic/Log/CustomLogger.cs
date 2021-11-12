using System;
using System.Collections.Generic;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class CustomLogger
	{
		public static readonly CustomLogger Default = new CustomLogger();
		private readonly List<ALogHandler> m_Handlers = new List<ALogHandler>();

		public void AddHandler(ALogHandler handler)
		{
			m_Handlers.Add(handler);
		}

		public void Log(ELogType level, string message)
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
