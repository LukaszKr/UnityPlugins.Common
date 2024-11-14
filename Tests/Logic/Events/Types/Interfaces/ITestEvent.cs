using System;

namespace UnityPlugins.Common.Logic.Events
{
	internal interface ITestEvent
	{
		int Count { get; }

		void AddListener(Action action);
		void RemoveListener(Action action);
		void Invoke();

		void Bind(EventBinder binder, Action action);
	}
}
