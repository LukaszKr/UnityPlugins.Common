namespace UnityPlugins.Common.Logic
{
	public enum EGridCardinal2D : byte
	{
		Up = 0,
		Right = 1,
		Down = 2,
		Left = 3,
	}

	public static class EGridCardinal2DExt
	{
		public static readonly EnumExt<EGridCardinal2D> Meta = new EnumExt<EGridCardinal2D>();

		public static EGridCardinal2D ReadEGridCardinal2D(this FastBinaryReader reader)
		{
			return (EGridCardinal2D)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EGridCardinal2D direction)
		{
			writer.Write((byte)direction);
		}

		#region ToGridDirection
		private static EGridDirection2D[] m_ToGridDirection = new EGridDirection2D[]
		{
			EGridDirection2D.Up,
			EGridDirection2D.Right,
			EGridDirection2D.Down,
			EGridDirection2D.Left
		};

		public static EGridDirection2D ToGridDirection(this EGridCardinal2D cardinal)
		{
			return m_ToGridDirection[(int)cardinal];
		}
		#endregion

		#region Iterator
		private static readonly GridPoint2D[] m_Iterator = new GridPoint2D[]
		{
			new GridPoint2D(0, -1),
			new GridPoint2D(1, 0),
			new GridPoint2D(0, 1),
			new GridPoint2D(-1, 0),
		};

		public static GridPoint2D GetIterator(this EGridCardinal2D direction)
		{
			return m_Iterator[(int)direction];
		}
		#endregion

		#region GetOpposite
		private static readonly EGridCardinal2D[] m_Opposite = new EGridCardinal2D[]
		{
			EGridCardinal2D.Down,
			EGridCardinal2D.Left,
			EGridCardinal2D.Up,
			EGridCardinal2D.Right
		};

		public static EGridCardinal2D GetOpposite(this EGridCardinal2D direction)
		{
			return m_Opposite[(int)direction];
		}
		#endregion

		#region GetClockwise
		private static readonly EGridCardinal2D[] m_Clockwise = new EGridCardinal2D[]
		{
			EGridCardinal2D.Right,
			EGridCardinal2D.Down,
			EGridCardinal2D.Left,
			EGridCardinal2D.Up
		};

		public static EGridCardinal2D GetClockwise(this EGridCardinal2D direction)
		{
			return m_Clockwise[(int)direction];
		}
		#endregion

		#region GetCounterClockwise
		private static readonly EGridCardinal2D[] m_CounterClockwise = new EGridCardinal2D[]
		{
			EGridCardinal2D.Left,
			EGridCardinal2D.Up,
			EGridCardinal2D.Right,
			EGridCardinal2D.Down
		};

		public static EGridCardinal2D GetCounterClockwise(this EGridCardinal2D direction)
		{
			return m_CounterClockwise[(int)direction];
		}
		#endregion

		#region ToAxis
		private static readonly EGridAxis2D[] m_ToAxis = new EGridAxis2D[]
		{
			EGridAxis2D.Y,
			EGridAxis2D.X,
			EGridAxis2D.Y,
			EGridAxis2D.X,
		};

		public static EGridAxis2D ToAxis(this EGridCardinal2D direction)
		{
			return m_ToAxis[(int)direction];
		}
		#endregion
	}
}
