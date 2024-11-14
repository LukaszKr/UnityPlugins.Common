using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Stack
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class StackEvent_2Args_Tests : AStackEventTests
	{
		public class TestEvent : ATestEvent<StackEvent<int, int>, AEvent<int, int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default, default);
			}

			protected override AEvent<int, int>.Callback ToCallback(Action action)
			{
				return (arg0, arg1) => action();
			}

			protected override void Bind(EventBinder binder, StackEvent<int, int> target, AEvent<int, int>.Callback callback)
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
