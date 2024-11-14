using System;
using Newtonsoft.Json;

namespace UnityPlugins.Common.Logic
{
	[JsonConverter(typeof(IDJsonConverter))]
	public readonly struct ID<T> : IEquatable<ID<T>>, IComparable<ID<T>>, IBinarySerializable
	{
		public readonly int Value;

		public static bool operator ==(ID<T> left, ID<T> right) => (left.Value == right.Value);
		public static bool operator !=(ID<T> left, ID<T> right) => (left.Value != right.Value);

		public ID(int value)
		{
			Value = value;
		}

		#region Serialization
		public ID(FastBinaryReader reader)
		{
			Value = reader.ReadInt();
		}

		public void WriteToBuffer(FastBinaryWriter writer)
		{
			writer.Write(Value);
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is ID<T> casted)
			{
				return casted.Value == Value;
			}

			return false;
		}

		public bool Equals(ID<T> other)
		{
			if(other != null)
			{
				return Value.Equals(other.Value);
			}
			return false;
		}

		public int CompareTo(ID<T> other)
		{
			return Value.CompareTo(other.Value);
		}

		public override int GetHashCode()
		{
			return Value;
		}

		public override string ToString()
		{
			return $"{Value}";
		}
	}
}
