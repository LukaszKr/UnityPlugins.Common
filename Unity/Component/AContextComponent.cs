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

		public void SetContext(TContext context)
		{
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
					OnReplace(m_ContextBinder, oldContext, context);
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

		protected virtual void OnReplace(EventBinder binder, TContext oldContext, TContext newContext)
		{
			OnDetach();
			OnAttach(binder);
		}

		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();
	}
}
