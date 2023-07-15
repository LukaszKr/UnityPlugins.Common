using System;
using System.IO;
using Newtonsoft.Json;

namespace ProceduralLevel.Common.Logic
{
	[JsonConverter(typeof(IDJsonConverter))]
	public readonly struct ID<T> : IEquatable<ID<T>>, IComparable<ID<T>>, IGenericID
	{
		public readonly int Value;

		public static bool operator ==(ID<T> left, ID<T> right) => (left.Value == right.Value);
		public static bool operator !=(ID<T> left, ID<T> right) => (left.Value != right.Value);

		int IGenericID.Value => Value;

		public ID(int value)
		{
			Value = value;
		}

		#region Serialization
		public ID(BinaryReader reader)
		{
			Value = reader.ReadInt32();
		}

		public void WriteToBuffer(BinaryWriter writer)
		{
			writer.Write(Value);
		}
		#endregion

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public bool Equals(ID<T> other)
		{
			if(other != null)
			{
				return Value.Equals(other.Value);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if(obj == null)
			{
				return false;
			}

			if(obj is ID<T> casted)
			{
				return casted.Value == Value;
			}

			return false;
		}

		public int CompareTo(ID<T> other)
		{
			return Value.CompareTo(other.Value);
		}

		public override string ToString()
		{
			return $"({Value})";
		}
	}
}
