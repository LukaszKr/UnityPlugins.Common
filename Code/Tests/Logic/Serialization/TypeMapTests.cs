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
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			map.Add(typeof(int), id);

			Assert.IsTrue(map.Contains(typeof(int)));
			Assert.IsTrue(map.Contains(id));

			Assert.AreEqual(id, map.Get(typeof(int)));
			Assert.AreEqual(typeof(int), map.Get(id));
		}

		[Test]
		public void Add_Duplicate()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			map.Add(typeof(int), id);

			Assert.Throws<ArgumentException>(() => map.Add(typeof(int), id));
		}

		[Test]
		public void Add_Duplicate_DifferentID()
		{
			ID<Type> id1 = new ID<Type>(1);
			ID<Type> id2 = new ID<Type>(2);
			TypeMap map = new TypeMap();
			map.Add(typeof(int), id1);

			Assert.Throws<ArgumentException>(() => map.Add(typeof(int), id2));
		}

		[Test]
		public void Add_Duplicate_DifferentType()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			map.Add(typeof(int), id);

			Assert.Throws<ArgumentException>(() => map.Add(typeof(float), id));
		}

		[Test]
		public void TryAdd_Duplicate()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			Assert.IsTrue(map.TryAdd(typeof(int), id));
			Assert.IsFalse(map.TryAdd(typeof(int), id));
		}

		[Test]
		public void TryAdd_Duplicate_DifferentType()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();

			Assert.IsTrue(map.TryAdd(typeof(int), id));
			Assert.Throws<ArgumentException>(() => map.TryAdd(typeof(float), id));
		}

		[Test]
		public void TryAdd_Duplicate_DifferentID()
		{
			ID<Type> id = new ID<Type>(1);
			ID<Type> id2 = new ID<Type>(2);
			TypeMap map = new TypeMap();
			
			Assert.IsTrue(map.TryAdd(typeof(int), id));
			Assert.Throws<ArgumentException>(() => map.TryAdd(typeof(int), id2));
		}

		[Test]
		public void Get_Missing_ID()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();

			Assert.Throws<KeyNotFoundException>(() => map.Get(id));
		}

		[Test]
		public void Get_Missing_Type()
		{
			TypeMap map = new TypeMap();

			Assert.Throws<KeyNotFoundException>(() => map.Get(typeof(int)));
		}

		[Test]
		public void Remove_ID()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			map.Add(typeof(int), id);

			Assert.IsTrue(map.Contains(typeof(int)));
			Assert.IsTrue(map.Contains(id));

			map.Remove(id);

			Assert.IsFalse(map.Contains(typeof(int)));
			Assert.IsFalse(map.Contains(id));
		}

		[Test]
		public void Remove_Type()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			map.Add(typeof(int), id);

			Assert.IsTrue(map.Contains(typeof(int)));
			Assert.IsTrue(map.Contains(id));

			map.Remove(typeof(int));

			Assert.IsFalse(map.Contains(typeof(int)));
			Assert.IsFalse(map.Contains(id));
		}

		[Test]
		public void Remove_Missing_ID()
		{
			ID<Type> id = new ID<Type>(1);
			TypeMap map = new TypeMap();
			Assert.Throws<KeyNotFoundException>(() => map.Remove(id));
		}

		[Test]
		public void Remove_Missing_Type()
		{
			TypeMap map = new TypeMap();
			Assert.Throws<KeyNotFoundException>(() => map.Remove(typeof(int)));
		}
	}
}
