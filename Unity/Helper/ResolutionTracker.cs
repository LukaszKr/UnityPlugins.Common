using ProceduralLevel.Common.Event;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public class ResolutionTracker
	{
		private int m_KnownWidth;
		private int m_KnownHeight;
		private ScreenOrientation m_KnownOrientation;
		private bool m_IsDirty;

		public readonly CustomEvent<int, int> OnResolutionChanged = new CustomEvent<int, int>();

		public void Update()
		{
			if(m_IsDirty)
			{
				m_IsDirty = false;
				OnResolutionChanged.Invoke(m_KnownWidth, m_KnownHeight);
			}

			int width = Screen.width;
			int height = Screen.height;
			ScreenOrientation orientation = Screen.orientation;
			if(m_KnownWidth != width || m_KnownHeight != height || m_KnownOrientation != orientation)
			{
				m_KnownWidth = width;
				m_KnownHeight = height;
				m_KnownOrientation = orientation;
				m_IsDirty = true;
			}
		}
	}
}
