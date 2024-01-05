namespace ProceduralLevel.Common.Logic
{
	public interface IUnique<TValue>
		where TValue : class
	{
		UGuid<TValue> GetID();
	}
}
