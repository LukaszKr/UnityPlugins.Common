using System;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public abstract class ALogHandler
	{
		public abstract void Log(ELogLevel level, string message);
		public abstract void Log(Exception e);
	}
}
