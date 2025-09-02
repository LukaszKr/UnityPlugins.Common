using System;
using System.Diagnostics;

namespace UnityPlugins.Common.Logic
{
	public readonly struct GridBounds2D : IEquatable<GridBounds2D>
	{
		public readonly GridPoint2D Min;
		public readonly GridPoint2D Max;

		public static bool operator ==(GridBounds2D l, GridBounds2D r) => l.Equals(r);
		public static bool operator !=(GridBounds2D l, GridBounds2D r) => !l.Equals(r);

		[DebuggerStepThrough]
		public GridBounds2D(GridSize2D size)
		{
			Min = default;
			Max = new GridPoint2D(size);
		}

		[DebuggerStepThrough]
		public GridBounds2D(GridPoint2D min, GridPoint2D max)
		{
			Min = min;
			Max = max;
		}

		[DebuggerStepThrough]
		public GridBounds2D(int maxX, int maxY)
		{
			Min = default;
			Max = new GridPoint2D(maxX, maxY);
		}

		[DebuggerStepThrough]
		public GridBounds2D(int minX, int minY, int maxX, int maxY)
		{
			Min = new GridPoint2D(minX, minY);
			Max = new GridPoint2D(maxX, maxY);
		}

		public GridPoint2D Clamp(GridPoint2D point)
		{
			int x = Math.Clamp(point.X, Min.X, Max.X-1);
			int y = Math.Clamp(point.Y, Min.Y, Max.Y-1);
			return new GridPoint2D(x, y);
		}

		public bool Contains(int x, int y)
		{
			return x < Max.X && y < Max.Y
				&& x >= Min.X && y >= Min.Y;
		}

		public bool Contains(GridPoint2D point)
		{
			return point.X < Max.X && point.Y < Max.Y
				&& point.X >= Min.X && point.Y >= Min.Y;
		}

		public bool Contains(GridBounds2D bounds)
		{
			GridPoint2D bMax = bounds.Max;
			return bMax.X <= Max.X && bMax.Y <= Max.Y
				&& Contains(bounds.Min);
		}

		public override bool Equals(object obj)
		{
			if(obj is GridBounds2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridBounds2D other)
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
