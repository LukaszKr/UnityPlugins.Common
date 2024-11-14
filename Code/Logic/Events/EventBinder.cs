using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public partial class EventBinder
	{
		private List<IEventBinding> m_Bindings;

		public bool IsDisabled { get; private set; }

		public int Count => m_Bindings.Count;

		public EventBinder()
		{
			m_Bindings = new List<IEventBinding>();
		}

		~EventBinder()
		{
			UnbindAll();
		}

		private void AddBinding(IEventBinding binding)
		{
			if(!IsDisabled)
			{
				binding.Bind();
			}
			m_Bindings.Add(binding);
		}

		public void UnbindAll()
		{
			if(!IsDisabled)
			{
				for(int x = 0; x < m_Bindings.Count; x++)
				{
					m_Bindings[x].Unbind();
				}
			}
			m_Bindings.Clear();
		}

		public void Disable()
		{
			if(!IsDisabled)
			{
				IsDisabled = true;
				for(int x = 0; x < m_Bindings.Count; x++)
				{
					m_Bindings[x].Unbind();
				}
			}
		}

		public void Enable()
		{
			if(IsDisabled)
			{
				IsDisabled = false;
				for(int x = 0; x < m_Bindings.Count; x++)
				{
					m_Bindings[x].Bind();
				}
			}
		}

		public void Enable(bool enable)
		{
			if(enable)
			{
				Enable();
			}
			else
			{
				Disable();
			}
		}

		public override string ToString()
		{
			return string.Format("[EventBinder, Disabled: {0}", IsDisabled);
		}
	}
}
