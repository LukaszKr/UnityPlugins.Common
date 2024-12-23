using NUnit.Framework;

namespace UnityPlugins.Common.Unity.Storage
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class BinaryJsonStorageTests : ADataStorageTests
	{
		protected override ADataStorage<TestData> CreateStorage(ADataPersistence persistence, UnityPath path)
		{
			return new BinaryJsonStorage<TestData>(persistence, path);
		}
	}
}
