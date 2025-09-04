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

		public static Vector3 ToGridVector2(this GridPoint2D point)
		{
			Vector2 v = default;
			v.x = point.X+0.5f;
			v.y = point.Y+0.5f;
			return v;
		}

		public static Vector2Int ToVector2Int(this GridPoint2D point)
		{
			Vector2Int v = default;
			v.x = point.X;
			v.y = point.Y;
			return v;
		}

		public static GridPoint2D ToGridPoint2D(this Vector2Int vec)
		{
			return new GridPoint2D(vec.x, vec.y);
		}
	}
}
