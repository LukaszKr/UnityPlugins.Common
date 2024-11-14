using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Tests
{
	public class EqualsTest<T>
		where T : IEquatable<T>
	{
		public readonly bool AreEqual;
		public readonly T A;
		public readonly T B;

		public EqualsTest(bool areEqual, T a, T b)
		{
			AreEqual = areEqual;
			A = a;
			B = b;
		}

		public virtual void Run()
		{
			Assert.AreEqual(AreEqual, A.Equals(B));

			object objA = A;
			object objB = B;
			Assert.AreEqual(AreEqual, objA.Equals(objB));
			Assert.AreEqual(AreEqual, A.GetHashCode() == B.GetHashCode());
		}

		public override string ToString()
		{
			string expression = (AreEqual? "is equal": "is not equal");
			return $"{A} {expression} {B}";
		}
	}
}
