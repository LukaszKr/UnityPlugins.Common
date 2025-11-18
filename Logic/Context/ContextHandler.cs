namespace UnityPlugins.Common.Logic
{
	public class ContextHandler<TContext>
	{
		private readonly EventBinder m_ContextBinder = new EventBinder();

		private readonly OnAttachDelegate m_OnAttach;
		private readonly OnDetachDelegate m_OnDetach;
		private readonly OnReplaceDelegate m_OnReplace;

		private bool m_ContextIsSet;
		protected TContext m_Current;

		public TContext Current => m_Current;

		public delegate void OnAttachDelegate(TContext context, EventBinder binder);
		public delegate void OnDetachDelegate();
		public delegate void OnReplaceDelegate(TContext newContext, EventBinder binder, TContext oldContext);

		public ContextHandler(OnAttachDelegate onAttach, OnDetachDelegate onDetach, OnReplaceDelegate onReplace)
		{
			m_OnAttach = onAttach;
			m_OnDetach = onDetach;
			m_OnReplace = onReplace;
		}

		public void ClearContext()
		{
			if(m_ContextIsSet)
			{
				m_ContextIsSet = false;
				m_Current = default;
				m_OnDetach();
				m_ContextBinder.UnbindAll();
			}
		}

		public void SetContext(TContext context)
		{
			if(m_ContextIsSet)
			{
				m_ContextBinder.UnbindAll();

				TContext oldContext = m_Current;
				m_Current = context;
				if(m_OnReplace != null)
				{
					m_OnReplace(m_Current, m_ContextBinder, oldContext);
				}
			}
			else
			{
				m_ContextIsSet = true;
				m_Current = context;
				m_OnAttach(m_Current, m_ContextBinder);
			}
		}
	}
}
