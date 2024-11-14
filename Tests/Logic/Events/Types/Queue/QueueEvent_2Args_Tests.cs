using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Queue
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class QueueEvent_2Args_Tests : AQueueEventTests
	{
		public class TestEvent : ATestEvent<QueueEvent<int, int>, AEvent<int, int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default, default);
			}

			protected override AEvent<int, int>.Callback ToCallback(Action action)
			{
				return (arg0, arg1) => action();
			}

			protected override void Bind(EventBinder binder, QueueEvent<int, int> target, AEvent<int, int>.Callback callback)
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
