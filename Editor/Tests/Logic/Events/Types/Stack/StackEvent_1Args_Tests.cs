using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Stack
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class StackEvent_1Args_Tests : AStackEventTests
	{
		public class TestEvent : ATestEvent<StackEvent<int>, AEvent<int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default);
			}

			protected override AEvent<int>.Callback ToCallback(Action action)
			{
				return (arg0) => action();
			}

			protected override void Bind(EventBinder binder, StackEvent<int> target, AEvent<int>.Callback callback)
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
