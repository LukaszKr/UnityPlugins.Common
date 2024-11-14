using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Queue
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class QueueEvent_0Args_Tests : AQueueEventTests
	{
		public class TestEvent : ATestEvent<QueueEvent, AEvent.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke();
			}

			protected override AEvent.Callback ToCallback(Action action)
			{
				return () => action();
			}

			protected override void Bind(EventBinder binder, QueueEvent target, AEvent.Callback callback)
			{
				binder.Bind(target, callback);
			}
		}

		protected override ITestEvent CreateEvent()
		{
			return new TestEvent();
		}
	}
}
