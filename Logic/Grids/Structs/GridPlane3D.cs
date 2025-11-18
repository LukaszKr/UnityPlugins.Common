using System;
using System.Diagnostics;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridPlane3D : IEquatable<GridPlane3D>
	{
		public readonly EGridAxis3D Primary;
		public readonly EGridAxis3D Secondary;

		public static bool operator ==(GridPlane3D l, GridPlane3D r) => l.Equals(r);
		public static bool operator !=(GridPlane3D l, GridPlane3D r) => !l.Equals(r);

		[DebuggerStepThrough]
		public GridPlane3D(EGridAxis3D along)
		{
			switch(along)
			{
				case EGridAxis3D.X:
					Primary = EGridAxis3D.Z;
					Secondary = EGridAxis3D.Y;
					break;
				case EGridAxis3D.Y:
					Primary = EGridAxis3D.X;
					Secondary = EGridAxis3D.Z;
					break;
				case EGridAxis3D.Z:
					Primary = EGridAxis3D.X;
					Secondary = EGridAxis3D.Y;
					break;
				default:
					throw new NotImplementedException(along.ToString());
			}
		}

		[DebuggerStepThrough]
		public GridPlane3D(EGridAxis3D primary, EGridAxis3D secondary)
		{
			Primary = primary;
			Secondary = secondary;
		}

		public override bool Equals(object obj)
		{
			if(obj is GridPlane3D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridPlane3D other)
		{
			return Primary == other.Primary && Secondary == other.Secondary;
		}

		public override int GetHashCode()
		{
			return (int)Primary + ((int)Secondary << 8);
		}

		public override string ToString()
		{
			return $"({Primary}, {Secondary})";
		}
	}
}
