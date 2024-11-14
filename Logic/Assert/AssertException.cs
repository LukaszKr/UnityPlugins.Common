using System;

namespace UnityPlugins.Common.Logic
{
	public class AssertException : Exception
	{
		public AssertException(string message)
			: base(message)
		{
		}
	}
}
