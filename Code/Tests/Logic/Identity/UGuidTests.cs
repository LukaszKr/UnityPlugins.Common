using UnityPlugins.Common.Tests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Identity
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class UGuidTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<UGuid<int>>
		{
			public EqualsTest(bool areEqual, UGuid<int> a, UGuid<int> b)
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
			new EqualsTest(true, new UGuid<int>("0f22ef3a-a5e3-472e-9725-efdbf0d9d03b"),
				new UGuid<int>("0f22ef3a-a5e3-472e-9725-efdbf0d9d03b")),
			new EqualsTest(false, new UGuid<int>("0f22ef3a-a5e3-472e-9725-efdbf0d9d03b"),
				new UGuid<int>("d2037916-1d1f-4888-857f-7042778d9e67")),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region Serialization
		[Test]
		public void Serialization_Binary()
		{
			UGuid<int> expected = UGuid<int>.Create();
			FastBinaryWriter writer = new FastBinaryWriter(64);
			expected.WriteToByteArray(writer);
			UGuid<int> actual = new UGuid<int>(writer.Buffer.ToBinaryReader());

			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void Serialization_Json()
		{
			UGuid<int> expected = UGuid<int>.Create();
			string json = JsonConvert.SerializeObject(expected);
			UGuid<int> actual = JsonConvert.DeserializeObject<UGuid<int>>(json);

			Assert.AreEqual(expected, actual);
		}
		#endregion
	}
}
