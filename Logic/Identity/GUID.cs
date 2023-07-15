using System;
using System.IO;
using Newtonsoft.Json;

namespace ProceduralLevel.Common.Logic
{
	[JsonConverter(typeof(GUIDJsonConverter))]
	public readonly struct GUID<T> : IEquatable<GUID<T>>, IComparable<GUID<T>>, IGenericGUID
	{
		public readonly Guid Value;

		public static bool operator ==(GUID<T> left, GUID<T> right) => (left.Value == right.Value);
		public static bool operator !=(GUID<T> left, GUID<T> right) => (left.Value != right.Value);

		Guid IGenericGUID.Value => Value;

		public static GUID<T> Create()
		{
			Guid guid = Guid.NewGuid();
			return new GUID<T>(guid);
		}

		public GUID(Guid guid)
		{
			Value = guid;
		}

		public GUID(GUID<T> uguid)
		{
			Value = uguid.Value;
		}

		public GUID(string guid)
		{
			Value = new Guid(guid);
		}

		#region Serialization
		public GUID(BinaryReader reader)
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

		public bool Equals(GUID<T> other)
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

			if(obj is GUID<T> casted)
			{
				return casted.Value == Value;
			}

			return false;
		}

		public int CompareTo(GUID<T> other)
		{
			return Value.CompareTo(other.Value);
		}

		public override string ToString()
		{
			return $"({Value})";
		}
	}
}
