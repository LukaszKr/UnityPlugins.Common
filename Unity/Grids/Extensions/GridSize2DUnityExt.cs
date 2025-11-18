using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class GridSize2DUnityExt
	{
		public static Vector2 ToVector2(this GridSize2D size)
		{
			Vector2 vec = default;
			vec.x = size.X;
			vec.y = size.Y;
			return vec;
		}

		public static Vector2Int ToVector3Int(this GridSize2D size)
		{
			Vector2Int vec = default;
			vec.x = size.X;
			vec.y = size.Y;
			return vec;
		}
	}
}
