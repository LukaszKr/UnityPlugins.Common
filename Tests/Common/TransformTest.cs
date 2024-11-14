namespace UnityPlugins.Common.Tests
{
	public class TransformTest<TSource, TExpected> : ATransformTest<TSource, TExpected>
	{
		public readonly TransformCallback Callback;

		public delegate TExpected TransformCallback(TSource source);

		public TransformTest(TransformCallback callback, TSource source, TExpected expected)
			: base(source, expected)
		{
			Callback = callback;
		}

		protected override TExpected Transform(TSource source)
		{
			return Callback(Source);
		}

		public override string ToString()
		{
			return $"{Source} -> {Expected}";
		}
	}
}
