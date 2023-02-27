using ProceduralLevel.Common.Event;
using ProceduralLevel.UnityPlugins.Common.Unity.Extended;
using System;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public abstract class AContextComponent<TContext> : ExtendedMonoBehaviour
		where TContext : class
	{
		protected TContext m_Context;
		private readonly EventBinder m_ContextBinder = new EventBinder();

		private bool m_Initialized;

		public void SetContext(TContext context)
		{
			if(!m_Initialized)
			{
				OnInitialize();
				m_Initialized = true;
			}

			if(context == m_Context)
			{
				throw new InvalidOperationException();
			}

			m_ContextBinder.UnbindAll();
			TContext oldContext = m_Context;
			m_Context = context;
			if(context != null)
			{
				if(oldContext != null)
				{
					OnReplace(m_ContextBinder, oldContext);
				}
				else
				{
					OnAttach(m_ContextBinder);
				}
			}
			else if(oldContext != null)
			{
				OnDetach();
			}
		}

		protected virtual void OnInitialize()
		{

		}

		protected virtual void OnReplace(EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(binder);
		}

		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();
	}
}
