using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridSize3DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridSize3D>
		{
			public EqualsTest(bool areEqual, GridSize3D a, GridSize3D b)
				: base(areEqual, a, b)
			{
			}

			public override void Run()
			{
				base.Run();

				Assert.AreEqual(AreEqual, A == B);
				Assert.AreNotEqual(AreEqual, A != B);
			}
		}

		private static readonly EqualsTest[] m_EqualsTests = new EqualsTest[]
		{
			new EqualsTest(true, default, default),
			new EqualsTest(true, new GridSize3D(1, 2, 3), new GridSize3D(1, 2, 3)),

			new EqualsTest(false, new GridSize3D(1, 2, 3), new GridSize3D(0, 2, 3)),
			new EqualsTest(false, new GridSize3D(1, 2, 3), new GridSize3D(1, 0, 3)),
			new EqualsTest(false, new GridSize3D(1, 2, 3), new GridSize3D(1, 2, 0)),
			new EqualsTest(false, new GridSize3D(1, 2, 3), new GridSize3D(0, 0, 0)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region Contains
		public class ContainsTest
		{
			public readonly GridSize3D Size;
			public readonly int X;
			public readonly int Y;
			public readonly int Z;
			public readonly bool Expected;

			public ContainsTest(GridSize3D size, int x, int y, int z, bool expected)
			{
				Size = size;
				X = x;
				Y = y;
				Z = z;
				Expected = expected;
			}

			public ContainsTest(int x, int y, int z, bool expected)
				: this(new GridSize3D(5, 5, 5), x, y, z, expected)
			{
			}

			public void Run()
			{
				Assert.AreEqual(Expected, Size.Contains(X, Y, Z));
				GridPoint3D point = new GridPoint3D(X, Y, Z);
				Assert.AreEqual(Expected, Size.Contains(point));
			}

			public override string ToString()
			{
				string result = (Expected? "contains": "doesn't contain");
				return $"{Size} {result} ({X}, {Y}, {Z})";
			}
		}

		private static readonly ContainsTest[] m_ContainsTests = new ContainsTest[]
		{
			new ContainsTest(0, 0, 0, true),
			new ContainsTest(4, 4, 4, true),

			new ContainsTest(-1, 0, 0, false),
			new ContainsTest(0, -1, 0, false),
			new ContainsTest(0, 0, -1, false),
			new ContainsTest(5, 4, 4, false),
			new ContainsTest(4, 5, 4, false),
			new ContainsTest(4, 4, 5, false),
		};

		[Test, TestCaseSource(nameof(m_ContainsTests))]
		public void Contains(ContainsTest test)
		{
			test.Run();
		}
		#endregion

		#region MinTest
		public class MinTest
		{
			public readonly GridSize3D Source;
			public readonly GridSize3D Other;
			public readonly GridSize3D Expected;

			public MinTest(GridSize3D source, GridSize3D other, GridSize3D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridSize3D result = Source.Min(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Min({Other}) -> {Expected}";
			}
		}

		private static readonly MinTest[] m_MinTests = new MinTest[]
		{
			new MinTest(new GridSize3D(4, 5, 6), new GridSize3D(1, 2, 3), new GridSize3D(1, 2, 3)),
			new MinTest(new GridSize3D(1, 2, 3), new GridSize3D(4, 5, 6), new GridSize3D(1, 2, 3)),
		};

		[Test, TestCaseSource(nameof(m_MinTests))]
		public void Min(MinTest test)
		{
			test.Run();
		}
		#endregion

		#region MaxTest
		public class MaxTest
		{
			public readonly GridSize3D Source;
			public readonly GridSize3D Other;
			public readonly GridSize3D Expected;

			public MaxTest(GridSize3D source, GridSize3D other, GridSize3D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridSize3D result = Source.Max(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Max({Other}) -> {Expected}";
			}
		}

		private static readonly MaxTest[] m_MaxTests = new MaxTest[]
		{
			new MaxTest(new GridSize3D(4, 5, 6), new GridSize3D(1, 2, 3), new GridSize3D(4, 5, 6)),
			new MaxTest(new GridSize3D(1, 2, 3), new GridSize3D(4, 5, 6), new GridSize3D(4, 5, 6)),
		};

		[Test, TestCaseSource(nameof(m_MaxTests))]
		public void Max(MaxTest test)
		{
			test.Run();
		}
		#endregion

		#region Serialization
		[Test]
		public void Serialization_Binary()
		{
			GridSize3D size = new GridSize3D(1, 2, 3);
			FastBinaryWriter writer = new FastBinaryWriter(64);
			byte[] bytes = size.WriteToByteArray(writer);
			GridSize3D deserialized = new GridSize3D(bytes.ToBinaryReader());
			Assert.AreEqual(size, deserialized);
		}
		#endregion
	}
}
