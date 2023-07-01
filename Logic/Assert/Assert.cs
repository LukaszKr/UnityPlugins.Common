namespace ProceduralLevel.Common.Logic
{
	public static class TestAssert
	{
		private const float APPROX = 0.00001f;

		#region IsTrue
		
		public static void IsTrue(bool condition, string message)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {message}]");
			}
		}
		
		public static void IsTrue<T0>(bool condition, string message, T0 arg0)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0)}]");
			}
		}
		
		public static void IsTrue<T0, T1>(bool condition, string message, T0 arg0, T1 arg1)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0, arg1)}]");
			}
		}
		
		public static void IsTrue<T0, T1, T2>(bool condition, string message, T0 arg0, T1 arg1, T2 arg2)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}
		
		#endregion

		#region IsFalse
		
		public static void IsFalse(bool condition, string message)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {message}]");
			}
		}
		
		public static void IsFalse<T0>(bool condition, string message, T0 arg0)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0)}]");
			}
		}
		
		public static void IsFalse<T0, T1>(bool condition, string message, T0 arg0, T1 arg1)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0, arg1)}]");
			}
		}
		
		public static void IsFalse<T0, T1, T2>(bool condition, string message, T0 arg0, T1 arg1, T2 arg2)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}
		
		#endregion
	}
}