using System;
using System.Diagnostics;
using System.Text;

namespace UnityPlugins.Common.Logic
{
	public class FastBinaryReader
	{
		[DebuggerStepThrough]
		public static implicit operator FastBinaryReader(byte[] buffer) => new FastBinaryReader(buffer);

		public readonly byte[] Buffer;
		public int Head;

		[DebuggerStepThrough]
		public FastBinaryReader(byte[] buffer)
		{
			Buffer = buffer;
		}

		#region Payload
		public BinaryPayloadHeader ReadPayload()
		{
			return new BinaryPayloadHeader(this);
		}

		public void SkipPayload(BinaryPayloadHeader header)
		{
			Head += header.Length;
		}
		#endregion

		public bool ReadBoolean()
		{
			byte result = Buffer[Head++];
			return result != 0;
		}

		public byte ReadByte()
		{
			return Buffer[Head++];
		}

		public sbyte ReadSByte()
		{
			return (sbyte)Buffer[Head++];
		}

		public ushort ReadUShort()
		{
			int result;
			result = (Buffer[Head++]);
			result += (Buffer[Head++] << 8);
			return (ushort)result;
		}

		public short ReadShort()
		{
			int result;
			result = (Buffer[Head++]);
			result += (Buffer[Head++] << 8);
			return (short)result;
		}

		public uint ReadUInt()
		{
			uint result;
			result = (Buffer[Head++]);
			result += (uint)(Buffer[Head++] << 8);
			result += (uint)(Buffer[Head++] << 16);
			result += (uint)(Buffer[Head++] << 24);
			return result;
		}

		public int ReadInt()
		{
			int result;
			result = (Buffer[Head++]);
			result += (Buffer[Head++] << 8);
			result += (Buffer[Head++] << 16);
			result += (Buffer[Head++] << 24);
			return result;
		}

		public ulong ReadULong()
		{
			ulong result = BitConverter.ToUInt64(Buffer, Head);
			Head += 8;
			return result;
		}

		public long ReadLong()
		{
			long result = BitConverter.ToInt64(Buffer, Head);
			Head += 8;
			return result;
		}

		public float ReadSingle()
		{
			float result = BitConverter.ToSingle(Buffer, Head);
			Head += 4;
			return result;
		}

		public double ReadDouble()
		{
			double result = BitConverter.ToDouble(Buffer, Head);
			Head += 8;
			return result;
		}

		public char[] ReadChars(int count)
		{
			char[] result = new char[count];
			for(int x = 0; x < count; ++x)
			{
				result[x] = (char)Buffer[Head++];
			}
			return result;
		}

		public string ReadString()
		{
			int length = ReadInt();
			if(length > 0)
			{
				string str = Encoding.UTF8.GetString(Buffer, Head, length);
				Head += length;
				return str;
			}
			return string.Empty;
		}

		public override string ToString()
		{
			return $"[{nameof(FastBinaryReader)}, {Head}/{Buffer.Length}]";
		}
	}
}
