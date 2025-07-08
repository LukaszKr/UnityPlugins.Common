using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Serialization
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class TypeMapTests
	{
		[Test]
		public void Add()
		{
			string key = "key1";
			TypeMap map = new TypeMap();
			map.Add(typeof(int), key);

			Assert.IsTrue(map.Contains(typeof(int)));
			Assert.IsTrue(map.Contains(key));

			Assert.AreEqual(key, map.Get(typeof(int)));
			Assert.AreEqual(typeof(int), map.Get(key));
		}

		[Test]
		public void Add_Duplicate()
		{
			string key = "key";
			TypeMap map = new TypeMap();
			map.Add(typeof(int), key);

			Assert.Throws<ArgumentException>(() => map.Add(typeof(int), key));
		}

		[Test]
		public void Add_Duplicate_DifferentKey()
		{
			string key1 = "key1";
			string key2 = "key2";
			TypeMap map = new TypeMap();
			map.Add(typeof(int), key1);

			Assert.Throws<ArgumentException>(() => map.Add(typeof(int), key2));
		}

		[Test]
		public void Add_Duplicate_DifferentType()
		{
			string key = "key1";
			TypeMap map = new TypeMap();
			map.Add(typeof(int), key);

			Assert.Throws<ArgumentException>(() => map.Add(typeof(float), key));
		}

		[Test]
		public void TryAdd_Duplicate()
		{
			string key = "key1";
			TypeMap map = new TypeMap();
			Assert.IsTrue(map.TryAdd(typeof(int), key));
			Assert.IsFalse(map.TryAdd(typeof(int), key));
		}

		[Test]
		public void TryAdd_Duplicate_DifferentType()
		{
			string key = "key1";
			TypeMap map = new TypeMap();

			Assert.IsTrue(map.TryAdd(typeof(int), key));
			Assert.Throws<ArgumentException>(() => map.TryAdd(typeof(float), key));
		}

		[Test]
		public void TryAdd_Duplicate_DifferentKey()
		{
			string key = "key1";
			string key2 = "key2";
			TypeMap map = new TypeMap();
			
			Assert.IsTrue(map.TryAdd(typeof(int), key));
			Assert.Throws<ArgumentException>(() => map.TryAdd(typeof(int), key2));
		}

		[Test]
		public void Get_Missing_Key()
		{
			string key = "key1";
			TypeMap map = new TypeMap();

			Assert.Throws<KeyNotFoundException>(() => map.Get(key));
		}

		[Test]
		public void Get_Missing_Type()
		{
			TypeMap map = new TypeMap();

			Assert.Throws<KeyNotFoundException>(() => map.Get(typeof(int)));
		}

		[Test]
		public void Remove_Key()
		{
			string key = "key1";
			TypeMap map = new TypeMap();
			map.Add(typeof(int), key);

			Assert.IsTrue(map.Contains(typeof(int)));
			Assert.IsTrue(map.Contains(key));

			map.Remove(key);

			Assert.IsFalse(map.Contains(typeof(int)));
			Assert.IsFalse(map.Contains(key));
		}

		[Test]
		public void Remove_Type()
		{
			string key = "key1";
			TypeMap map = new TypeMap();
			map.Add(typeof(int), key);

			Assert.IsTrue(map.Contains(typeof(int)));
			Assert.IsTrue(map.Contains(key));

			map.Remove(typeof(int));

			Assert.IsFalse(map.Contains(typeof(int)));
			Assert.IsFalse(map.Contains(key));
		}

		[Test]
		public void Remove_Missing_Key()
		{
			string key = "key1";
			TypeMap map = new TypeMap();
			Assert.Throws<KeyNotFoundException>(() => map.Remove(key));
		}

		[Test]
		public void Remove_Missing_Type()
		{
			TypeMap map = new TypeMap();
			Assert.Throws<KeyNotFoundException>(() => map.Remove(typeof(int)));
		}
	}
}
