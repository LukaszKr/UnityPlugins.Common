using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class EHexFlatDirectionUnityExt
	{
		private static readonly float[] m_Rotations = new float[] //assuming up is the default
		{
			0f,
			60f,
			120f,
			180f,
			240f,
			300f,
		};

		public static float ToRotation(this EHexFlatDirection direction)
		{
			return m_Rotations[(int)direction];
		}
	}
}
