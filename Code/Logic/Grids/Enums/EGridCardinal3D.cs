namespace UnityPlugins.Common.Logic
{
	public enum EGridCardinal3D : byte
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3,
		Front = 4,
		Back = 5,
	}

	public static class EGridCardinal3DExt
	{
		public static readonly EnumExt<EGridCardinal3D> Meta = new EnumExt<EGridCardinal3D>();

		public static EGridCardinal3D ReadEGridCardinal3D(this FastBinaryReader reader)
		{
			return (EGridCardinal3D)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EGridCardinal3D direction)
		{
			writer.Write((byte)direction);
		}

		#region Iterator
		private static readonly GridPoint3D[] m_Iterator = new GridPoint3D[]
		{
			new GridPoint3D(0, 1, 0),
			new GridPoint3D(0, -1, 0),
			new GridPoint3D(-1, 0, 0),
			new GridPoint3D(1, 0, 0),
			new GridPoint3D(0, 0, 1),
			new GridPoint3D(0, 0, -1),
		};

		public static GridPoint3D GetIterator(this EGridCardinal3D direction)
		{
			return m_Iterator[(int)direction];
		}
		#endregion

		#region GetOpposite
		private static readonly EGridCardinal3D[] m_Opposite = new EGridCardinal3D[]
		{
			EGridCardinal3D.Down,
			EGridCardinal3D.Up,
			EGridCardinal3D.Right,
			EGridCardinal3D.Left,
			EGridCardinal3D.Back,
			EGridCardinal3D.Front
		};

		public static EGridCardinal3D GetOpposite(this EGridCardinal3D direction)
		{
			return m_Opposite[(int)direction];
		}
		#endregion

		#region ToAxis
		private static readonly EGridAxis3D[] m_Axis = new EGridAxis3D[]
		{
			EGridAxis3D.Y,
			EGridAxis3D.Y,
			EGridAxis3D.X,
			EGridAxis3D.X,
			EGridAxis3D.Z,
			EGridAxis3D.Z
		};

		public static EGridAxis3D ToAxis(this EGridCardinal3D direction)
		{
			return m_Axis[(int)direction];
		}
		#endregion
	}
}
