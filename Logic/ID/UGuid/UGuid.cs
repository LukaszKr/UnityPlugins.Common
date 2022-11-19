using Newtonsoft.Json;
using System;
using System.IO;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	[Serializable, JsonConverter(typeof(UGuidJsonConverter))]
	public struct UGuid<T> : IEquatable<UGuid<T>>, IComparable<UGuid<T>>
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

		#region Buffer Serialization
		public UGuid(BinaryReader reader)
		{
			Value = new Guid(reader.ReadString());
		}

		public void WriteToBuffer(BinaryWriter writer)
		{
			writer.Write(Value.ToString());
		}
		#endregion

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public bool Equals(UGuid<T> other)
		{
			if(other != null)
			{
				return Value.Equals(other.Value);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if(obj is UGuid<T> casted)
			{
				return casted.Value == Value;
			}

			return false;
		}

		public int CompareTo(UGuid<T> other)
		{
			return Value.CompareTo(other.Value);
		}

		public override string ToString()
		{
			return Value.ToString();
		}
	}
}
