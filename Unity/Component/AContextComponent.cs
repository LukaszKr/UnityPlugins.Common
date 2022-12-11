using ProceduralLevel.Common.Context;
using ProceduralLevel.Common.Event;
using ProceduralLevel.UnityPlugins.Common.Unity.Extended;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public abstract class AContextComponent<TContext> : ExtendedMonoBehaviour
		where TContext : class
	{
		private ContextClass<TContext> m_Context;

		public TContext Context => m_Context?.Context;

		public void SetContext(TContext newContext)
		{
			if(m_Context == null)
			{
				m_Context = new ContextClass<TContext>(OnAttach, OnDetach, OnReplace);
			}

			m_Context.SetContext(newContext);
		}

		protected virtual void OnReplace(EventBinder binder, TContext oldContext, TContext newContext)
		{
			OnDetach();
			OnAttach(binder, newContext);
		}

		protected abstract void OnAttach(EventBinder binder, TContext context);
		protected abstract void OnDetach();
	}
}
