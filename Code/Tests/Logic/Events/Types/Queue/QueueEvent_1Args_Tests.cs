using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Queue
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class QueueEvent_1Args_Tests : AQueueEventTests
	{
		public class TestEvent : ATestEvent<QueueEvent<int>, AEvent<int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default);
			}

			protected override AEvent<int>.Callback ToCallback(Action action)
			{
				return (arg0) => action();
			}

			protected override void Bind(EventBinder binder, QueueEvent<int> target, AEvent<int>.Callback callback)
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
