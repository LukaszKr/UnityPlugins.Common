using System;

namespace UnityPlugins.Common.Logic
{
	public class EventBinding<TCallback> : IEventBinding
		where TCallback : Delegate
	{
		private readonly ABaseEvent<TCallback> m_Target;
		private readonly TCallback m_Callback;

		public EventBinding(ABaseEvent<TCallback> target, TCallback callback)
		{
			m_Target = target;
			m_Callback = callback;
		}

		public void Bind()
		{
			m_Target.AddListener(m_Callback);
		}

		public void Unbind()
		{
			m_Target.RemoveListener(m_Callback);
		}
	}
}
