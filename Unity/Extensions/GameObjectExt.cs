using System.Collections.Generic;
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

		public static void DestroyAll(this List<GameObject> list)
		{
			int count = list.Count;
			for(int x = 0; x < count; ++x)
			{
				GameObject target = list[x];
				Object.DestroyImmediate(target);
			}
			list.Clear();
		}

		public static void DestroyAll<T>(this List<T> list)
			where T : Component
		{
			int count = list.Count;
			for(int x = 0; x < count; ++x)
			{
				T target = list[x];
				Object.DestroyImmediate(target.gameObject);
			}
			list.Clear();
		}
	}
}
