namespace UnityPlugins.Common.Logic
{
	public abstract class AContextClass<TContext>
	{
		private readonly ContextHandler<TContext> m_ContextHandler;
		protected TContext m_Context;

		public AContextClass()
		{
			m_ContextHandler = new ContextHandler<TContext>(OnAttach, OnDetach, OnReplace);
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

		protected virtual void OnReplace(TContext context, EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(context, binder);
		}
	}
}
