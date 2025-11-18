using System;

namespace UnityPlugins.Common.Logic
{
	public enum EGridAxis3D : byte
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	public static class EGridAxis3DExt
	{
		public static EnumExt<EGridAxis3D> Meta = new EnumExt<EGridAxis3D>();

		static EGridAxis3DExt()
		{
			m_GridPlanes = new GridPlane3D[Meta.Values.Length];

			for(int x = 0; x < m_GridPlanes.Length; ++x)
			{
				m_GridPlanes[x] = new GridPlane3D(Meta.Values[x]);
			}
		}

		public static EGridAxis3D ReadEGridAxis3D(this FastBinaryReader reader)
		{
			return (EGridAxis3D)reader.ReadByte();
		}

		public static void Write(this FastBinaryWriter writer, EGridAxis3D axis)
		{
			writer.Write((byte)axis);
		}

		#region GetThird
		public static EGridAxis3D GetThird(this EGridAxis3D axisA, EGridAxis3D axisB)
		{
			int value = (int)axisA+(int)axisB;
			switch(value)
			{
				case 1:
					return EGridAxis3D.Z;
				case 2:
					return EGridAxis3D.Y;
				case 3:
					return EGridAxis3D.X;
				default:
					throw new NotSupportedException($"{axisA}:{axisB}");
			}
		}
		#endregion

		#region Iterator
		private static readonly GridPoint3D[] m_Iterator = new GridPoint3D[]
		{
			new GridPoint3D(1, 0, 0),
			new GridPoint3D(0, 1, 0),
			new GridPoint3D(0, 0, 1),
		};

		public static GridPoint3D GetIterator(this EGridAxis3D axis)
		{
			return m_Iterator[(int)axis];
		}
		#endregion

		#region ToGridCardinals
		private static readonly EGridCardinal3D[][] m_GridCardinals = new EGridCardinal3D[][]
		{
			new EGridCardinal3D[] { EGridCardinal3D.Right, EGridCardinal3D.Left },
			new EGridCardinal3D[] { EGridCardinal3D.Up, EGridCardinal3D.Down },
			new EGridCardinal3D[] { EGridCardinal3D.Front, EGridCardinal3D.Back }
		};

		public static EGridCardinal3D[] ToGridCardinals(this EGridAxis3D axis)
		{
			return m_GridCardinals[(int)axis];
		}
		#endregion

		#region ToPlane
		private static readonly GridPlane3D[] m_GridPlanes;

		public static GridPlane3D ToGridPlanet3D(this EGridAxis3D axis)
		{
			return m_GridPlanes[(int)axis];
		}
		#endregion
	}
}
