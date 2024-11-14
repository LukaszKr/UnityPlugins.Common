using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Stack
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class StackEvent_0Args_Tests : AStackEventTests
	{
		public class TestEvent : ATestEvent<StackEvent, AEvent.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke();
			}

			protected override AEvent.Callback ToCallback(Action action)
			{
				return () => action();
			}

			protected override void Bind(EventBinder binder, StackEvent target, AEvent.Callback callback)
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
