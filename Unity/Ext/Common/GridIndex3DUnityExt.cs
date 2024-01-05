using ProceduralLevel.Common.Grid;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public static class GridIndex3DUnityExt
	{
		public static Vector3 ToVector3(this GridIndex3D index)
		{
			return new Vector3(index.X, index.Y, index.Z);
		}

		public static Vector3Int ToVector3Int(this GridIndex3D index)
		{
			return new Vector3Int(index.X, index.Y, index.Z);
		}
	}
}
