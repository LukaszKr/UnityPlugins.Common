using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Queue
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class QueueEvent_3Args_Tests : AQueueEventTests
	{
		public class TestEvent : ATestEvent<QueueEvent<int, int, int>, AEvent<int, int, int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default, default, default);
			}

			protected override AEvent<int, int, int>.Callback ToCallback(Action action)
			{
				return (arg0, arg1, arg2) => action();
			}

			protected override void Bind(EventBinder binder, QueueEvent<int, int, int> target, AEvent<int, int, int>.Callback callback)
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