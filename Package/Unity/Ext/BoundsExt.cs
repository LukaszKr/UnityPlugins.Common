using ProceduralLevel.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public static class BoundsExt
	{
		public static void GetCorners(this Bounds bounds, Vector3[] corners)
		{
			GameAssert.AreEqual(8, corners.Length);
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;
			Vector3 size = bounds.size;
			corners[0] = min;
			corners[1] = min;
			corners[1].x += size.x;
			corners[2] = min;
			corners[2].y += size.y;
			corners[3] = min;
			corners[3].z += size.z;

			corners[4] = max;
			corners[5] = max;
			corners[5].x -= size.x;
			corners[6] = max;
			corners[6].y -= size.y;
			corners[7] = max;
			corners[7].z -= size.z;
		}
	}
}
