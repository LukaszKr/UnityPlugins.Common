using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Storage
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class BinaryJsonStorageTests : ADataStorageTests
	{
		protected override ADataStorage<TestData> CreateStorage(ADataPersistence persistence, string filePath)
		{
			return new BinaryJsonStorage<TestData>(persistence, filePath);
		}
	}
}
