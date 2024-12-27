using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Storage.Persistence
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	public class FileDataPersistenceTests : ADataPersistenceTests
	{
		protected override ADataPersistence CreatePersistence()
		{
			return new FileDataPersistence();
		}

		protected override string GetMainPath()
		{
			return new UnityPath(EUnityPathType.Project, "Tests/Storage/Main.data").ToString(m_Persistence);
		}

		protected override string GetCopyPath()
		{
			return new UnityPath(EUnityPathType.Project, "Tests/Storage/Copy.data").ToString(m_Persistence);
		}
	}
}
