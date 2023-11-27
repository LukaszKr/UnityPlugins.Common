using ProceduralLevel.Common.Event;
using ProceduralLevel.Common.Unity.Extended;

namespace ProceduralLevel.Common.Unity
{
	public abstract class AContextComponent<TContext> : ExtendedMonoBehaviour
	{
		protected TContext m_Context;
		private readonly EventBinder m_ContextBinder = new EventBinder();

		private bool m_ContextIsSet;
		private bool m_Initialized;

		private void Awake()
		{
			if(!m_ContextIsSet)
			{
				GameObject.SetActive(false);
				DisableContextObject();
			}
		}

		public void ClearContext()
		{
			if(m_ContextIsSet)
			{
				m_ContextIsSet = false;
				m_Context = default;
				m_ContextBinder.UnbindAll();
				OnDetach();
				DisableContextObject();
			}
		}

		public void SetContext(TContext context)
		{
			if(!m_Initialized)
			{
				OnInitialize();
				m_Initialized = true;
			}

			m_ContextBinder.UnbindAll();

			if(m_ContextIsSet)
			{
				TContext oldContext = m_Context;
				m_Context = context;
				OnReplace(m_ContextBinder, oldContext);
			}
			else
			{
				m_ContextIsSet = true;
				m_Context = context;
				OnAttach(m_ContextBinder);
			}
			EnableContextObject();
		}

		protected virtual void OnReplace(EventBinder binder, TContext oldContext)
		{
			OnDetach();
			OnAttach(binder);
		}

		protected abstract void OnInitialize();
		protected abstract void OnAttach(EventBinder binder);
		protected abstract void OnDetach();

		protected virtual void DisableContextObject()
		{
			GameObject.SetActive(false);
		}

		protected virtual void EnableContextObject()
		{
			GameObject.SetActive(true);
		}
	}
}
