using ProceduralLevel.Common.Grid;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public static class GridSize3DUnityExt
	{
		public static Vector3 ToVector3(this GridSize3D size)
		{
			return new Vector3(size.X, size.Y, size.Z);
		}

		public static Bounds ToUnityBounds(this GridBounds3D bounds)
		{
			GridSize3D size = bounds.Size;
			Vector3 center = new Vector3(bounds.Min.X+size.X*0.5f, bounds.Min.Y+size.Y*0.5f, bounds.Min.Z+size.Z*0.5f);
			return new Bounds(center, bounds.Size.ToVector3());
		}
	}
}
