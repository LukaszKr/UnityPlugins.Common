using Newtonsoft.Json;
using System;
using System.IO;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	[Serializable, JsonConverter(typeof(UIDJsonConverter))]
	public struct UID<T> : IEquatable<UID<T>>, IComparable<UID<T>>
		where T : class
	{
		public static readonly UID<T> Invalid = new UID<T>(-1);

		public readonly int Value;

		public static bool operator ==(UID<T> left, UID<T> right) => (left.Value == right.Value);
		public static bool operator !=(UID<T> left, UID<T> right) => (left.Value != right.Value);

		public UID(int value)
		{
			Value = value;
		}

		#region Buffer Serialization
		public UID(BinaryReader reader)
		{
			Value = reader.ReadInt32();
		}

		public void WriteToBuffer(BinaryWriter writer)
		{
			writer.Write(Value);
		}
		#endregion

		#region Equals
		public override bool Equals(object other)
		{
			if(other is UID<T> casted)
			{
				return casted.Value == Value;
			}
			return false;
		}

		public bool Equals(UID<T> other)
		{
			return Value == other.Value;
		}
		#endregion

		#region Compare
		public int CompareTo(UID<T> other)
		{
			return Value.CompareTo(other.Value);
		}
		#endregion

		public override int GetHashCode()
		{
			return Value;
		}

		public override string ToString()
		{
			return $"({typeof(T).Name}={Value})";
		}
	}
}
