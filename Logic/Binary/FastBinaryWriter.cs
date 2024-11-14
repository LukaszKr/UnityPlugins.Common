using System;
using System.Text;

namespace UnityPlugins.Common.Logic
{
	public class FastBinaryWriter
	{
		public static implicit operator FastBinaryWriter(byte[] buffer) => new FastBinaryWriter(buffer);

		public readonly byte[] Buffer;
		public int Head;

		public FastBinaryWriter(byte[] buffer)
		{
			Buffer = buffer;
		}

		public FastBinaryWriter(int capacity)
		{
			Buffer = new byte[capacity];
		}

		public void Clear()
		{
			Head = 0;
		}

		public byte[] GetBytes()
		{
			byte[] result = new byte[Head];
			for(int x = 0; x < Head; ++x)
			{
				result[x] = Buffer[x];
			}
			return result;
		}

		public void Write(bool value)
		{
			Buffer[Head++] = (value ? (byte)1 : (byte)0);
		}

		public void Write(byte value)
		{
			Buffer[Head++] = value;
		}

		public void Write(sbyte value)
		{
			Buffer[Head++] = (byte)value;
		}

		public void Write(ushort value)
		{
			Buffer[Head++] = (byte)value;
			Buffer[Head++] = (byte)(value >> 8);
		}

		public void Write(short value)
		{
			Buffer[Head++] = (byte)value;
			Buffer[Head++] = (byte)(value >> 8);
		}

		public void Write(uint value)
		{
			Buffer[Head++] = (byte)value;
			Buffer[Head++] = (byte)(value >> 8);
			Buffer[Head++] = (byte)(value >> 16);
			Buffer[Head++] = (byte)(value >> 24);
		}

		public void Write(int value)
		{
			Buffer[Head++] = (byte)value;
			Buffer[Head++] = (byte)(value >> 8);
			Buffer[Head++] = (byte)(value >> 16);
			Buffer[Head++] = (byte)(value >> 24);
		}

		public void Write(ulong value)
		{
			BitConverter.TryWriteBytes(new Span<byte>(Buffer, Head, Buffer.Length), value);
			Head += 8;
		}

		public void Write(long value)
		{
			BitConverter.TryWriteBytes(new Span<byte>(Buffer, Head, Buffer.Length), value);
			Head += 8;
		}

		public void Write(float value)
		{
			BitConverter.TryWriteBytes(new Span<byte>(Buffer, Head, Buffer.Length), value);
			Head += 4;
		}

		public void Write(double value)
		{
			BitConverter.TryWriteBytes(new Span<byte>(Buffer, Head, Buffer.Length), value);
			Head += 8;
		}

		public void Write(byte[] bytes)
		{
			for(int x = 0; x < bytes.Length; ++x)
			{
				Buffer[Head++] = bytes[x];
			}
		}

		public void Write(string text)
		{
			if(string.IsNullOrEmpty(text))
			{
				Write(0);
			}
			else
			{
				byte[] data = Encoding.UTF8.GetBytes(text);
				Write(data.Length);
				Write(data);
			}
		}
	}
}
