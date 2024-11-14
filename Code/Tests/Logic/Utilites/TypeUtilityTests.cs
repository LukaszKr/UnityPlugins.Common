using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Utilities
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class TypeUtilityTests
	{
		[Test]
		public void IsString_Type_Primitive_False()
		{
			Assert.IsFalse(TypeUtility.IsString(typeof(int)));
		}

		[Test]
		public void IsString_Type_StringArray_False()
		{
			Assert.IsFalse(TypeUtility.IsString(typeof(string[])));
		}

		[Test]
		public void IsString_Type_String_True()
		{
			Assert.IsTrue(TypeUtility.IsString(typeof(string)));
		}

		[Test]
		public void IsString_Value_Null_False()
		{
			object obj = null;
			Assert.IsFalse(obj.IsString());
		}

		[Test]
		public void IsString_Value_Primitive_False()
		{
			int value = 1;
			Assert.IsFalse(value.IsString());
		}

		[Test]
		public void IsString_Value_String_Null_False()
		{
			string str = null;
			Assert.IsFalse(str.IsString());
		}

		[Test]
		public void IsString_Value_String_Empty_True()
		{
			string str = "";
			Assert.IsTrue(str.IsString());
		}

		[Test]
		public void IsString_Value_String_True()
		{
			string str = "Hello World";
			Assert.IsTrue(str.IsString());
		}
	}
}
