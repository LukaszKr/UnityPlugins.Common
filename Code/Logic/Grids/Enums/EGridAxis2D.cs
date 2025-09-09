namespace UnityPlugins.Common.Logic
{
	public enum EGridAxis2D : byte
	{
		X = 0,
		Y = 1,
	}

	public static class EGridAxis2DExt
	{
		public static EnumExt<EGridAxis2D> Meta = new EnumExt<EGridAxis2D>();

		public static EGridAxis2D ReadEGridAxis2D(this FastBinaryReader reader)
		{
			return (EGridAxis2D)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EGridAxis2D axis)
		{
			writer.Write((byte)axis);
		}

		public static EGridAxis2D GetOther(this EGridAxis2D axis)
		{
			if(axis == EGridAxis2D.X)
			{
				return EGridAxis2D.Y;
			}
			return EGridAxis2D.X;
		}

		#region Iterator
		private static readonly GridPoint2D[] m_Iterator = new GridPoint2D[]
		{
			new GridPoint2D(1, 0),
			new GridPoint2D(0, 1)
		};

		public static GridPoint2D GetIterator(this EGridAxis2D axis)
		{
			return m_Iterator[(int)axis];
		}
		#endregion

		#region ToGridCardinals
		private static readonly EGridCardinal2D[][] m_GridCardinals = new EGridCardinal2D[][]
		{
			new EGridCardinal2D[] { EGridCardinal2D.Right, EGridCardinal2D.Left },
			new EGridCardinal2D[] { EGridCardinal2D.Up, EGridCardinal2D.Down },
		};

		public static EGridCardinal2D[] ToGridCardinals(this EGridAxis2D axis)
		{
			return m_GridCardinals[(int)axis];
		}
		#endregion
	}
}
