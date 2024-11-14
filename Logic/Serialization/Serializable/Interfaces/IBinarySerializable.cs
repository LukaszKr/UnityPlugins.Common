namespace UnityPlugins.Common.Logic
{
	public interface IBinarySerializable
	{
		void WriteToBuffer(FastBinaryWriter writer);
	}
}
