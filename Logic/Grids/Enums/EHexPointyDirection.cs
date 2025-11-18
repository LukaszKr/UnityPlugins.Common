namespace UnityPlugins.Common.Logic
{
	public enum EHexPointyDirection : byte
	{
		UpRight = 0,
		Right = 1,
		DownRight = 2,
		DownLeft = 3,
		Left = 4,
		UpLeft = 5
	}

	public static class EHexPointyDirectionExt
	{
		public static readonly EnumExt<EHexPointyDirection> Meta = new EnumExt<EHexPointyDirection>();

		public static EHexPointyDirection ReadEHexPointyDirection(this FastBinaryReader reader)
		{
			return (EHexPointyDirection)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EHexPointyDirection direction)
		{
			writer.Write((byte)direction);
		}

		#region GetOpposite
		private static EHexPointyDirection[] m_GetOpposite = new EHexPointyDirection[]
		{
			EHexPointyDirection.DownLeft,
			EHexPointyDirection.Left,
			EHexPointyDirection.UpLeft,
			EHexPointyDirection.UpRight,
			EHexPointyDirection.Right,
			EHexPointyDirection.DownRight
		};

		public static EHexPointyDirection GetOpposite(this EHexPointyDirection direction)
		{
			return m_GetOpposite[(int)direction];
		}
		#endregion

		#region GetClockwise
		private static EHexPointyDirection[] m_GetClockwise = new EHexPointyDirection[]
		{
			EHexPointyDirection.Right,
			EHexPointyDirection.DownRight,
			EHexPointyDirection.DownLeft,
			EHexPointyDirection.Left,
			EHexPointyDirection.UpLeft,
			EHexPointyDirection.UpRight
		};

		public static EHexPointyDirection GetClockwise(this EHexPointyDirection direction)
		{
			return m_GetClockwise[(int)direction];
		}
		#endregion

		#region GetCounterClockwise
		private static EHexPointyDirection[] m_GetCounterClockwise = new EHexPointyDirection[]
		{
			EHexPointyDirection.UpLeft,
			EHexPointyDirection.UpRight,
			EHexPointyDirection.Right,
			EHexPointyDirection.DownRight,
			EHexPointyDirection.DownLeft,
			EHexPointyDirection.Left,
		};

		public static EHexPointyDirection GetCounterClockwise(this EHexPointyDirection direction)
		{
			return m_GetCounterClockwise[(int)direction];
		}
		#endregion
	}
}
