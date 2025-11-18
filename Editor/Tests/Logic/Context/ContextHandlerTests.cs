using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Context
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class ContextHandlerTests
	{
		private class TestContextTarget
		{
			public int ReplaceCallCount;
			public int AttachCallCount;
			public int DetachCallCount;

			public readonly ContextHandler<int> Context;

			public TestContextTarget()
			{
				Context = new ContextHandler<int>(OnAttach, OnDetach, OnReplace);
			}

			private void OnAttach(int context, EventBinder binder)
			{
				Assert.AreEqual(AttachCallCount, DetachCallCount);
				AttachCallCount++;
			}

			private void OnDetach()
			{
				DetachCallCount++;
				Assert.AreEqual(AttachCallCount, DetachCallCount);
			}

			private void OnReplace(int context, EventBinder binder, int oldContext)
			{
				ReplaceCallCount++;
				OnDetach();
				OnAttach(context, binder);
			}
		}

		[Test]
		public void SetContext()
		{
			TestContextTarget test = new TestContextTarget();
			test.Context.SetContext(1);

			AssertTestClass(test, 1, 0, 0);
		}

		[Test]
		public void SetContext_ToDifferent()
		{
			TestContextTarget test = new TestContextTarget();
			test.Context.SetContext(1);
			test.Context.SetContext(2);

			AssertTestClass(test, 2, 1, 1);
		}

		[Test]
		public void SetContext_ToTheSame()
		{
			TestContextTarget test = new TestContextTarget();
			test.Context.SetContext(1);
			test.Context.SetContext(1);

			AssertTestClass(test, 2, 1, 1);
		}

		[Test]
		public void ClearContext_WasSet()
		{
			TestContextTarget test = new TestContextTarget();
			test.Context.SetContext(1);
			test.Context.ClearContext();

			AssertTestClass(test, 1, 1, 0);
		}

		[Test]
		public void ClearContext_WasNotSet()
		{
			TestContextTarget test = new TestContextTarget();
			test.Context.ClearContext();
			AssertTestClass(test, 0, 0, 0);
		}

		#region Helpers
		private void AssertTestClass(TestContextTarget test, int attachCallCount, int detachCallCount, int replaceCallCount)
		{
			Assert.AreEqual(attachCallCount, test.AttachCallCount, "OnAttach");
			Assert.AreEqual(detachCallCount, test.DetachCallCount, "OnDetach");
			Assert.AreEqual(replaceCallCount, test.ReplaceCallCount, "OnReplace");
		}
		#endregion
	}
}
