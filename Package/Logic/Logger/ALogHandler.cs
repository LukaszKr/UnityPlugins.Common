using System;

namespace ProceduralLevel.Common.Logic
{
	public abstract class ALogHandler
	{
		public abstract void Log(ELogType level, string message);
		public abstract void Log(Exception e);
	}
}
