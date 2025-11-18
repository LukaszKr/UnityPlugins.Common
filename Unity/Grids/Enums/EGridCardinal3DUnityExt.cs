using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class EGridCardinal3DUnityExt
	{
		#region ToQuaternion
		private static readonly Quaternion[] m_Quaternions = new Quaternion[]
		{
			Quaternion.Euler(90, 0, 0), //Up
			Quaternion.Euler(-90, 0, 0), //Down
			Quaternion.Euler(0, 90, 0), //Left
			Quaternion.Euler(0, -90, 0), //Right
			Quaternion.Euler(0, 180, 0), //Front
			Quaternion.Euler(0, 0, 0), //Back
		};

		public static Quaternion ToQuaternion(this EGridCardinal3D direction)
		{
			return m_Quaternions[(int)direction];
		}
		#endregion

		#region DebugColor
		private static readonly Color[] m_DebugColors = new Color[]
		{
			new Color(0, 1f, 0), //Up
			new Color(0, 1f, 1f), //Down
			new Color(1f, 1f, 0f), //Left
			new Color(1f, 0, 0), //Right
			new Color(0, 0, 1f), //Front
			new Color(1f, 0, 1f), //Back
		};

		public static Color ToDebugColor(this EGridCardinal3D direction)
		{
			return m_DebugColors[(int)direction];
		}
		#endregion
	}
}
