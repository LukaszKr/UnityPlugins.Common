using System;

namespace UnityPlugins.Common.Logic
{
	public readonly struct BinaryPayloadHeader : IEquatable<BinaryPayloadHeader>
	{
		public readonly int Offset;
		public readonly int Length;

		public static bool operator ==(BinaryPayloadHeader left, BinaryPayloadHeader right) => left.Equals(right);
		public static bool operator !=(BinaryPayloadHeader left, BinaryPayloadHeader right) => !left.Equals(right);

		public int FinalOffset => Offset+Length;

		public BinaryPayloadHeader(int offset, int length)
		{
			Offset = offset;
			Length = length;
		}

		public BinaryPayloadHeader(FastBinaryReader reader)
		{
			Length = reader.ReadInt();
			Offset = reader.Head;
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
			return Offset == other.Offset && Length == other.Length;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Offset, Length);
		}

		public override string ToString()
		{
			return $"({nameof(Length)}: {Length})";
		}
	}
}
