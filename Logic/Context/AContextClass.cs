namespace UnityPlugins.Common.Logic
{
	public abstract class AContextClass<TContext> : IContextClass
	{
		private readonly ContextHandler<TContext> m_ContextHandler;
		protected TContext m_Context;

		public AContextClass()
		{
			m_ContextHandler = new ContextHandler<TContext>(OnAttach, OnDetach, Replace);
		}

		public void SetContext(TContext context)
		{
			m_ContextHandler.SetContext(context);
		}

		public void ClearContext()
		{
			m_ContextHandler.ClearContext();
		}

		private void OnAttach(TContext context, EventBinder binder)
		{
			m_Context = context;
			OnAttach(binder);
		}

		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();

		private void Replace(TContext newContext, EventBinder binder, TContext oldContext)
		{
			m_Context = newContext;
			OnReplace(binder, oldContext);
		}

		protected virtual void OnReplace(EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(m_Context, binder);
		}
	}
}
