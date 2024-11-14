using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Custom
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class CustomEvent_0Args_Tests : ACustomEventTests
	{
		public class TestEvent : ATestEvent<CustomEvent, AEvent.Callback>
		{
			public override void Invoke()
			{
				Event.Invoke();
			}

			protected override AEvent.Callback ToCallback(Action action)
			{
				return () => action();
			}

			protected override void Bind(EventBinder binder, CustomEvent target, AEvent.Callback callback)
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
