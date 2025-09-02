using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridSize3D : IEquatable<GridSize3D>, IBinarySerializable
	{
		public readonly byte X;
		public readonly byte Y;
		public readonly byte Z;

		public static bool operator ==(GridSize3D l, GridSize3D r) => l.Equals(r);
		public static bool operator !=(GridSize3D l, GridSize3D r) => !l.Equals(r);

		[DebuggerStepThrough, JsonConstructor]
		public GridSize3D(int x, int y, int z)
		{
			X = (byte)x;
			Y = (byte)y;
			Z = (byte)z;
		}

		public GridSize3D(FastBinaryReader reader)
		{
			X = reader.ReadByte();
			Y = reader.ReadByte();
			Z = reader.ReadByte();
		}

		public void WriteToBuffer(FastBinaryWriter writer)
		{
			writer.Write(X);
			writer.Write(Y);
			writer.Write(Z);
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

		public GridSize3D Min(GridSize3D other)
		{
			return new GridSize3D(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z));
		}

		public GridSize3D Max(GridSize3D other)
		{
			return new GridSize3D(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z));
		}

		public bool Contains(int x, int y, int z)
		{
			return x < X && y < Y && z < Z
				&& x >= 0 && y >= 0 && z >= 0;
		}

		public bool Contains(GridPoint3D point)
		{
			return point.X < X && point.Y < Y && point.Z < Z
				&& point.X >= 0 && point.Y >= 0 && point.Z >= 0;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridSize3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridSize3D other)
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
