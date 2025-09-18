using System;
using System.Diagnostics;
using Newtonsoft.Json;

namespace UnityPlugins.Common.Logic
{
	[Serializable, JsonConverter(typeof(GridPoint2DJsonConverter))]
	public struct GridPoint2D : IEquatable<GridPoint2D>, IBinarySerializable
	{
		public int X;
		public int Y;

		public static bool operator ==(GridPoint2D l, GridPoint2D r) => l.Equals(r);
		public static bool operator !=(GridPoint2D l, GridPoint2D r) => !l.Equals(r);

		[DebuggerStepThrough, JsonConstructor]
		public GridPoint2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		[DebuggerStepThrough]
		public GridPoint2D(GridSize2D size)
		{
			X = size.X;
			Y = size.Y;
		}

		[DebuggerStepThrough]
		public GridPoint2D(EGridAxis2D axisA, int valueA, int valueB)
		{
			if(axisA == EGridAxis2D.X)
			{
				X = valueA;
				Y = valueB;
			}
			else
			{
				X = valueB;
				Y = valueA;
			}
		}

		#region Serialization
		public GridPoint2D(FastBinaryReader reader)
		{
			X = reader.ReadInt();
			Y = reader.ReadInt();
		}

		public void WriteToBuffer(FastBinaryWriter writer)
		{
			writer.Write(X);
			writer.Write(Y);
		}
		#endregion

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

		public GridPoint2D Set(EGridAxis2D axis, int value)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridPoint2D(value, Y);
				case EGridAxis2D.Y:
					return new GridPoint2D(X, value);
				default:
					throw new NotImplementedException(axis.ToString());
			}
		}

		public GridPoint2D Add(GridPoint2D point)
		{
			return new GridPoint2D(X+point.X, Y+point.Y);
		}

		public GridPoint2D Subtract(GridPoint2D point)
		{
			return new GridPoint2D(X-point.X, Y-point.Y);
		}

		public GridPoint2D Min(GridPoint2D other)
		{
			return new GridPoint2D(Math.Min(X, other.X), Math.Min(Y, other.Y));
		}

		public GridPoint2D Max(GridPoint2D other)
		{
			return new GridPoint2D(Math.Max(X, other.X), Math.Max(Y, other.Y));
		}

		#region Translate
		public GridPoint2D Translate(EGridCardinal2D direction, int distance = 1)
		{
			switch(direction)
			{
				case EGridCardinal2D.Up:
					return new GridPoint2D(X, Y-distance);
				case EGridCardinal2D.Right:
					return new GridPoint2D(X+distance, Y);
				case EGridCardinal2D.Down:
					return new GridPoint2D(X, Y+distance);
				case EGridCardinal2D.Left:
					return new GridPoint2D(X-distance, Y);
				default:
					throw new NotImplementedException($"{direction}");
			}
		}

		public GridPoint2D Translate(EGridDirection2D direction, int distance = 1)
		{
			switch(direction)
			{
				case EGridDirection2D.Up:
					return new GridPoint2D(X, Y-distance);
				case EGridDirection2D.UpRight:
					return new GridPoint2D(X+distance, Y-distance);
				case EGridDirection2D.Right:
					return new GridPoint2D(X+distance, Y);
				case EGridDirection2D.DownRight:
					return new GridPoint2D(X+distance, Y+distance);
				case EGridDirection2D.Down:
					return new GridPoint2D(X, Y+distance);
				case EGridDirection2D.DownLeft:
					return new GridPoint2D(X-distance, Y+distance);
				case EGridDirection2D.Left:
					return new GridPoint2D(X-distance, Y);
				case EGridDirection2D.UpLeft:
					return new GridPoint2D(X-distance, Y-distance);
				default:
					throw new NotImplementedException($"{direction}");
			}
		}

		public GridPoint2D Translate(EGridAxis2D axis, int distance = 1)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					return new GridPoint2D(X+distance, Y);
				case EGridAxis2D.Y:
					return new GridPoint2D(X, Y+distance);
				default:
					throw new NotImplementedException($"{axis}");
			}
		}

		public GridPoint2D Translate(EHexFlatDirection direction, int distance = 1)
		{
			if(direction == EHexFlatDirection.Up)
			{
				return new GridPoint2D(X, Y-distance);
			}
			if(direction == EHexFlatDirection.Down)
			{
				return new GridPoint2D(X, Y+distance);
			}

			bool oddColumn = (X & 1) == 1;
			int offsetX = 0;
			int offsetY = distance;

			switch(direction)
			{
				case EHexFlatDirection.UpRight:
					offsetX = distance;
					if(!oddColumn)
					{
						offsetY++;
					}
					offsetY = -(offsetY >> 1);
					break;
				case EHexFlatDirection.DownRight:
					offsetX = distance;
					if(oddColumn)
					{
						offsetY++;
					}
					offsetY = (offsetY >> 1);
					break;
				case EHexFlatDirection.DownLeft:
					offsetX = -distance;
					if(oddColumn)
					{
						offsetY++;
					}
					offsetY = (offsetY >> 1);
					break;
				case EHexFlatDirection.UpLeft:
					offsetX = -distance;
					if(!oddColumn)
					{
						offsetY++;
					}
					offsetY = -(offsetY >> 1);
					break;
				default:
					throw new NotImplementedException($"{direction}");
			}

			return new GridPoint2D(X+offsetX, Y+offsetY);
		}

		public GridPoint2D Translate(EHexPointyDirection direction, int distance = 1)
		{
			if(direction == EHexPointyDirection.Right)
			{
				return new GridPoint2D(X+distance, Y);
			}
			if(direction == EHexPointyDirection.Left)
			{
				return new GridPoint2D(X-distance, Y);
			}

			bool isOddRow = (Y & 1) == 1;
			int offsetX = distance;
			int offsetY = 0;

			switch(direction)
			{
				case EHexPointyDirection.UpRight:
					offsetY = -distance;
					if(isOddRow)
					{
						offsetX++;
					}
					offsetX = (offsetX >> 1);
					break;
				case EHexPointyDirection.DownRight:
					offsetY = distance;
					if(isOddRow)
					{
						offsetX++;
					}
					offsetX = (offsetX >> 1);
					break;
				case EHexPointyDirection.DownLeft:
					offsetY = distance;
					if(!isOddRow)
					{
						offsetX++;
					}
					offsetX = -(offsetX >> 1);
					break;
				case EHexPointyDirection.UpLeft:
					offsetY = -distance;
					if(!isOddRow)
					{
						offsetX++;
					}
					offsetX = -(offsetX >> 1);
					break;
				default:
					throw new NotImplementedException($"{direction}");
			}

			return new GridPoint2D(X+offsetX, Y+offsetY);
		}
		#endregion

		#region IsNeighbour
		public bool IsGridNeighour(GridPoint2D other)
		{
			int deltaX = other.X-X;
			int deltaY = other.Y-Y;

			if(deltaX < -1 || deltaX > 1 || deltaY < -1 || deltaY > 1)
			{
				return false;
			}

			return (deltaX != 0 || deltaY != 0);
		}

		public bool IsHexFlatNeighbour(GridPoint2D other)
		{
			int deltaX = other.X-X;
			int deltaY = other.Y-Y;

			if(deltaX == 0)
			{
				return deltaY == -1 || deltaY == 1;
			}

			if(deltaX != 1 && deltaX != -1)
			{
				return false;
			}

			if(deltaY == 0)
			{
				return true;
			}

			bool isOddColumn = (X & 1) == 1;
			if(isOddColumn)
			{
				return deltaY == 1;
			}
			else
			{
				return deltaY == -1;
			}
		}

		public bool IsHexPointyNeighbour(GridPoint2D other)
		{
			int deltaX = other.X-X;
			int deltaY = other.Y-Y;

			if(deltaY == 0)
			{
				return deltaX == -1 || deltaX == 1;
			}

			if(deltaY != 1 && deltaY != -1)
			{
				return false;
			}

			if(deltaX == 0)
			{
				return true;
			}

			bool isOddRow = (Y & 1) == 1;
			if(isOddRow)
			{
				return deltaX == 1;
			}
			else
			{
				return deltaX == -1;
			}
		}
		#endregion

		#region GetDirection
		public EGridDirection2D GetGridDirection(GridPoint2D other)
		{
			int deltaX = other.X-X;
			int deltaY = other.Y-Y;

			if(deltaX > 0)
			{
				if(deltaY > 0)
				{
					return EGridDirection2D.DownRight;
				}
				else if(deltaY < 0)
				{
					return EGridDirection2D.UpRight;
				}
				return EGridDirection2D.Right;
			}
			else if(deltaX < 0)
			{
				if(deltaY > 0)
				{
					return EGridDirection2D.DownLeft;
				}
				else if(deltaY < 0)
				{
					return EGridDirection2D.UpLeft;
				}
				return EGridDirection2D.Left;
			}
			else
			{
				if(deltaY > 0)
				{
					return EGridDirection2D.Down;
				}
				else if(deltaY < 0)
				{
					return EGridDirection2D.Up;
				}
				//It's the same point
				return EGridDirection2D.Up;
			}
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is GridPoint2D other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(GridPoint2D other)
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
