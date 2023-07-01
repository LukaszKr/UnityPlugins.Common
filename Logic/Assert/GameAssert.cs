using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Logic
{
	public static partial class GameAssert
	{
		private const float APPROX = 0.00001f;

		public static void IsTrue(bool condition, FormattableString message = null)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {message}]");
			}
		}

		public static void IsFalse(bool condition, FormattableString message = null)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {message}]");
			}
		}

		public static void IsNull<T>(T obj, FormattableString message = null)
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {message}]");
			}
		}

		public static void IsNotNull<T>(T obj, FormattableString message = null)
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {message}]");
			}
		}

		public static void AreEqual<T>(T expected, T actual, FormattableString message = null)
		{
			AreEqual(expected, actual, null, message);
		}

		public static void AreNotEqual<T>(T expected, T actual, FormattableString message = null)
		{
			AreNotEqual(expected, actual, null, message);
		}

		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, FormattableString message = null)
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

		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, FormattableString message = null)
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

		public static void AreApproximatelyEqual(float expected, float actual, FormattableString message = null)
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, FormattableString message = null)
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, FormattableString message = null)
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {message}]");
			}
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, FormattableString message = null)
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {message}]");
			}
		}
	}
}
