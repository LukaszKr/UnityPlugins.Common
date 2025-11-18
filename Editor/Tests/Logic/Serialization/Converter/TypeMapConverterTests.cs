using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Serialization.Converter
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class TypeMapConverterTests
	{
		public class TestTypeMapConverter : ATypeMapConverter
		{
			public static TypeMap TypeMap;

			protected override TypeMap GetTypeMap()
			{
				return TypeMap;
			}
		}

		[JsonConverter(typeof(TestTypeMapConverter))]
		public class Container
		{
			public ABaseClass Instance;
		}

		[JsonConverter(typeof(TestTypeMapConverter))]
		public abstract class ABaseClass
		{
			public int BaseValue = 0;
		}

		public class TestClass : ABaseClass
		{
			public bool Flag = false;
		}

		[Test]
		public void SeriailizeAndDeserialize()
		{
			TypeMap map = new TypeMap();
			TestTypeMapConverter.TypeMap = map;
			map.Add("key1", typeof(Container));
			map.Add("key2", typeof(TestClass));

			Container container = new Container();
			TestClass expected = new TestClass()
			{
				BaseValue = 2,
				Flag = true
			};
			container.Instance = expected;
			string json = JsonConvert.SerializeObject(container, Formatting.Indented);
			Assert.IsFalse(string.IsNullOrEmpty(json));

			Container deserialized = JsonConvert.DeserializeObject<Container>(json);

			Assert.AreEqual(container.GetType(), deserialized.GetType());
			TestClass actual = deserialized.Instance as TestClass;

			Assert.AreEqual(expected.BaseValue, actual.BaseValue);
			Assert.AreEqual(expected.Flag, actual.Flag);
		}

		[Test, Description("If serialized file contains type id that is not registered, deserialization will fail.")]
		public void DeserializeUnmappedType()
		{
			TypeMap map = new TypeMap();
			TestTypeMapConverter.TypeMap = map;
			map.Add("key1", typeof(Container));
			map.Add("key2", typeof(TestClass));

			Container container = new Container();
			TestClass expected = new TestClass()
			{
				BaseValue = 2,
				Flag = true
			};
			container.Instance = expected;
			string json = JsonConvert.SerializeObject(container, Formatting.Indented);

			TestTypeMapConverter.TypeMap = new TypeMap();

			Assert.Throws<KeyNotFoundException>(() => JsonConvert.DeserializeObject<Container>(json));
		}
	}
}
