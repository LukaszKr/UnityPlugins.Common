using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public static partial class DebugAssert
	{
		public const string CONDITIONAL = "UNITY_EDITOR";

		private const float APPROX = 0.00001f;

		[Conditional(CONDITIONAL)]
		public static void IsTrue(bool condition, string message = "")
		{
			GameAssert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse(bool condition, string message = "")
		{
			GameAssert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T>(T obj, string message = "")
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T>(T obj, string message = "")
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, string message = "")
		{
			GameAssert.AreEqual(expected, actual, null, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, string message = "")
		{
			GameAssert.AreNotEqual(expected, actual, null, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, string message = "")
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, string message = "")
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}
	}
}
