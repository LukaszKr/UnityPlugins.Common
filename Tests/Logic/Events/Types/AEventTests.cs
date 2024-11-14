using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events
{
	internal abstract class AEventTests
	{
		protected abstract ITestEvent CreateEvent();

		[Test, Description("Add listener.")]
		public void AddListener()
		{
			Action callback = () => { };
			ITestEvent e = CreateEvent();
			Assert.AreEqual(0, e.Count);

			e.AddListener(callback);
			Assert.AreEqual(1, e.Count);
		}

		[Test, Description("Adding listener twice is valid.")]
		public void AddListener_Twice()
		{
			Action callback = () => { };
			ITestEvent e = CreateEvent();
			Assert.AreEqual(0, e.Count);

			e.AddListener(callback);
			e.AddListener(callback);
			Assert.AreEqual(2, e.Count);
		}

		[Test, Description("Remove listener.")]
		public void RemoveListener()
		{
			Action callback = () => { };
			ITestEvent e = CreateEvent();
			Assert.AreEqual(0, e.Count);
			e.AddListener(callback);

			Assert.AreEqual(1, e.Count);
			e.RemoveListener(callback);
		}

		[Test, Description("Remove listener only removes one instance, even if listener was added multiple times.")]
		public void RemoveListener_SingleOccurence()
		{
			Action callback = () => { };
			ITestEvent e = CreateEvent();
			Assert.AreEqual(0, e.Count);
			e.AddListener(callback);
			e.AddListener(callback);
			Assert.AreEqual(2, e.Count);

			e.RemoveListener(callback);
			Assert.AreEqual(1, e.Count);
		}

		[Test, Description("Invoke on empty.")]
		public void Invoke_NoListeners()
		{
			ITestEvent e = CreateEvent();
			e.Invoke();
		}

		[Test, Description("Invoke with single listener.")]
		public void Invoke_SingleListener()
		{
			int callCount = 0;
			Action callback = () => { callCount++; };
			ITestEvent e = CreateEvent();
			e.AddListener(callback);
			e.Invoke();
			Assert.AreEqual(1, callCount);
		}

		[Test, Description("Invoke with same listener added twice.")]
		public void Invoke_SameListenerTwice()
		{
			int callCount = 0;
			Action callback = () => { callCount++; };
			ITestEvent e = CreateEvent();
			e.AddListener(callback);
			e.AddListener(callback);
			e.Invoke();
			Assert.AreEqual(callCount, GetExpectedCallCount(2));
		}

		[Test, Description("Invoke with different listeners.")]
		public void Invoke_MultipleListeners()
		{
			bool[] callTable = new bool[3];
			Action[] callbacks = new Action[callTable.Length];
			ITestEvent e = CreateEvent();
			for(int x = 0; x < callbacks.Length; ++x)
			{
				int index = x;
				callbacks[x] = () => { callTable[index] = true; };
				e.AddListener(callbacks[x]);
			}

			e.Invoke();
			AssertCallTable(callTable);
		}

		[Test, Description("Event can be binded with binder.")]
		public void EventBinder_Bind()
		{
			int callCount = 0;
			Action callback = () => { callCount++; };

			EventBinder binder = new EventBinder();
			ITestEvent e = CreateEvent();
			Assert.AreEqual(0, binder.Count);
			e.Bind(binder, callback);
			Assert.AreEqual(1, binder.Count);

			e.Invoke();
			Assert.AreEqual(1, callCount);
		}

		[Test, Description("Event can be unbinded from binder.")]
		public void EventBinder_Unbind()
		{
			int callCount = 0;
			Action callback = () => { callCount++; };

			EventBinder binder = new EventBinder();
			ITestEvent e = CreateEvent();
			e.Bind(binder, callback);

			e.Invoke();
			Assert.AreEqual(1, callCount);

			binder.UnbindAll();
			e.Invoke();
			Assert.AreEqual(1, callCount);
		}

		protected abstract void AssertCallTable(bool[] callTable);
		protected abstract int GetExpectedCallCount(int listenerCount);
	}
}
