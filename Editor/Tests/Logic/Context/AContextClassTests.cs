using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Context
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class AContextClassTests
	{
		private class TestContextClass : AContextClass<int>
		{
			public bool ContextWillBeDifferent;

			public int AttachCallCount;
			public int DetachCallCount;
			public int ReplaceCallCount;

			public EventBinder ContextBinder;

			public TestContextClass(bool willChangeContext = false)
			{
				ContextWillBeDifferent = willChangeContext;
			}

			protected override void OnAttach(EventBinder binder)
			{
				ContextBinder = binder;
				AttachCallCount++;
			}

			protected override void OnDetach()
			{
				DetachCallCount++;
			}

			protected override void OnReplace(EventBinder binder, int oldContext)
			{
				ReplaceCallCount++;
				if(ContextWillBeDifferent)
				{
					Assert.AreNotEqual(m_Context, oldContext);
				}

				base.OnReplace(binder, oldContext);
			}
		}

		[Test]
		public void SetContext()
		{
			TestContextClass test = new TestContextClass();
			test.SetContext(1);

			AssertTestClass(test, 1, 0, 0);
		}

		[Test]
		public void SetContext_ToDifferent()
		{
			TestContextClass test = new TestContextClass(true);
			test.SetContext(1);
			test.SetContext(2);

			AssertTestClass(test, 2, 1, 1);
		}

		[Test]
		public void SetContext_ToTheSame()
		{
			TestContextClass test = new TestContextClass();
			test.SetContext(1);
			test.SetContext(1);

			AssertTestClass(test, 2, 1, 1);
		}

		[Test]
		public void ClearContext_WasSet()
		{
			TestContextClass test = new TestContextClass();
			test.SetContext(1);
			test.ClearContext();

			AssertTestClass(test, 1, 1, 0);
		}

		[Test]
		public void ClearContext_WasNotSet()
		{
			TestContextClass test = new TestContextClass();
			test.ClearContext();
			AssertTestClass(test, 0, 0, 0);
		}

		[Test]
		public void ClearContext_EventBinderCleared()
		{
			TestContextClass test = new TestContextClass();
			test.SetContext(5);
			CustomEvent evt = new CustomEvent();
			test.ContextBinder.Bind(evt, () => { });
			Assert.AreEqual(1, evt.Count);
			test.ClearContext();
			Assert.AreEqual(0, evt.Count);
		}

		#region Helpers
		private void AssertTestClass(TestContextClass test, int attachCallCount, int detachCallCount, int replaceCallCount)
		{
			Assert.AreEqual(attachCallCount, test.AttachCallCount, "OnAttach");
			Assert.AreEqual(detachCallCount, test.DetachCallCount, "OnDetach");
			Assert.AreEqual(replaceCallCount, test.ReplaceCallCount, "OnReplace");
		}
		#endregion
	}
}
