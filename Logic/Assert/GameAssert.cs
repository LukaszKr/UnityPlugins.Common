using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public static partial class GameAssert
	{
		private const float APPROX = 0.00001f;

		#region IsTrue
		public static void IsTrue(bool condition, string message = default)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {message}]");
			}
		}

		public static void IsTrue<Arg0>(bool condition, string message, Arg0 arg0)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0)}]");
			}
		}

		public static void IsTrue<Arg0, Arg1>(bool condition, string message, Arg0 arg0, Arg1 arg1)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void IsTrue<Arg0, Arg1, Arg2>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void IsTrue<Arg0, Arg1, Arg2, Arg3>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(!condition)
			{
				throw new AssertException($"[IsTrue, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}
		#endregion

		#region IsFalse
		public static void IsFalse(bool condition, string message = default)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {message}]");
			}
		}

		public static void IsFalse<Arg0>(bool condition, string message, Arg0 arg0)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0)}]");
			}
		}

		public static void IsFalse<Arg0, Arg1>(bool condition, string message, Arg0 arg0, Arg1 arg1)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void IsFalse<Arg0, Arg1, Arg2>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void IsFalse<Arg0, Arg1, Arg2, Arg3>(bool condition, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(condition)
			{
				throw new AssertException($"[IsFalse, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion

		#region IsNull
		public static void IsNull<T>(T obj, string message = default)
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {message}]");
			}
		}

		public static void IsNull<T, Arg0>(T obj, string message, Arg0 arg0)
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {string.Format(message, arg0)}]");
			}
		}

		public static void IsNull<T, Arg0, Arg1>(T obj, string message, Arg0 arg0, Arg1 arg1)
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void IsNull<T, Arg0, Arg1, Arg2>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void IsNull<T, Arg0, Arg1, Arg2, Arg3>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
			where T : class
		{
			if(obj != null)
			{
				throw new AssertException($"[IsNull, {typeof(T).Name}, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion

		#region IsNotNull
		public static void IsNotNull<T>(T obj, string message = default)
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {message}]");
			}
		}

		public static void IsNotNull<T, Arg0>(T obj, string message, Arg0 arg0)
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {string.Format(message, arg0)}]");
			}
		}

		public static void IsNotNull<T, Arg0, Arg1>(T obj, string message, Arg0 arg0, Arg1 arg1)
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void IsNotNull<T, Arg0, Arg1, Arg2>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void IsNotNull<T, Arg0, Arg1, Arg2, Arg3>(T obj, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
			where T : class
		{
			if(obj == null)
			{
				throw new AssertException($"[IsNotNull, {typeof(T).Name}, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion

		#region Comparable
		public static void IsLarger<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			if(a.CompareTo(b) <= 0)
			{
				throw new AssertException($"[IsLarger, {typeof(T).Name}, {a} > {b}, {message}]");
			}
		}

		public static void IsLargerEqual<T>(T a, T b, string message = default)
				where T : IComparable<T>
		{
			if(a.CompareTo(b) < 0)
			{
				throw new AssertException($"[IsLargerEqual, {typeof(T).Name}, {a} >= {b}, {message}]");
			}
		}

		public static void IsSmaller<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			if(a.CompareTo(b) >= 0)
			{
				throw new AssertException($"[IsSmaller, {typeof(T).Name}, {a} < {b}, {message}]");
			}
		}

		public static void IsSmallerEqual<T>(T a, T b, string message = default)
			where T : IComparable<T>
		{
			if(a.CompareTo(b) > 0)
			{
				throw new AssertException($"[IsSmallerEqual, {typeof(T).Name}, {a} <= {b}, {message}]");
			}
		}
		#endregion

		#region AreEqual
		public static void AreEqual<T>(T expected, T actual, string message = default)
		{
			if(!Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {message}]");
			}
		}

		public static void AreEqual<T, Arg0>(T expected, T actual, string message, Arg0 arg0)
		{
			if(!Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0)}]");
			}
		}

		public static void AreEqual<T, Arg0, Arg1>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1)
		{
			if(!Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void AreEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(!Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void AreEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(!Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		public static void AreEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = default)
		{
			if(!comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {message}]");
			}
		}

		public static void AreEqual<T, Arg0>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0)
		{
			if(!comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0)}]");
			}
		}

		public static void AreEqual<T, Arg0, Arg1>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1)
		{
			if(!comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void AreEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(!comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void AreEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(!comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreEqual, {expected} != {actual}, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion

		#region AreNotEqual
		public static void AreNotEqual<T>(T expected, T actual, IEqualityComparer<T> comparer, string message = default)
		{
			if(comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {message}]");
			}
		}

		public static void AreNotEqual<T, Arg0>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0)
		{
			if(comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0)}]");
			}
		}

		public static void AreNotEqual<T, Arg0, Arg1>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1)
		{
			if(comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void AreNotEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void AreNotEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, IEqualityComparer<T> comparer, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(comparer.Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		public static void AreNotEqual<T>(T expected, T actual, string message = default)
		{
			if(Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {message}]");
			}
		}

		public static void AreNotEqual<T, Arg0>(T expected, T actual, string message, Arg0 arg0)
		{
			if(Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0)}]");
			}
		}

		public static void AreNotEqual<T, Arg0, Arg1>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1)
		{
			if(Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void AreNotEqual<T, Arg0, Arg1, Arg2>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void AreNotEqual<T, Arg0, Arg1, Arg2, Arg3>(T expected, T actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(Equals(expected, actual))
			{
				throw new AssertException($"[AreNotEqual, {expected} == {actual}, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion

		#region AreApproximatelyEqual
		public static void AreApproximatelyEqual(float expected, float actual, string message = default)
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual<Arg0>(float expected, float actual, string message, Arg0 arg0)
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual<Arg0, Arg1>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1)
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			AreApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreApproximatelyEqual(float expected, float actual, float tolerance, string message = default)
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {message}]");
			}
		}

		public static void AreApproximatelyEqual<Arg0>(float expected, float actual, float tolerance, string message, Arg0 arg0)
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {string.Format(message, arg0)}]");
			}
		}

		public static void AreApproximatelyEqual<Arg0, Arg1>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1)
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void AreApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(Math.Abs(expected-actual) > tolerance)
			{
				throw new AssertException($"[AreApproximatelyEqual, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion

		#region AreNotApproximatelyEqual
		public static void AreNotApproximatelyEqual(float expected, float actual, string message = default)
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual<Arg0>(float expected, float actual, string message, Arg0 arg0)
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual<Arg0, Arg1>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1)
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			AreNotApproximatelyEqual(expected, actual, APPROX, message);
		}

		public static void AreNotApproximatelyEqual(float expected, float actual, float tolerance, string message = default)
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {message}]");
			}
		}

		public static void AreNotApproximatelyEqual<Arg0>(float expected, float actual, float tolerance, string message, Arg0 arg0)
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {string.Format(message, arg0)}]");
			}
		}

		public static void AreNotApproximatelyEqual<Arg0, Arg1>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1)
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {string.Format(message, arg0, arg1)}]");
			}
		}

		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2)
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {string.Format(message, arg0, arg1, arg2)}]");
			}
		}

		public static void AreNotApproximatelyEqual<Arg0, Arg1, Arg2, Arg3>(float expected, float actual, float tolerance, string message, Arg0 arg0, Arg1 arg1, Arg2 arg2, Arg3 arg3)
		{
			if(Math.Abs(expected-actual) <= tolerance)
			{
				throw new AssertException($"[AreNotApproximatelyEqual, {string.Format(message, arg0, arg1, arg2, arg3)}]");
			}
		}

		#endregion
	}
}
