using System;
using System.Diagnostics;

namespace UnityPlugins.Common.Logic
{
	[Serializable]
	public struct GridPoint3D : IEquatable<GridPoint3D>
	{
		public int X;
		public int Y;
		public int Z;

		public static bool operator ==(GridPoint3D l, GridPoint3D r) => l.Equals(r);
		public static bool operator !=(GridPoint3D l, GridPoint3D r) => !l.Equals(r);

		[DebuggerStepThrough]
		public GridPoint3D(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		[DebuggerStepThrough]
		public GridPoint3D(GridSize3D size)
		{
			X = size.X;
			Y = size.Y;
			Z = size.Z;
		}

		public int Get(EGridAxis3D axis)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return X;
				case EGridAxis3D.Y:
					return Y;
				case EGridAxis3D.Z:
					return Z;
				default:
					throw new NotImplementedException(axis.ToString());
			}
		}

		public GridPoint3D Set(EGridAxis3D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return new GridPoint3D(value, Y, Z);
				case EGridAxis3D.Y:
					return new GridPoint3D(X, value, Z);
				case EGridAxis3D.Z:
					return new GridPoint3D(X, Y, value);
				default:
					throw new NotImplementedException(axis.ToString());
			}
		}

		public GridPoint3D Add(GridPoint3D point)
		{
			return new GridPoint3D(X+point.X, Y+point.Y, Z+point.Z);
		}

		public GridPoint3D Subtract(GridPoint3D point)
		{
			return new GridPoint3D(X-point.X, Y-point.Y, Z-point.Z);
		}

		public GridPoint3D Min(GridPoint3D other)
		{
			return new GridPoint3D(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z));
		}

		public GridPoint3D Max(GridPoint3D other)
		{
			return new GridPoint3D(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z));
		}

		public GridPoint3D Translate(EGridCardinal3D direction, int distance = 1)
		{
			switch(direction)
			{
				case EGridCardinal3D.Up:
					return new GridPoint3D(X, Y+distance, Z);
				case EGridCardinal3D.Right:
					return new GridPoint3D(X+distance, Y, Z);
				case EGridCardinal3D.Down:
					return new GridPoint3D(X, Y-distance, Z);
				case EGridCardinal3D.Left:
					return new GridPoint3D(X-distance, Y, Z);
				case EGridCardinal3D.Front:
					return new GridPoint3D(X, Y, Z+distance);
				case EGridCardinal3D.Back:
					return new GridPoint3D(X, Y, Z-distance);
				default:
					throw new NotImplementedException($"{direction}");
			}
		}

		public GridPoint3D Translate(EGridAxis3D axis, int distance)
		{
			switch(axis)
			{
				case EGridAxis3D.X:
					return new GridPoint3D(X+distance, Y, Z);
				case EGridAxis3D.Y:
					return new GridPoint3D(X, Y+distance, Z);
				case EGridAxis3D.Z:
					return new GridPoint3D(X, Y, Z+distance);
				default:
					throw new NotImplementedException($"{axis}");
			}
		}

		public override bool Equals(object obj)
		{
			if(obj is GridPoint3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridPoint3D other)
		{
			return X == other.X && Y == other.Y && Z == other.Z;
		}

		public override int GetHashCode()
		{
			return X + (Y << 10) + (Z << 20);
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})";
		}
	}
}
