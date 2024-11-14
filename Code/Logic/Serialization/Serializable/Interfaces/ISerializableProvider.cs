namespace UnityPlugins.Common.Logic
{
	public interface ISerializableProvider<TSerializable>
		where TSerializable : ASerializable
	{
		TSerializable GetSerializable();
	}
}
