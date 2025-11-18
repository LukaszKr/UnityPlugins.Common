using System;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridHit2D : IEquatable<GridHit2D>
	{
		public readonly GridPoint2D Position;
		public readonly EGridCardinal2D Face;

		public static bool operator ==(GridHit2D l, GridHit2D r) => l.Equals(r);
		public static bool operator !=(GridHit2D l, GridHit2D r) => !l.Equals(r);

		public GridHit2D(int x, int y, EGridCardinal2D face)
		{
			Position = new GridPoint2D(x, y);
			Face = face;
		}

		public GridHit2D(GridPoint2D position, EGridCardinal2D face)
		{
			Position = position;
			Face = face;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridHit2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridHit2D other)
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
