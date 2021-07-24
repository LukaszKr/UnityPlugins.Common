using ProceduralLevel.UnityPlugins.Common.Extended;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Pool
{
	public abstract class AUnityPoolManager : ExtendedMonoBehaviour
	{
		public UnityPool<TEntry> CreatePool<TEntry>(TEntry prefab, int initialCapacity, EUnityPoolOptions options)
			where TEntry : ExtendedMonoBehaviour, IUnityPoolEntry
		{
			GameObject parent = new GameObject();
			Transform parentTransform = parent.transform;
			parentTransform.SetParent(Transform, false);
#if UNITY_EDITOR
			parent.name = string.Format("{0}_Pool", typeof(TEntry).Name);
#endif
			UnityPool<TEntry> pool = new UnityPool<TEntry>(parentTransform, prefab, initialCapacity, options);
			pool.Prefill();
			return pool;
		}
	}
}
