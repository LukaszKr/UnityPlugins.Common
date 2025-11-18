using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class GridPoint3DUnityExt
	{
		public static Vector3 ToVector3(this GridPoint3D point)
		{
			Vector3 v = default;
			v.x = point.X;
			v.y = point.Y;
			v.z = point.Z;
			return v;
		}

		public static Vector3 ToGridVector3(this GridPoint3D point)
		{
			Vector3 v = default;
			v.x = point.X+0.5f;
			v.y = point.Y+0.5f;
			v.z = point.Z+0.5f;
			return v;
		}

		public static Vector3Int ToVector3Int(this GridPoint3D point)
		{
			Vector3Int v = default;
			v.x = point.X;
			v.y = point.Y;
			v.z = point.Z;
			return v;
		}

		public static GridPoint3D ToGridPoint3D(this Vector3Int vec)
		{
			return new GridPoint3D(vec.x, vec.y, vec.z);
		}
	}
}
