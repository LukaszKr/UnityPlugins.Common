using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Storage.Utilities
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class StorageEntryTests
	{
		public class Container
		{
			public StorageEntry<int> Stored = new StorageEntry<int>(5);
		}

		private ADataStorage<Container> m_Storage;

		[SetUp]
		public void SetUp()
		{
			m_Storage = new BinaryJsonStorage<Container>(new MemoryDataPersistence(), "Test", false);
		}

		[Test]
		public void Modified_IsSetToTrueWhenModified()
		{
			Container container = new Container();

			Assert.IsFalse(container.Stored.Modified);
			Assert.AreEqual(5, container.Stored.Value);
			container.Stored.Value = 4;
			Assert.IsTrue(container.Stored.Modified);
			Assert.AreEqual(4, container.Stored.Value);
		}

		[Test]
		public void Modified_DoesntResetIfValueReturnsToDefault()
		{
			Container container = new Container();

			Assert.IsFalse(container.Stored.Modified);
			Assert.AreEqual(5, container.Stored.Value);
			container.Stored.Value = 4;
			container.Stored.Value = 5;
			Assert.IsTrue(container.Stored.Modified);
			Assert.AreEqual(5, container.Stored.Value);
		}

		[Test]
		public void Deserialization_NotModifeid()
		{
			Container container = new Container();
			m_Storage.Save(container);
			Container deserialized = m_Storage.Load(null);

			Assert.AreEqual(container.Stored.Value, deserialized.Stored.Value);
			Assert.IsFalse(container.Stored.Modified);
			Assert.IsFalse(deserialized.Stored.Modified);
		}

		[Test]
		public void Deserialization_ModifiedEntry()
		{
			Container container = new Container();
			container.Stored.Value = 3;
			m_Storage.Save(container);
			Container deserialized = m_Storage.Load(null);

			Assert.AreEqual(container.Stored.Value, deserialized.Stored.Value);
			Assert.IsTrue(container.Stored.Modified);
			Assert.IsTrue(deserialized.Stored.Modified);
		}

		[Test]
		public void Deserialization_VersionChanged_RestoreToDefault()
		{
			Container container = new Container();
			container.Stored.Value = 3;
			m_Storage.Save(container);

			Container loadInto = new Container();
			loadInto.Stored = new StorageEntry<int>(4, 2);
			Container deserialized = m_Storage.Load(loadInto);

			Assert.AreNotEqual(container.Stored.Value, deserialized.Stored.Value);
			Assert.AreEqual(4, deserialized.Stored.Value);
			Assert.IsTrue(container.Stored.Modified);
			Assert.IsFalse(deserialized.Stored.Modified);
		}
	}
}
