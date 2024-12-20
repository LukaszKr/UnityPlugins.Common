using System;

namespace UnityPlugins.Common.Logic
{
	public readonly struct BinaryPayloadHeader : IEquatable<BinaryPayloadHeader>
	{
		public readonly int Position;
		public readonly int Length;

		public static bool operator ==(BinaryPayloadHeader left, BinaryPayloadHeader right) => left.Equals(right);
		public static bool operator !=(BinaryPayloadHeader left, BinaryPayloadHeader right) => !left.Equals(right);

		public BinaryPayloadHeader(int position, int length)
		{
			Position = position;
			Length = length;
		}

		public BinaryPayloadHeader(int position, FastBinaryReader reader)
		{
			Position = position;
			Length = reader.ReadInt();
		}

		public override bool Equals(object obj)
		{
			if(obj is BinaryPayloadHeader other)
			{
				return Equals(other);
			}

			return false;
		}

		public bool Equals(BinaryPayloadHeader other)
		{
			return Position == other.Position && Length == other.Length;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Position, Length);
		}

		public override string ToString()
		{
			return $"({nameof(Length)}: {Length})";
		}
	}
}
