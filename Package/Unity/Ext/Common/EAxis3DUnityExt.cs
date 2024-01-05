using ProceduralLevel.Common.Grid;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public static class EAxis3DUnityExt
	{
		private static readonly Vector3[] m_EulerRotations = new Vector3[]
		{
			new Vector3(0, -90, 0), //x
			new Vector3(90, 0, 0), //y
			new Vector3(0, 0, 0), //z
		};

		private static readonly Quaternion[] m_QuaternionRotations;

		static EAxis3DUnityExt()
		{
			m_QuaternionRotations = new Quaternion[m_EulerRotations.Length];
			for(int x = 0; x < m_QuaternionRotations.Length; ++x)
			{
				m_QuaternionRotations[x] = Quaternion.Euler(m_EulerRotations[x]);
			}
		}

		public static Vector3 ToEuler(this EGridAxis3D direction)
		{
			return m_EulerRotations[(int)direction];
		}

		public static Quaternion ToQuaternion(this EGridAxis3D direction)
		{
			return m_QuaternionRotations[(int)direction];
		}
	}
}
