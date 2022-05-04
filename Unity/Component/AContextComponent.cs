using ProceduralLevel.Common.Context;
using ProceduralLevel.Common.Event;
using ProceduralLevel.UnityPlugins.Common.Unity.Extended;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public abstract class AContextComponent<TContext> : ExtendedMonoBehaviour
		where TContext : class
	{
		private ContextClass<TContext> m_Context;

		public TContext Context { get { return m_Context?.Value; } }

		public void SetContext(TContext newContext)
		{
			if(m_Context == null)
			{
				m_Context = new ContextClass<TContext>(OnAttach, OnDetach, OnReplace);
			}

			m_Context.SetValue(newContext);
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
