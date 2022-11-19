using System;
using System.Collections.Generic;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public static partial class GameAssert
	{
		private const float APPROX = 0.00001f;

		public static void IsTrue(bool condition, string message = "")
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {message}]");
			}
		}

		public static void IsFalse(bool condition, string message = "")
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {message}]");
			}
		}

		public static void IsNull<T>(T obj, string message = "")
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {message}]");
			}
		}

		public static void IsNotNull<T>(T obj, string message = "")
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {message}]");
			}
		}

		public static void AreEqual<T>(T expected, T actual, string message = "")
		{
			AreEqual(expected, actual, null, message);
		}

		public static void AreNotEqual<T>(T expected, T actual, string message = "")
		{
			AreNotEqual(expected, actual, null, message);
		}

		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			if(comparer == null)
			{
				if(!Equals(expected, actual))
				{
					throw new AssertException($"[AreEqual, {expected} != {actual}, {message}]");
				}
			}
			else
			{
				if(!comparer.Equals(expected, actual))
				{
					throw new AssertException($"[AreEqual, {expected} != {actual}, {message}]");
				}
			}
		}

		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			if(comparer == null)
			{
				if(Equals(expected, actual))
				{
					throw new AssertException($"[AreNotEqual, {expected} == {actual}, {message}]");
				}
			}
			else
			{
				if(comparer.Equals(expected, actual))
				{
					throw new AssertException($"[AreNotEqual, {expected} == {actual}, {message}]");
				}
			}
		}

		public static void AreApproximatelyEqual(float expected, float actual, string message = "")
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, string message = "")
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {message}]");
			}
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {message}]");
			}
		}
	}
}
