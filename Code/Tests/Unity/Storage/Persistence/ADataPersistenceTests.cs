using System.IO;
using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Storage.Persistence
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	public abstract class ADataPersistenceTests
	{
		protected ADataPersistence m_Persistence;
		private string[] m_Paths;

		[SetUp]
		public void SetUp()
		{
			m_Persistence = CreatePersistence();

			m_Paths = new string[]
			{
				GetMainPath(),
				GetCopyPath()
			};

			for(int x = 0; x < m_Paths.Length; x++)
			{
				string path = m_Paths[x];
				Assert.IsFalse(m_Persistence.PathExists(path), path);
			}
		}

		[TearDown]
		public void TearDown()
		{
			for(int x = 0; x < m_Paths.Length; ++x)
			{
				string path = m_Paths[x];
				if(!m_Persistence.PathExists(path))
				{
					continue;
				}
				m_Persistence.Delete(path);
				Assert.IsFalse(m_Persistence.PathExists(path));
			}
		}

		[Test]
		public void FileDoesntExist_ReadBytes()
		{
			Assert.Throws<FileNotFoundException>(() => m_Persistence.ReadBytes("missingpath.file"));
		}

		[Test]
		public void FileDoesntExist_ReadString()
		{
			Assert.Throws<FileNotFoundException>(() => m_Persistence.ReadString("missingpath.file"));
		}

		[Test]
		public void WriteRead_String()
		{
			const string STR = "Hello World";
			string testPath = GetMainPath();
			m_Persistence.WriteString(testPath, STR);
			Assert.AreEqual(STR, m_Persistence.ReadString(testPath));
		}

		[Test]
		public void WriteRead_Bytes()
		{
			byte[] bytes = new byte[] { 5, 4, 3, 2, 1 };
			string testPath = GetMainPath();
			m_Persistence.WriteBytes(testPath, bytes);
			byte[] readBytes = m_Persistence.ReadBytes(testPath);

			Assert.IsTrue(bytes != readBytes); //different array object should be returned
			Assert.AreEqual(bytes.Length, readBytes.Length);
			for(int x = 0; x < bytes.Length; ++x)
			{
				Assert.AreEqual(bytes[x], readBytes[x]);
			}
		}

		[Test]
		public void Copy_Create()
		{
			const string STR = "123";
			string testPath = GetMainPath();
			string copyPath = GetCopyPath();

			m_Persistence.WriteString(testPath, STR);
			Assert.IsTrue(m_Persistence.PathExists(testPath));
			Assert.IsFalse(m_Persistence.PathExists(copyPath));

			m_Persistence.CreateCopy(testPath, copyPath);
			Assert.IsTrue(m_Persistence.PathExists(testPath));
			Assert.IsTrue(m_Persistence.PathExists(copyPath));
		}

		[Test]
		public void Copy_ModifyOriginal_CopyNotChanged()
		{
			const string STR_A = "123";
			const string STR_B = "321";
			string testPath = GetMainPath();
			string copyPath = GetCopyPath();

			m_Persistence.WriteString(testPath, STR_A);
			m_Persistence.CreateCopy(testPath, copyPath);
			m_Persistence.WriteString(testPath, STR_B);

			Assert.AreEqual(STR_B, m_Persistence.ReadString(testPath));
			Assert.AreEqual(STR_A, m_Persistence.ReadString(copyPath));
		}

		[Test]
		public void Delete()
		{
			string testPath = GetMainPath();
			Assert.IsFalse(m_Persistence.PathExists(testPath));
			m_Persistence.WriteString(testPath, "123");
			Assert.IsTrue(m_Persistence.PathExists(testPath));
			m_Persistence.Delete(testPath);
			Assert.IsFalse(m_Persistence.PathExists(testPath));
		}

		protected abstract ADataPersistence CreatePersistence();
		protected abstract string GetMainPath();
		protected abstract string GetCopyPath();
	}
}
