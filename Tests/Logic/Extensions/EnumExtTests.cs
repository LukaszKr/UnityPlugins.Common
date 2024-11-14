using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Ext
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EnumExtTests
	{
		public enum TestEnum
		{
			MaxValue = 4,
			Default = 0,
			MinValue = -4,
		}

		private EnumExt<TestEnum> m_Meta;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			m_Meta = new EnumExt<TestEnum>();
		}

		[Test, Description("Enum with smallest value.")]
		public void MinValue()
		{
			Assert.AreEqual((int)TestEnum.MinValue, m_Meta.MinValue);
		}

		[Test, Description("Enum with largest value.")]
		public void MaxValue()
		{
			Assert.AreEqual((int)TestEnum.MaxValue, m_Meta.MaxValue);
		}

		[Test, Description("Values array.")]
		public void Values()
		{
			Assert.AreEqual(3, m_Meta.Values.Length);
		}

		[Test, Description("Values are sorted in ascending order.")]
		public void Values_SortedInAscendingOrder()
		{
			Assert.AreEqual(m_Meta.Values, new TestEnum[] { TestEnum.MinValue, TestEnum.Default, TestEnum.MaxValue });
		}
	}
}
