using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public abstract class AContextComponent<TContext> : ExtendedMonoBehaviour
	{
		private readonly ContextHandler<TContext> m_ContextHandler;
		private bool m_IsInitialized;
		protected TContext m_Context;

		public AContextComponent()
		{
			m_ContextHandler = new ContextHandler<TContext>(OnAttach, OnDetach, Replace);
		}

		public void TryInitialize()
		{
			if(!m_IsInitialized)
			{
				m_IsInitialized = true;
				OnInitialize();
			}
		}

		public void SetContext(TContext context)
		{
			TryInitialize();
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

		protected abstract void OnInitialize();
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
