using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public abstract class ABaseEvent<TCallback>
		where TCallback : Delegate
	{
		protected readonly List<TCallback> m_Listeners = new List<TCallback>();
		private readonly List<TCallback> m_PendingRemoval = new List<TCallback>();

		protected bool m_IsInvoking = false;

		public int Count { get { return m_Listeners.Count; } }

		public void AddListener(TCallback listener)
		{
			m_Listeners.Add(listener);
		}

		public void RemoveListener(TCallback listener)
		{
			if(m_IsInvoking)
			{
				m_PendingRemoval.Add(listener);
			}
			else
			{
				m_Listeners.Remove(listener);
			}
		}

		protected void FlushPendingRemoval()
		{
			int count = m_PendingRemoval.Count;
			for(int x = count-1; x >= 0; --x)
			{
				TCallback callback = m_PendingRemoval[x];
				m_Listeners.Remove(callback);
			}
			m_PendingRemoval.Clear();
		}

		public void RemoveAllListeners()
		{
			m_Listeners.Clear();
		}

		public override string ToString()
		{
			return $"[{GetType().Name}, ListenerCount: {m_Listeners.Count}]";
		}
	}
}
