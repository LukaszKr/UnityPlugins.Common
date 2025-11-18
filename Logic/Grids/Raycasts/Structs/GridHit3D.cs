using System;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridHit3D : IEquatable<GridHit3D>
	{
		public readonly GridPoint3D Position;
		public readonly EGridCardinal3D Face;

		public static bool operator ==(GridHit3D l, GridHit3D r) => l.Equals(r);
		public static bool operator !=(GridHit3D l, GridHit3D r) => !l.Equals(r);

		public GridHit3D(int x, int y, int z, EGridCardinal3D face)
		{
			Position = new GridPoint3D(x, y, z);
			Face = face;
		}

		public GridHit3D(GridPoint3D position, EGridCardinal3D face)
		{
			Position = position;
			Face = face;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridHit3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridHit3D other)
		{
			return (Face == other.Face && Position.Equals(other.Position));
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Face.GetHashCode(), Position.GetHashCode());
		}

		public override string ToString()
		{
			return $"({Position}, {Face})";
		}
	}
}
