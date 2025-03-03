using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public static class GameObjectExt
	{
		public static void SetLayerToHierarchy(this Transform transform, int layer)
		{
			transform.gameObject.layer = layer;
			int childCount = transform.childCount;
			for(int x = 0; x < childCount; ++x)
			{
				Transform child = transform.GetChild(x);
				child.SetLayerToHierarchy(layer);
			}
		}
	}
}
