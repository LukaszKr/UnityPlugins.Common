namespace UnityPlugins.Common.Logic
{
	public enum EGridDirection2D : byte
	{
		Up = 0,
		UpRight = 1,
		Right = 2,
		DownRight = 3,
		Down = 4,
		DownLeft = 5,
		Left = 6,
		UpLeft = 7
	}

	public static class EGridDirection2DExt
	{
		public static readonly EnumExt<EGridDirection2D> Meta = new EnumExt<EGridDirection2D>();

		public static EGridDirection2D ReadEGridDirection2D(this FastBinaryReader reader)
		{
			return (EGridDirection2D)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EGridDirection2D direction)
		{
			writer.Write((byte)direction);
		}

		#region Iterator
		private static readonly GridPoint2D[] m_Iterator = new GridPoint2D[]
		{
			new GridPoint2D(0, -1),
			new GridPoint2D(1, -1),
			new GridPoint2D(1, 0),
			new GridPoint2D(1, 1),
			new GridPoint2D(0, 1),
			new GridPoint2D(-1, 1),
			new GridPoint2D(-1, 0),
			new GridPoint2D(-1, -1)
		};

		public static GridPoint2D GetIterator(this EGridDirection2D direction)
		{
			return m_Iterator[(int)direction];
		}
		#endregion

		#region GetOpposite
		private static readonly EGridDirection2D[] m_Opposite = new EGridDirection2D[]
		{
			EGridDirection2D.Down,
			EGridDirection2D.DownLeft,
			EGridDirection2D.Left,
			EGridDirection2D.UpLeft,
			EGridDirection2D.Up,
			EGridDirection2D.UpRight,
			EGridDirection2D.Right,
			EGridDirection2D.DownRight
		};

		public static EGridDirection2D GetOpposite(this EGridDirection2D direction)
		{
			return m_Opposite[(int)direction];
		}
		#endregion

		#region GetClockwise
		private static readonly EGridDirection2D[] m_Clockwise = new EGridDirection2D[]
		{
			EGridDirection2D.UpRight,
			EGridDirection2D.Right,
			EGridDirection2D.DownRight,
			EGridDirection2D.Down,
			EGridDirection2D.DownLeft,
			EGridDirection2D.Left,
			EGridDirection2D.UpLeft,
			EGridDirection2D.Up
		};

		public static EGridDirection2D GetClockwise(this EGridDirection2D direction)
		{
			return m_Clockwise[(int)direction];
		}
		#endregion

		#region GetCounterClockwise
		private static readonly EGridDirection2D[] m_CounterClockwise = new EGridDirection2D[]
		{
			EGridDirection2D.UpLeft,
			EGridDirection2D.Up,
			EGridDirection2D.UpRight,
			EGridDirection2D.Right,
			EGridDirection2D.DownRight,
			EGridDirection2D.Down,
			EGridDirection2D.DownLeft,
			EGridDirection2D.Left
		};

		public static EGridDirection2D GetCounterClockwise(this EGridDirection2D direction)
		{
			return m_CounterClockwise[(int)direction];
		}
		#endregion
	}
}
