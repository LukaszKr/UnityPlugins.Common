using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Storage
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class TextJsonStorageTests : ADataStorageTests
	{
		protected override ADataStorage<TestData> CreateStorage(ADataPersistence persistence, UnityPath path)
		{
			return new TextJsonStorage<TestData>(persistence, path);
		}
	}
}
