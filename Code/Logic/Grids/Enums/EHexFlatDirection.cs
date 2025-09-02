namespace UnityPlugins.Common.Logic
{
	public enum EHexFlatDirection : byte
	{
		Up = 0,
		UpRight = 1,
		DownRight = 2,
		Down = 3,
		DownLeft = 4,
		UpLeft = 5
	}

	public static class EHexFlatDirectionExt
	{
		public static readonly EnumExt<EHexFlatDirection> Meta = new EnumExt<EHexFlatDirection>();

		public static EHexFlatDirection ReadHexFlatDirection(this FastBinaryReader reader)
		{
			return (EHexFlatDirection)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EHexFlatDirection direction)
		{
			writer.Write((byte)direction);
		}

		#region GetOpposite
		private static EHexFlatDirection[] m_GetOpposite = new EHexFlatDirection[]
		{
			EHexFlatDirection.Down,
			EHexFlatDirection.DownLeft,
			EHexFlatDirection.UpLeft,
			EHexFlatDirection.Up,
			EHexFlatDirection.UpRight,
			EHexFlatDirection.DownRight
		};

		public static EHexFlatDirection GetOpposite(this EHexFlatDirection direction)
		{
			return m_GetOpposite[(int)direction];
		}
		#endregion

		#region GetClockwise
		private static EHexFlatDirection[] m_GetClockwise = new EHexFlatDirection[]
		{
			EHexFlatDirection.UpRight,
			EHexFlatDirection.DownRight,
			EHexFlatDirection.Down,
			EHexFlatDirection.DownLeft,
			EHexFlatDirection.UpLeft,
			EHexFlatDirection.Up
		};

		public static EHexFlatDirection GetClockwise(this EHexFlatDirection direction)
		{
			return m_GetClockwise[(int)direction];
		}
		#endregion

		#region GetCounterClockwise
		private static EHexFlatDirection[] m_GetCounterClockwise = new EHexFlatDirection[]
		{
			EHexFlatDirection.UpLeft,
			EHexFlatDirection.Up,
			EHexFlatDirection.UpRight,
			EHexFlatDirection.DownRight,
			EHexFlatDirection.Down,
			EHexFlatDirection.DownLeft,
		};

		public static EHexFlatDirection GetCounterClockwise(this EHexFlatDirection direction)
		{
			return m_GetCounterClockwise[(int)direction];
		}
		#endregion
	}
}
