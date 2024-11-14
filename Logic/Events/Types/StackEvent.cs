namespace UnityPlugins.Common.Logic
{
	public sealed class StackEvent : AEvent
	{
		public override void Invoke()
		{
			int lastIndex = m_Listeners.Count-1;
			if(lastIndex >= 0)
			{
				m_Listeners[lastIndex]();
			}
		}
	}

	public sealed class StackEvent<T0> : AEvent<T0>
	{
		public override void Invoke(T0 arg0)
		{
			int lastIndex = m_Listeners.Count-1;
			if(lastIndex >= 0)
			{
				m_Listeners[lastIndex](arg0);
			}
		}
	}

	public sealed class StackEvent<T0, T1> : AEvent<T0, T1>
	{
		public override void Invoke(T0 arg0, T1 arg1)
		{
			int lastIndex = m_Listeners.Count-1;
			if(lastIndex >= 0)
			{
				m_Listeners[lastIndex](arg0, arg1);
			}
		}
	}

	public sealed class StackEvent<T0, T1, T2> : AEvent<T0, T1, T2>
	{
		public override void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			int lastIndex = m_Listeners.Count-1;
			if(lastIndex >= 0)
			{
				m_Listeners[lastIndex](arg0, arg1, arg2);
			}
		}
	}
}
