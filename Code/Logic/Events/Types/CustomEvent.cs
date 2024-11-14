namespace UnityPlugins.Common.Logic
{
	public sealed class CustomEvent : AEvent
	{
		public override void Invoke()
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_IsInvoking = true;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x]();
				}
				m_IsInvoking = false;
				FlushPendingRemoval();
			}
		}
	}

	public sealed class CustomEvent<T0> : AEvent<T0>
	{
		public override void Invoke(T0 arg0)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_IsInvoking = true;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0);
				}
				m_IsInvoking = false;
				FlushPendingRemoval();
			}
		}
	}

	public sealed class CustomEvent<T0, T1> : AEvent<T0, T1>
	{
		public override void Invoke(T0 arg0, T1 arg1)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_IsInvoking = true;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0, arg1);
				}
				m_IsInvoking = false;
				FlushPendingRemoval();
			}
		}
	}

	public sealed class CustomEvent<T0, T1, T2> : AEvent<T0, T1, T2>
	{
		public override void Invoke(T0 arg0, T1 arg1, T2 arg2)
		{
			int count = m_Listeners.Count;
			if(count > 0)
			{
				m_IsInvoking = true;
				for(int x = 0; x < count; x++)
				{
					m_Listeners[x](arg0, arg1, arg2);
				}
				m_IsInvoking = false;
				FlushPendingRemoval();
			}
		}
	}
}
