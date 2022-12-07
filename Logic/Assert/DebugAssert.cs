using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public static partial class DebugAssert
	{
		public const string CONDITIONAL = "UNITY_EDITOR";

		private const float APPROX = 0.00001f;

		[Conditional(CONDITIONAL)]
		public static void IsTrue(bool condition, FormattableString message = null)
		{
			GameAssert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse(bool condition, FormattableString message = null)
		{
			GameAssert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T>(T obj, FormattableString message = null)
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T>(T obj, FormattableString message = null)
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, FormattableString message = null)
		{
			GameAssert.AreEqual(expected, actual, null, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, FormattableString message = null)
		{
			GameAssert.AreNotEqual(expected, actual, null, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, FormattableString message = null)
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, FormattableString message = null)
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, FormattableString message = null)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, FormattableString message = null)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, FormattableString message = null)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, FormattableString message = null)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}
	}
}
