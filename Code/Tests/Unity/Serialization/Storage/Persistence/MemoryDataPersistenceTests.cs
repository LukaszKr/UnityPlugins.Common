using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Serialization.Storage.Persistence
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class MemoryDataPersistenceTests : ADataPersistenceTests
	{
		protected override ADataPersistence CreatePersistence()
		{
			return new MemoryDataPersistence();
		}

		protected override string GetMainPath()
		{
			return "Main";
		}

		protected override string GetCopyPath()
		{
			return "Copy";
		}
	}
}
