using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityPlugins.Common.Logic
{
	public static partial class DebugAssert
	{
		public const string CONDITIONAL = "UNITY_EDITOR";

		private const float APPROX = 0.00001f;

		#region Comparable
		public static void IsLarger<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			GameAssert.IsLarger(a, b, message);
		}

		public static void IsLargerEqual<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			GameAssert.IsLargerEqual(a, b, message);
		}

		public static void IsSmaller<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			GameAssert.IsSmaller(a, b, message);
		}

		public static void IsSmallerEqual<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			GameAssert.IsSmallerEqual(a, b, message);
		}
		#endregion

		#region IsTrue
		[Conditional(CONDITIONAL)]
		public static void IsTrue(bool condition, string message = default)
		{
			GameAssert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0>(bool condition, string message, Arg0 arg0)
		{
			GameAssert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0, Arg1>(bool condition, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0, Arg1, Arg2>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.IsTrue(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsTrue<Arg0, Arg1, Arg2, Arg3>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.IsTrue(condition, message);
		}

		#endregion

		#region IsFalse
		[Conditional(CONDITIONAL)]
		public static void IsFalse(bool condition, string message = default)
		{
			GameAssert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0>(bool condition, string message, Arg0 arg0)
		{
			GameAssert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0, Arg1>(bool condition, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0, Arg1, Arg2>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.IsFalse(condition, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsFalse<Arg0, Arg1, Arg2, Arg3>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.IsFalse(condition, message);
		}

		#endregion

		#region IsNull
		[Conditional(CONDITIONAL)]
		public static void IsNull<T>(T obj, string message = default)
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0>(T obj, string message, Arg0 arg0)
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0, Arg1>(T obj, string message, Arg0 arg0, Arg1 arg1)
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0, Arg1, Arg2>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNull<T, Arg0, Arg1, Arg2, Arg3>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
			where T : class
		{
			GameAssert.IsNull(obj, message);
		}

		#endregion

		#region IsNotNull
		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T>(T obj, string message = default)
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0>(T obj, string message, Arg0 arg0)
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0, Arg1>(T obj, string message, Arg0 arg0, Arg1 arg1)
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0, Arg1, Arg2>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		[Conditional(CONDITIONAL)]
		public static void IsNotNull<T, Arg0, Arg1, Arg2, Arg3>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
			where T : class
		{
			GameAssert.IsNotNull(obj, message);
		}

		#endregion

		#region AreEqual
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, string message = default)
		{
			GameAssert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0>(T expected, T actual, string message, Arg0 arg0)
		{
			GameAssert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = default)
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0)
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreEqual(expected, actual, comparer, message);
		}
		#endregion

		#region AreNotEqual
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, string message = default)
		{
			GameAssert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0>(T expected, T actual, string message, Arg0 arg0)
		{
			GameAssert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreNotEqual(expected, actual, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = default)
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0)
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}
		[Conditional(CONDITIONAL)]
		public static void AreNotEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreNotEqual(expected, actual, comparer, message);
		}
		#endregion

		#region AreApproximatelyEqual
		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, string message = default)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0>(float expected, float actual, string message, Arg0 arg0)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = default)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0>(float expected, float actual, float tolerance, string message, Arg0 arg0)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreApproximatelyEqual(expected, actual, tolerance, message);
		}

		#endregion

		#region AreNotApproximatelyEqual
		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, string message = default)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0>(float expected, float actual, string message, Arg0 arg0)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = default)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0>(float expected, float actual, float tolerance, string message, Arg0 arg0)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		[Conditional(CONDITIONAL)]
		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			GameAssert.AreNotApproximatelyEqual(expected, actual, tolerance, message);
		}

		#endregion
	}
}
