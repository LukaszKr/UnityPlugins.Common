using NUnit.Framework;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityPlugins.Common.Unity.Components
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class AUnitySingletonTests
	{
		private class TestSingleton : AUnitySingleton<TestSingleton>
		{
		}

		[Test]
		public void NotYetCreated_InstanceIsNull()
		{
			Assert.IsTrue(null == TestSingleton.Instance);
		}

		[Test]
		public void Created_InstanceIsNotNull()
		{
			TestSingleton singleton = Spawn();

			Assert.AreEqual(singleton, TestSingleton.Instance);
			Object.DestroyImmediate(singleton);
		}

		[Test]
		public void DestroySingleton_InstanceIsNull()
		{
			TestSingleton singleton = Spawn();
			Object.DestroyImmediate(singleton);
			Assert.IsTrue(null == TestSingleton.Instance);
		}

		private TestSingleton Spawn()
		{
			GameObject go = new GameObject();
			return go.AddComponent<TestSingleton>();
		}
	}
}
