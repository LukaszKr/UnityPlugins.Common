using System;
using System.Diagnostics;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridSize2D : IEquatable<GridSize2D>, IBinarySerializable
	{
		public readonly byte X;
		public readonly byte Y;

		public static bool operator ==(GridSize2D l, GridSize2D r) => l.Equals(r);
		public static bool operator !=(GridSize2D l, GridSize2D r) => !l.Equals(r);

		[DebuggerStepThrough]
		public GridSize2D(int x, int y)
		{
			X = (byte)x;
			Y = (byte)y;
		}

		public GridSize2D(FastBinaryReader reader)
		{
			X = reader.ReadByte();
			Y = reader.ReadByte();
		}

		public void WriteToBuffer(FastBinaryWriter writer)
		{
			writer.Write(X);
			writer.Write(Y);
		}

		public int Get(EGridAxis2D axis)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return X;
				case EGridAxis2D.Y:
					return Y;
				default:
					throw new NotImplementedException(axis.ToString());
			}
		}

		public GridSize2D Min(GridSize2D other)
		{
			return new GridSize2D(Math.Min(X, other.X), Math.Min(Y, other.Y));
		}

		public GridSize2D Max(GridSize2D other)
		{
			return new GridSize2D(Math.Max(X, other.X), Math.Max(Y, other.Y));
		}

		public bool Contains(int x, int y)
		{
			return x < X && y < Y
				&& x >= 0 && y >= 0;
		}

		public bool Contains(GridPoint2D point)
		{
			return point.X < X && point.Y < Y
				&& point.X >= 0 && point.Y >= 0;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridSize2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridSize2D other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			return X + (Y << 16);
		}

		public override string ToString()
		{
			return $"({X}, {Y})";
		}
	}
}
