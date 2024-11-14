using UnityPlugins.Common.Tests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Identity
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class IDTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<ID<int>>
		{
			public EqualsTest(bool areEqual, ID<int> a, ID<int> b)
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
			new EqualsTest(true, new ID<int>(1), new ID<int>(1)),
			new EqualsTest(false, new ID<int>(1), new ID<int>(0)),
		};

		[Test]
		public void Equals([ValueSource(nameof(m_EqualsTests))] EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region Serialization
		[Test]
		public void Serialization_Binary()
		{
			ID<int> expected = new ID<int>(12345);
			FastBinaryWriter writer = new FastBinaryWriter(64);
			expected.WriteToByteArray(writer);
			ID<int> actual = new ID<int>(writer.Buffer.ToBinaryReader());

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Serialization_Json()
		{
			ID<int> expected = new ID<int>(12345);
			string json = JsonConvert.SerializeObject(expected);
			ID<int> actual = JsonConvert.DeserializeObject<ID<int>>(json);

			Assert.AreEqual(expected, actual);
		}
		#endregion
	}
}
