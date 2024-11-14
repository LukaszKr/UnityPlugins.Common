namespace UnityPlugins.Common.Logic
{
	public static class BinaryExt
	{
		public static byte[] WriteToByteArray(this IBinarySerializable serializable, FastBinaryWriter writer)
		{
			serializable.WriteToBuffer(writer);
			byte[] bytes = writer.GetBytes();
			writer.Clear();
			return bytes;
		}

		#region Array
		public static FastBinaryReader ToBinaryReader(this byte[] array)
		{
			return new FastBinaryReader(array);
		}
		#endregion
	}
}
