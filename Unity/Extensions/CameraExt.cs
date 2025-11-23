using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public static class CameraExt
	{
		public static bool Raycast<TComponent>(this Camera camera, out TComponent result, Vector2 screenPoint, int layerMask, float maxDistance = 1000f)
			where TComponent : Object
		{
			result = camera.Raycast<TComponent>(screenPoint, layerMask, maxDistance);
			return result != null;
		}

		public static TComponent Raycast<TComponent>(this Camera camera, Vector2 screenPoint, int layerMask, float maxDistance = 1000f)
			where TComponent : Object
		{
			Ray ray = camera.ScreenPointToRay(screenPoint);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, maxDistance, layerMask))
			{
				TComponent result = hit.transform.GetComponent<TComponent>();
				return result;
			}
			return null;
		}
	}
}
