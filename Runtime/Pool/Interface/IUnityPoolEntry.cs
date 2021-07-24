namespace ProceduralLevel.UnityPlugins.Common.Pool
{
	public interface IUnityPoolEntry
	{
		void OnGetFromPool();
		void OnReturnToPool();
	}
}
