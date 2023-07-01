namespace ProceduralLevel.Common.Unity.Pool
{
	public interface IUnityPoolEntry
	{
		void OnGetFromPool();
		void OnReturnToPool();
	}
}
