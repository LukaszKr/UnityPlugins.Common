using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Serialization.Binary.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class BinaryPayloadHeaderTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<BinaryPayloadHeader>
		{
			public EqualsTest(bool areEqual, BinaryPayloadHeader a, BinaryPayloadHeader b)
				: base(areEqual, a, b)
			{
			}

			public override void Run()
			{
				base.Run();

				Assert.AreEqual(AreEqual, A == B);
				Assert.AreEqual(!AreEqual, A != B);
			}
		}

		private static readonly EqualsTest[] m_EqualsTests = new EqualsTest[]
		{
			new EqualsTest(true, new BinaryPayloadHeader(1, 2), new BinaryPayloadHeader(1, 2)),
			new EqualsTest(false, new BinaryPayloadHeader(1, 2), new BinaryPayloadHeader(0, 2)),
			new EqualsTest(false, new BinaryPayloadHeader(1, 2), new BinaryPayloadHeader(1, 0)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
