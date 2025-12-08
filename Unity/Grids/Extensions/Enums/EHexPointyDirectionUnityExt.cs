using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class EHexPointyDirectionUnityExt
	{
		private static readonly float[] m_Rotations = new float[] //assuming right is the default - easier to work with
		{
			-60f,
			0f,
			60f,
			120f,
			180f,
			240f,
		};

		public static float ToRotation(this EHexPointyDirection direction)
		{
			return m_Rotations[(int)direction];
		}
	}
}
