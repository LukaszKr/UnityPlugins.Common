using NUnit.Framework;

namespace UnityPlugins.Common.Tests
{
	public abstract class ATransformTest<TSource, TExpected>
	{
		public readonly TSource Source;
		public readonly TExpected Expected;

		public ATransformTest(TSource source, TExpected expected)
		{
			Source = source;
			Expected = expected;
		}

		public void Run()
		{
			TExpected result = Transform(Source);
			Assert.AreEqual(Expected, result);
		}

		protected abstract TExpected Transform(TSource source);

		public override string ToString()
		{
			return $"{Source} -> {Expected}";
		}
	}
}
