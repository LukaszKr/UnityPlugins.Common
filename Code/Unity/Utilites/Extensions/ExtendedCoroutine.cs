using System.Collections;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public class ExtendedCoroutine
	{
		private MonoBehaviour m_Parent;
		private Coroutine m_Current;

		public bool IsActive => (m_Current != null);

		~ExtendedCoroutine()
		{
			Kill();
		}

		public void Start(MonoBehaviour parent, IEnumerator coroutine)
		{
			Kill();
			m_Parent = parent;
			m_Current = parent.StartCoroutine(CoroutineWrapper(coroutine));
		}

		public void Kill()
		{
			if(m_Current != null)
			{
				if(m_Parent)
				{
					m_Parent.StopCoroutine(m_Current);
				}
				m_Current = null;
			}
		}

		private IEnumerator CoroutineWrapper(IEnumerator coroutine)
		{
			yield return coroutine;
			m_Current = null;
		}
	}
}
