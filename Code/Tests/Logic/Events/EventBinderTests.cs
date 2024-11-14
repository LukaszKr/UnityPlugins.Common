using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EventBinderTests
	{
		private EventBinder m_Binder;

		[SetUp]
		public void Setup()
		{
			m_Binder = new EventBinder();
		}

		[Test, Description("Event binder is enabled by default.")]
		public void EnabledByDefault()
		{
			Assert.IsFalse(m_Binder.IsDisabled);
		}

		[Test, Description("Enable/Disable methods sets state correctly.")]
		public void EnableDisableMethod()
		{
			CustomEvent testEvent = new CustomEvent();
			AEvent.Callback callback = () => { };
			Assert.IsFalse(m_Binder.IsDisabled);
			m_Binder.Bind(testEvent, callback);

			Assert.AreEqual(1, testEvent.Count);
			m_Binder.Enable(false);
			Assert.AreEqual(0, testEvent.Count);
			m_Binder.Enable(true);
			Assert.AreEqual(1, testEvent.Count);
		}

		[Test, Description("When disabled, no callbacks are called.")]
		public void Disable_AfterBinding()
		{
			int callCount = 0;
			AEvent.Callback callback = () => { callCount++; };
			CustomEvent testEvent = new CustomEvent();

			m_Binder.Bind(testEvent, callback);
			m_Binder.Disable();
			Assert.IsTrue(m_Binder.IsDisabled);

			Assert.AreEqual(0, testEvent.Count);
			testEvent.Invoke();
			Assert.AreEqual(0, callCount);

			m_Binder.Enable();
			Assert.IsFalse(m_Binder.IsDisabled);
			Assert.AreEqual(1, testEvent.Count);
			testEvent.Invoke();
			Assert.AreEqual(1, callCount);
		}

		[Test, Description("When disabled, no callbacks are called.")]
		public void Disable_BeforeBinding()
		{
			int callCount = 0;
			AEvent.Callback callback = () => { callCount++; };
			CustomEvent testEvent = new CustomEvent();

			m_Binder.Disable();
			Assert.IsTrue(m_Binder.IsDisabled);
			m_Binder.Bind(testEvent, callback);

			Assert.AreEqual(0, testEvent.Count);
			testEvent.Invoke();
			Assert.AreEqual(0, callCount);

			m_Binder.Enable();
			Assert.IsFalse(m_Binder.IsDisabled);
			Assert.AreEqual(1, testEvent.Count);
			testEvent.Invoke();
			Assert.AreEqual(1, callCount);
		}

		[Test, Description("Unbind all when binder is enabled.")]
		public void UnbindAll_WhenEnabled()
		{
			AEvent.Callback callback = () => { };
			CustomEvent testEvent = new CustomEvent();
			m_Binder.Bind(testEvent, callback);

			Assert.AreEqual(1, testEvent.Count);
			m_Binder.UnbindAll();
			Assert.AreEqual(0, testEvent.Count);
		}

		[Test, Description("Unbind all when binder is disabled.")]
		public void UnbindAll_WhenDisabled()
		{
			AEvent.Callback callback = () => { };
			CustomEvent testEvent = new CustomEvent();
			m_Binder.Bind(testEvent, callback);

			Assert.AreEqual(1, testEvent.Count);
			m_Binder.Disable();
			m_Binder.UnbindAll();
			m_Binder.Enable();
			Assert.AreEqual(0, testEvent.Count);
		}
	}
}
