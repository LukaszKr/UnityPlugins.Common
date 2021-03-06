using ProceduralLevel.UnityPlugins.Common.Extended;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	public abstract class AAspectRatioConstraint: ExtendedMonoBehaviour
	{
		private float m_KnownWidth;
		private float m_KnownHeight;

		[SerializeField]
		private AspectRatioConstraintConfig m_Settings = null;

		private void Update()
		{
			Vector2 availableSpace = GetAvailableSpace();
			if(!Mathf.Approximately(m_KnownWidth, availableSpace.x) || !Mathf.Approximately(m_KnownHeight, availableSpace.y))
			{
				Recalculate(availableSpace);
			}
		}

		private void Recalculate(Vector2 availableSpace)
		{
			m_KnownWidth = availableSpace.x;
			m_KnownHeight = availableSpace.y;

			float aspect = m_KnownWidth/m_KnownHeight;

			float minAspect = m_Settings.MinAspect;
			float maxAspect = m_Settings.MaxAspect;

			if(aspect < minAspect)
			{
				float maxHeight = m_KnownWidth/minAspect;
				SetSize(m_KnownWidth, maxHeight);

			}
			else if(aspect > maxAspect)
			{
				float maxWidth = m_KnownHeight*maxAspect;
				SetSize(maxWidth, m_KnownHeight);
			}
		}

		protected abstract Vector2 GetAvailableSpace();
		protected abstract void SetSize(float width, float height);
	}
}
