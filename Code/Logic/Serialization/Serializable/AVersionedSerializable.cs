namespace UnityPlugins.Common.Logic
{
	public abstract class AVersionedSerializable : ASerializable
	{
		public readonly int Version;

		protected AVersionedSerializable(int version)
		{
			Version = version;
		}
	}
}
