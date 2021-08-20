using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public static partial class DebugAssert
	{
		private const float APPROX = 0.00001f;

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void IsTrue(bool condition, string message = "")
		{
			if(!condition)
			{
				throw new DebugAssertException($"[IsTrue, {message}]");
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void IsFalse(bool condition, string message = "")
		{
			if(condition)
			{
				throw new DebugAssertException($"[IsFalse, {message}]");
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void IsNull<T>(T obj, string message = "")
			where T : class
		{
			if(obj != null)
			{
				throw new DebugAssertException($"[IsNull, {typeof(T).Name}, {message}]");
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void IsNotNull<T>(T obj, string message = "")
			where T : class
		{
			if(obj == null)
			{
				throw new DebugAssertException($"[IsNotNull, {typeof(T).Name}, {message}]");
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, string message = "")
		{
			AreEqual(expected, actual, null, message);
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, string message = "")
		{
			AreNotEqual(expected, actual, null, message);
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			if(comparer == null)
			{
				if(!Equals(expected, actual))
				{
					throw new DebugAssertException($"[AreEqual, {expected} != {actual}, {message}]");
				}
			}
			else
			{
				if(!comparer.Equals(expected, actual))
				{
					throw new DebugAssertException($"[AreEqual, {expected} != {actual}, {message}]");
				}
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			if(comparer == null)
			{
				if(Equals(expected, actual))
				{
					throw new DebugAssertException($"[AreNotEqual, {expected} == {actual}, {message}]");
				}
			}
			else
			{
				if(comparer.Equals(expected, actual))
				{
					throw new DebugAssertException($"[AreNotEqual, {expected} == {actual}, {message}]");
				}
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, string message = "")
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, string message = "")
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new DebugAssertException($"[AreApproximatelyEqual, {message}]");
			}
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new DebugAssertException($"[AreNotApproximatelyEqual, {message}]");
			}
		}
	}
}
