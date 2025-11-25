using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class GridPoint2DUnityExt
	{
		public static Vector2 ToVector2(this GridPoint2D point)
		{
			Vector2 v = default;
			v.x = point.X;
			v.y = point.Y;
			return v;
		}

		public static Vector2Int ToVector2Int(this GridPoint2D point)
		{
			Vector2Int v = default;
			v.x = point.X;
			v.y = point.Y;
			return v;
		}

		public static Vector3 ToVector3(this GridPoint2D point)
		{
			Vector3 v = default;
			v.x = point.X;
			v.y = 0;
			v.z = -point.Y;
			return v;
		}

		public static GridPoint2D ToGridPoint2D(this Vector2Int vec)
		{
			return new GridPoint2D(vec.x, vec.y);
		}

		#region Hex
		private static readonly float m_Sqrt3 = Mathf.Sqrt(3)*0.5f;
		private static readonly float m_Sqrt3_Half = m_Sqrt3*0.5f;
		private static readonly float m_HexSpacing = 0.75f;

		public static Vector3 ToPointyHexVector3(this GridPoint2D point)
		{
			float horizontalSpacing = point.X * m_Sqrt3;
			float verticalSpacing = point.Y*m_HexSpacing;
			if((point.Y & 1) == 1)
			{
				return new Vector3(horizontalSpacing + m_Sqrt3_Half, 0, -verticalSpacing);
			}
			return new Vector3(horizontalSpacing, 0, -verticalSpacing);
		}

		public static Vector3 ToFlatHexVector3(this GridPoint2D point)
		{
			float verticalSpacing = point.X * m_Sqrt3;
			float horizontalSpacing = point.Y*m_HexSpacing;
			if((point.Y & 1) == 1)
			{
				return new Vector3(horizontalSpacing + m_Sqrt3_Half, 0, -verticalSpacing);
			}
			return new Vector3(horizontalSpacing, 0, -verticalSpacing);
		}
		#endregion
	}
}
