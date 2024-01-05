using System;

namespace ProceduralLevel.Common.Logic
{
	public class AssertException : Exception
	{
		public AssertException(string message)
			: base(message)
		{
		}
	}
}
