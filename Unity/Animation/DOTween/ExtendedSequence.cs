#if DOTWEEN
using System;
using System.Collections;
using DG.Tweening;

namespace UnityPlugins.Common.Unity
{
	public class ExtendedSequence
	{
		private Sequence m_Sequence;
		private Action m_OnFinished;

		public bool IsActive => m_Sequence != null;

		public Sequence Start(Action onFinished = null, bool completePrevious = false)
		{
			Kill(completePrevious);
			m_OnFinished = onFinished;

			m_Sequence = DOTween.Sequence();
			m_Sequence.OnComplete(OnCompletedHandler);
			return m_Sequence;
		}

		public void Kill(bool complete = false)
		{
			if(m_Sequence != null)
			{
				m_Sequence.Kill(complete);
				m_Sequence = null;
			}
		}

		/// <summary>
		/// For use in coroutines.
		/// </summary>
		public IEnumerator WaitUntilFinished()
		{
			while(IsActive)
			{
				yield return null;
			}
		}

		#region Callbacks
		private void OnCompletedHandler()
		{
			m_Sequence = null;
			if(m_OnFinished != null)
			{
				m_OnFinished();
			}
		}
		#endregion
	}
}
#endif
