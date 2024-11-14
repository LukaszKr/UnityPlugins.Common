using UnityPlugins.Common.Logic;
using NUnit.Framework;
using UnityEngine;

namespace UnityPlugins.Common.Unity.Components
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class AContextComponentTests
	{
		private class TestContextComponent : AContextComponent<int>
		{
			public int InitializeCallCount;
			public int AttachCallCount;
			public int DetachCallCount;
			public int ReplaceCallCount;

			protected override void OnInitialize()
			{
				InitializeCallCount++;
				Assert.AreEqual(0, AttachCallCount);
				Assert.AreEqual(0, DetachCallCount);
				Assert.AreEqual(0, ReplaceCallCount);
			}

			protected override void OnAttach(EventBinder binder)
			{
				Assert.IsTrue(AttachCallCount == DetachCallCount);
				AttachCallCount++;
			}

			protected override void OnDetach()
			{
				DetachCallCount++;
				Assert.IsTrue(AttachCallCount == DetachCallCount);
			}

			protected override void OnReplace(int context, EventBinder binder, int oldContext)
			{
				ReplaceCallCount++;
				base.OnReplace(context, binder, oldContext);
			}
		}

		private TestContextComponent m_Component;

		[SetUp]
		public void SetUp()
		{
			GameObject gameObject = new GameObject();
			m_Component = gameObject.AddComponent<TestContextComponent>();
		}

		[TearDown]
		public void TearDown()
		{
			if(m_Component)
			{
				Object.DestroyImmediate(m_Component.GameObject);
			}
		}

		[Test]
		public void SetContext()
		{
			m_Component.SetContext(1);

			AssertTestClass(m_Component, true, 1, 0, 0);
		}

		[Test]
		public void SetContext_ToDifferent()
		{
			m_Component.SetContext(1);
			m_Component.SetContext(2);

			AssertTestClass(m_Component, true, 2, 1, 1);
		}

		[Test]
		public void SetContext_ToTheSame()
		{
			m_Component.SetContext(1);
			m_Component.SetContext(1);

			AssertTestClass(m_Component, true, 2, 1, 1);
		}

		[Test]
		public void ClearContext_WasSet()
		{
			m_Component.SetContext(1);
			m_Component.ClearContext();

			AssertTestClass(m_Component, true, 1, 1, 0);
		}

		[Test]
		public void ClearContext_WasNotSet()
		{
			m_Component.ClearContext();
			AssertTestClass(m_Component, false, 0, 0, 0);
		}

		[Test]
		public void ClearContext_IsNotCalledWhenObjectIsDestroyed()
		{
			m_Component.SetContext(1);
			Object.DestroyImmediate(m_Component);
			AssertTestClass(m_Component, true, 1, 0, 0);
		}

		#region Helpers
		private void AssertTestClass(TestContextComponent component, bool wasInitialized, int attachCallCount, int detachCallCount, int replaceCallCount)
		{
			Assert.AreEqual((wasInitialized? 1: 0), component.InitializeCallCount, "OnInitialize");
			Assert.AreEqual(attachCallCount, component.AttachCallCount, "OnAttach");
			Assert.AreEqual(detachCallCount, component.DetachCallCount, "OnDetach");
			Assert.AreEqual(replaceCallCount, component.ReplaceCallCount, "OnReplace");
		}
		#endregion
	}
}
