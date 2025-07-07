using System;
using Newtonsoft.Json;

namespace UnityPlugins.Common.Logic
{
	[Serializable, JsonConverter(typeof(UGuidJsonConverter))]
	public readonly struct UGuid<T> : IEquatable<UGuid<T>>, IComparable<UGuid<T>>, IBinarySerializable
	{
		public readonly Guid Value;

		public static bool operator ==(UGuid<T> left, UGuid<T> right) => (left.Value == right.Value);
		public static bool operator !=(UGuid<T> left, UGuid<T> right) => (left.Value != right.Value);

		public static UGuid<T> Create()
		{
			Guid guid = Guid.NewGuid();
			return new UGuid<T>(guid);
		}

		public UGuid(Guid guid)
		{
			Value = guid;
		}

		public UGuid(UGuid<T> uguid)
		{
			Value = uguid.Value;
		}

		public UGuid(string guid)
		{
			Value = new Guid(guid);
		}

		#region Serialization
		public UGuid(FastBinaryReader reader)
		{
			Value = new Guid(reader.ReadString());
		}

		public void WriteToBuffer(FastBinaryWriter writer)
		{
			writer.Write(Value.ToString());
		}
		#endregion

		public override bool Equals(object obj)
		{
			if(obj is UGuid<T> casted)
			{
				return casted.Value == Value;
			}

			return false;
		}

		public bool Equals(UGuid<T> other)
		{
			if(other != null)
			{
				return Value.Equals(other.Value);
			}
			return false;
		}

		public int CompareTo(UGuid<T> other)
		{
			return Value.CompareTo(other.Value);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}