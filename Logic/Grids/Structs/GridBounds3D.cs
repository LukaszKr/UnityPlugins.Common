using System;
using System.Diagnostics;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridBounds3D : IEquatable<GridBounds3D>
	{
		public readonly GridPoint3D Min;
		public readonly GridPoint3D Max;

		public static bool operator ==(GridBounds3D l, GridBounds3D r) => l.Equals(r);
		public static bool operator !=(GridBounds3D l, GridBounds3D r) => !l.Equals(r);

		[DebuggerStepThrough]
		public GridBounds3D(GridSize3D size)
		{
			Min = default;
			Max = new GridPoint3D(size);
		}

		[DebuggerStepThrough]
		public GridBounds3D(GridPoint3D min, GridPoint3D max)
		{
			Min = min;
			Max = max;
		}

		[DebuggerStepThrough]
		public GridBounds3D(int maxX, int maxY, int maxZ)
		{
			Min = default;
			Max = new GridPoint3D(maxX, maxY, maxZ);
		}

		[DebuggerStepThrough]
		public GridBounds3D(int minX, int minY, int minZ, int maxX, int maxY, int maxZ)
		{
			Min = new GridPoint3D(minX, minY, minZ);
			Max = new GridPoint3D(maxX, maxY, maxZ);
		}

		public GridPoint3D Clamp(GridPoint3D point)
		{
			int x = Math.Clamp(point.X, Min.X, Max.X-1);
			int y = Math.Clamp(point.Y, Min.Y, Max.Y-1);
			int z = Math.Clamp(point.Z, Min.Z, Max.Z-1);
			return new GridPoint3D(x, y, z);
		}

		public bool Contains(int x, int y, int z)
		{
			return x < Max.X && y < Max.Y && z < Max.Z
				&& x >= Min.X && y >= Min.Y && z >= Min.Z;
		}

		public bool Contains(GridPoint3D point)
		{
			return point.X < Max.X && point.Y < Max.Y && point.Z < Max.Z
				&& point.X >= Min.X && point.Y >= Min.Y && point.Z >= Min.Z;
		}
		public bool Contains(GridBounds3D bounds)
		{
			GridPoint3D bMax = bounds.Max;
			return bMax.X <= Max.X && bMax.Y <= Max.Y && bMax.Z <= Max.Z
				&& Contains(bounds.Min);
		}

		public override bool Equals(object obj)
		{
			if(obj is GridBounds3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridBounds3D other)
		{
			return Min == other.Min && Max == other.Max;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Min, Max);
		}

		public override string ToString()
		{
			return $"({nameof(Min)}: {Min}, {nameof(Max)}: {Max})";
		}
	}
}
