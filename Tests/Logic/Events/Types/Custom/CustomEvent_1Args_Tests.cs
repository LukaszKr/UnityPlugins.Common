using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Custom
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class CustomEvent_1Args_Tests : ACustomEventTests
	{
		public class TestEvent : ATestEvent<CustomEvent<int>, AEvent<int>.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke(default);
			}

			protected override AEvent<int>.Callback ToCallback(Action action)
			{
				return (arg0) => action();
			}

			protected override void Bind(EventBinder binder, CustomEvent<int> target, AEvent<int>.Callback callback)
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
