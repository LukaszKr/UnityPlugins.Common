using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityPlugins.Common.Unity.Components
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class ASingletonComponentTests
	{
		private class TestSingletonComponent : ASingletonComponent<TestSingletonComponent>
		{
		}

		[Test]
		public void NotYetCreated_InstanceIsNull()
		{
			Assert.IsTrue(null == TestSingletonComponent.Instance);
		}

		[Test]
		public void Created_InstanceIsNotNull()
		{
			TestSingletonComponent singleton = Spawn();

			Assert.AreEqual(singleton, TestSingletonComponent.Instance);
			Object.DestroyImmediate(singleton);
		}

		[Test]
		public void DestroySingleton_InstanceIsNull()
		{
			TestSingletonComponent singleton = Spawn();
			Object.DestroyImmediate(singleton);
			Assert.IsTrue(null == TestSingletonComponent.Instance);
		}

		private TestSingletonComponent Spawn()
		{
			GameObject go = new GameObject();
			return go.AddComponent<TestSingletonComponent>();
		}
	}
}
