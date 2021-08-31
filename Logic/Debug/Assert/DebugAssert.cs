using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public static partial class DebugAssert
	{
		private const float APPROX = 0.00001f;

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void IsTrue(bool condition, string message = "")
		{
			Assert.IsTrue(condition, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void IsFalse(bool condition, string message = "")
		{
			Assert.IsFalse(condition, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void IsNull<T>(T obj, string message = "")
			where T : class
		{
			Assert.IsNull(obj, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void IsNotNull<T>(T obj, string message = "")
			where T : class
		{
			Assert.IsNotNull(obj, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreEqual<T>(T expected, T actual, string message = "")
		{
			Assert.AreEqual(expected, actual, null, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreNotEqual<T>(T expected, T actual, string message = "")
		{
			Assert.AreNotEqual(expected, actual, null, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			Assert.AreEqual(expected, actual, comparer, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = "")
		{
			Assert.AreNotEqual(expected, actual, comparer, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreApproximatelyEqual(float expected, float actual, string message = "")
		{
			Assert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreNotApproximatelyEqual(float expected, float actual, string message = "")
		{
			Assert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			Assert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = "")
		{
			Assert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}
	}
}
