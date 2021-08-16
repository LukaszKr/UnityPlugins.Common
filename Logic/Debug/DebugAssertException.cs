using System;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class DebugAssertException : Exception
	{
		public DebugAssertException(string message)
			: base(message)
		{
		}
	}
}
