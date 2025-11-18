using System.IO;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace UnityPlugins.Common.Unity.Serialization.Storage
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	public abstract class ADataStorageTests
	{
		public class TestData
		{
			public string StringValue;
			public NestedTestData Nested;
			public NestedTestData[] NestedArray;
		}

		public class NestedTestData
		{
			public int Value;
		}

		protected ADataStorage<TestData> m_Storage;
		protected MemoryDataPersistence m_Persistence;

		[SetUp]
		public void SetUp()
		{
			m_Persistence = new MemoryDataPersistence();
			m_Storage = CreateStorage(m_Persistence, "Tests/Storage.test");
		}

		[TearDown]
		public void TearDown()
		{
			m_Storage.Delete(true);
		}

		protected abstract ADataStorage<TestData> CreateStorage(ADataPersistence persistence, string path);

		[Test]
		public void BackupPath_SameDirectoryAsMain()
		{
			FileInfo file = new FileInfo(m_Storage.FilePath);
			FileInfo backup = new FileInfo(m_Storage.BackupPath);
			Assert.AreEqual(file.Directory.FullName, backup.Directory.FullName);
		}

		[Test]
		public void Delete()
		{
			TestData toSave = CreateTestData();
			SaveWithBackup(toSave);
			m_Storage.Delete(true);
			Assert.IsFalse(m_Persistence.PathExists(m_Storage.FilePath));
			Assert.IsFalse(m_Persistence.PathExists(m_Storage.BackupPath));
		}

		[Test]
		public void Delete_KeepBackup()
		{
			TestData toSave = CreateTestData();
			SaveWithBackup(toSave);
			m_Storage.Delete(false);
			Assert.IsFalse(m_Persistence.PathExists(m_Storage.FilePath));
			Assert.IsTrue(m_Persistence.PathExists(m_Storage.BackupPath));
		}

		[Test]
		public void SaveAndLoad()
		{
			TestData toSave = CreateTestData();
			m_Storage.Save(toSave);
			TestData loaded = m_Storage.Load(null);
			AssertData(toSave, loaded);
		}

		[Test]
		public void MainFileIsMissing_LoadFromBackup()
		{
			TestData toSave = CreateTestData();
			SaveWithBackup(toSave);
			m_Persistence.Delete(m_Storage.FilePath);
			Assert.IsFalse(m_Persistence.PathExists(m_Storage.FilePath));

			TestData loaded = m_Storage.Load(null);
			AssertData(toSave, loaded);
		}

		[Test]
		public void MainFileIsCorrupted_LoadFromBackup()
		{
			TestData toSave = CreateTestData();
			SaveWithBackup(toSave);
			m_Persistence.WriteString(m_Storage.FilePath, "Corrupted data");

			LogAssert.ignoreFailingMessages = true;
			TestData loaded = m_Storage.Load(null);
			LogAssert.ignoreFailingMessages = false;
			AssertData(toSave, loaded);
		}

		#region Helpers
		private void SaveWithBackup(TestData toSave)
		{
			m_Storage.Save(toSave);
			Assert.IsTrue(m_Persistence.PathExists(m_Storage.FilePath));
			Assert.IsFalse(m_Persistence.PathExists(m_Storage.BackupPath));
			m_Storage.Save(toSave);
			Assert.IsTrue(m_Persistence.PathExists(m_Storage.BackupPath));
		}

		private void AssertData(TestData expected, TestData data)
		{
			Assert.IsNotNull(expected);
			Assert.IsNotNull(data);
			Assert.AreNotSame(expected, data);

			Assert.AreEqual(expected.StringValue, data.StringValue);
			AssertNestedData(expected.Nested, data.Nested);
			if(expected.NestedArray != null)
			{
				Assert.AreEqual(expected.NestedArray.Length, data.NestedArray.Length);
				for(int x = 0; x < expected.NestedArray.Length; ++x)
				{
					AssertNestedData(expected.NestedArray[x], data.NestedArray[x]);
				}
			}
			else
			{
				Assert.IsNull(data.NestedArray);
			}
		}

		private void AssertNestedData(NestedTestData expected, NestedTestData data)
		{
			if(expected == null)
			{
				Assert.IsNull(data);
			}
			else
			{
				Assert.IsNotNull(data);
				Assert.AreEqual(expected.Value, data.Value);
			}
		}

		private TestData CreateTestData()
		{
			TestData data = new TestData();
			data.StringValue = "Hello World";
			data.Nested = new NestedTestData()
			{
				Value = 5
			};
			data.NestedArray = new NestedTestData[]
			{
				new NestedTestData()
				{
					Value = 2
				},
				new NestedTestData()
				{
					Value = 3
				}
			};

			return data;
		}
		#endregion
	}
}
