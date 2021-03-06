using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	public class UIAspectRatioConstraint: AAspectRatioConstraint
	{
		private RectTransform m_Target = null;
		private Canvas m_Canvas = null;

		private void Awake()
		{
			m_Target = GetComponent<RectTransform>();
			m_Canvas = GetComponentInParent<Canvas>();
		}

		protected override Vector2 GetAvailableSpace()
		{
			return new Vector2(Screen.width, Screen.height);
		}

		protected override void SetSize(float width, float height)
		{
			m_Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
			m_Target.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		}
	}
}
