using System;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public abstract class ALogHandler
	{
		public abstract void Log(ELogLevel level, string message);
		public abstract void Log(Exception e);
	}
}
