using System;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class AssertException : Exception
	{
		public AssertException(string message)
			: base(message)
		{
		}
	}
}
