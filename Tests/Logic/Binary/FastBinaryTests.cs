using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Binary
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class FastBinaryTests
	{
		private FastBinaryReader m_Reader;
		private FastBinaryWriter m_Writer;

		[SetUp]
		public void SetUp()
		{
			byte[] buffer = new byte[32];
			m_Reader = new FastBinaryReader(buffer);
			m_Writer = new FastBinaryWriter(buffer);
		}

		[Test, Description("Write&Read bool.")]
		[TestCase(false)]
		[TestCase(true)]
		public void Bool(bool value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadBoolean());
			AssertBuffers();
		}

		[Test, Description("Write&Read byte.")]
		[TestCase(byte.MinValue)]
		[TestCase((byte)128)]
		[TestCase(byte.MaxValue)]
		public void Byte(byte value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadByte());
			AssertBuffers();
		}

		[Test, Description("Write&Read sbyte.")]
		[TestCase(sbyte.MinValue)]
		[TestCase((sbyte)0)]
		[TestCase(sbyte.MaxValue)]
		public void SByte(sbyte value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadSByte());
			AssertBuffers();
		}

		[Test, Description("Write&Read ushort.")]
		[TestCase(ushort.MinValue)]
		[TestCase((ushort)((ushort.MaxValue-ushort.MinValue)/2))]
		[TestCase(ushort.MaxValue)]
		public void UShort(ushort value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadUShort());
			AssertBuffers();
		}

		[Test, Description("Write&Read short.")]
		[TestCase(short.MinValue)]
		[TestCase(0)]
		[TestCase(short.MaxValue)]
		public void Short(short value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadShort());
			AssertBuffers();
		}

		[Test, Description("Write&Read uint.")]
		[TestCase(uint.MinValue)]
		[TestCase((uint)(uint.MaxValue-uint.MinValue)/2)]
		[TestCase(uint.MaxValue)]
		public void UInt(uint value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadUInt());
			AssertBuffers();
		}

		[Test, Description("Write&Read int.")]
		[TestCase(int.MinValue)]
		[TestCase(0)]
		[TestCase(int.MaxValue)]
		public void Int(int value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadInt());
			AssertBuffers();
		}

		[Test, Description("Write&Read ulong.")]
		[TestCase(ulong.MinValue)]
		[TestCase((ulong)((ulong.MaxValue-ulong.MinValue)/2))]
		[TestCase(ulong.MaxValue)]
		public void ULong(ulong value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadULong());
			AssertBuffers();
		}

		[Test, Description("Write&Read long.")]
		[TestCase(long.MinValue)]
		[TestCase(0)]
		[TestCase(long.MaxValue)]
		public void Long(long value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadLong());
			AssertBuffers();
		}

		[Test, Description("Write&Read float.")]
		[TestCase(float.MinValue)]
		[TestCase(0)]
		[TestCase(float.MaxValue)]
		public void Float(float value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadSingle());
			AssertBuffers();
		}

		[Test, Description("Write&Read double.")]
		[TestCase(double.MinValue)]
		[TestCase(0)]
		[TestCase(double.MaxValue)]
		public void Double(double value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadDouble());
			AssertBuffers();
		}

		[Test, Description("Write&Read string.")]
		[TestCase("Hello World")]
		[TestCase("")]
		public void String(string value)
		{
			m_Writer.Write(value);
			Assert.AreEqual(value, m_Reader.ReadString());
			AssertBuffers();
		}

		[Test, Description("Null strings are read as empty string.")]
		public void String_Null()
		{
			string str = null;
			m_Writer.Write(str);
			Assert.AreEqual(string.Empty, m_Reader.ReadString());
			AssertBuffers();
		}

		private void AssertBuffers()
		{
			Assert.AreEqual(m_Reader.Buffer, m_Writer.Buffer);
			Assert.AreEqual(m_Reader.Head, m_Writer.Head);
		}
	}
}
