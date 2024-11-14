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
			m_ContextHandler = new ContextHandler<TContext>(OnAttach, OnDetach, OnReplace);
		}

		public void SetContext(TContext context)
		{
			if(!m_IsInitialized)
			{
				m_IsInitialized = true;
				OnInitialize();
			}

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

		protected virtual void OnReplace(TContext context, EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(context, binder);
		}
	}
}
