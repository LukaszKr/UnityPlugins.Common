using System;
using System.Collections.Generic;
using UnityPlugins.Common.Logic;
using UnityPlugins.Common.Logic.Events;

namespace UnityPlugins.Common
{
	internal abstract class ATestEvent<TEvent, TCallback> : ITestEvent
		where TEvent : ABaseEvent<TCallback>, new()
		where TCallback : Delegate
	{
		public readonly TEvent Event = new TEvent();

		private readonly Dictionary<Action, TCallback> m_Map = new Dictionary<Action, TCallback>();

		public int Count => Event.Count;

		public void AddListener(Action action)
		{
			TCallback callback = GetCallback(action);
			Event.AddListener(callback);
		}

		public void RemoveListener(Action action)
		{
			TCallback callback = GetCallback(action);
			Event.RemoveListener(callback);
		}

		public abstract void Invoke();
		protected abstract void Bind(EventBinder binder, TEvent target, TCallback callback);

		public void Bind(EventBinder binder, Action action)
		{
			TCallback callback = GetCallback(action);
			Bind(binder, Event, callback);
		}

		private TCallback GetCallback(Action action)
		{
			TCallback callback;
			if(!m_Map.TryGetValue(action, out callback))
			{
				callback = ToCallback(action);
				m_Map[action] = callback;
			}
			return callback;
		}

		protected abstract TCallback ToCallback(Action action);
	}
}
