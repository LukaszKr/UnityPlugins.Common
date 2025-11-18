using System.Collections.Generic;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Ext
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class StringExtTests
	{
		[Test]
		public void JoinToString()
		{
			List<string> list = new List<string>()
			{
				"Hello",
				"World"
			};
			Assert.AreEqual("Hello, World", list.JoinToString());
		}
	}
}
