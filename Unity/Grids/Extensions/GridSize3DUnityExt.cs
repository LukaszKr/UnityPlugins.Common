using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class GridSize3DUnityExt
	{
		public static Vector3 ToVector3(this GridSize3D size)
		{
			Vector3 vec = default;
			vec.x = size.X;
			vec.y = size.Y;
			vec.z = size.Z;
			return vec;
		}

		public static Vector3Int ToVector3Int(this GridSize3D size)
		{
			Vector3Int vec = default;
			vec.x = size.X;
			vec.y = size.Y;
			vec.z = size.Z;
			return vec;
		}
	}
}
