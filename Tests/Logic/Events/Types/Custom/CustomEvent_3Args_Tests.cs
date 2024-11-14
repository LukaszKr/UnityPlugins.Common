using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Custom
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class CustomEvent_3Args_Tests : ACustomEventTests
	{
		public class TestEvent : ATestEvent<CustomEvent<int, int, int>, AEvent<int, int, int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default, default, default);
			}

			protected override AEvent<int, int, int>.Callback ToCallback(Action action)
			{
				return (arg0, arg1, arg2) => action();
			}

			protected override void Bind(EventBinder binder, CustomEvent<int, int, int> target, AEvent<int, int, int>.Callback callback)
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
