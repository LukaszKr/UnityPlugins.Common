using System.Collections.Generic;
using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridSize2DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridSize2D>
		{
			public EqualsTest(bool areEqual, GridSize2D a, GridSize2D b)
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
			new EqualsTest(true, new GridSize2D(1, 2), new GridSize2D(1, 2)),

			new EqualsTest(false, new GridSize2D(1, 2), new GridSize2D(1, 0)),
			new EqualsTest(false, new GridSize2D(1, 2), new GridSize2D(0, 2)),
			new EqualsTest(false, new GridSize2D(1, 2), new GridSize2D(0, 0)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region Clamp
		public class ClampTest
		{
			public readonly GridSize2D Size;
			public readonly GridPoint2D PointToClamp;
			public readonly GridPoint2D Expected;

			public ClampTest(GridSize2D size, int pX, int pY, int eX, int eY)
			{
				Size = size;
				PointToClamp = new GridPoint2D(pX, pY);
				Expected = new GridPoint2D(eX, eY);
			}

			public void Run()
			{
				GridPoint2D result = Size.Clamp(PointToClamp);
				Assert.AreEqual(Expected, result);
			}

			public override string ToString()
			{
				return $"{nameof(Size)}: {Size}, {PointToClamp} -> {Expected}";
			}
		}

		private static IEnumerable<ClampTest> GetClampTests()
		{
			GridSize2D size = new GridSize2D(4, 5);
			int maxX = size.X-1;
			int maxY = size.Y-1;
			yield return new ClampTest(size, 100, 3, maxX, 3);
			yield return new ClampTest(size, 3, 100, 3, maxY);
			yield return new ClampTest(size, -1, 3, 0, 3);
			yield return new ClampTest(size, 3, -3, 3, 0);
			yield return new ClampTest(size, 3, 2, 3, 2);
		}

		[Test, TestCaseSource(nameof(GetClampTests))]
		public void Clamp(ClampTest test)
		{
			test.Run();
		}
		#endregion

		#region Contains
		public class ContainsTest
		{
			public readonly GridSize2D Size;
			public readonly int X;
			public readonly int Y;
			public readonly bool Expected;

			public ContainsTest(GridSize2D size, int x, int y, bool expected)
			{
				Size = size;
				X = x;
				Y = y;
				Expected = expected;
			}

			public ContainsTest(int x, int y, bool expected)
				: this(new GridSize2D(5, 5), x, y, expected)
			{
			}

			public void Run()
			{
				Assert.AreEqual(Expected, Size.Contains(X, Y));
				GridPoint2D point = new GridPoint2D(X, Y);
				Assert.AreEqual(Expected, Size.Contains(point));
			}

			public override string ToString()
			{
				string result = (Expected? "contains": "doesn't contain");
				return $"{Size} {result} ({X}, {Y})";
			}
		}

		private static readonly ContainsTest[] m_ContainsTests = new ContainsTest[]
		{
			new ContainsTest(0, 0, true),
			new ContainsTest(4, 4, true),

			new ContainsTest(-1, 0, false),
			new ContainsTest(0, -1, false),
			new ContainsTest(5, 4, false),
			new ContainsTest(4, 5, false),
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
			public readonly GridSize2D Source;
			public readonly GridSize2D Other;
			public readonly GridSize2D Expected;

			public MinTest(GridSize2D source, GridSize2D other, GridSize2D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridSize2D result = Source.Min(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Min({Other}) -> {Expected}";
			}
		}

		private static readonly MinTest[] m_MinTests = new MinTest[]
		{
			new MinTest(new GridSize2D(4, 5), new GridSize2D(1, 2), new GridSize2D(1, 2)),
			new MinTest(new GridSize2D(1, 2), new GridSize2D(4, 5), new GridSize2D(1, 2)),
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
			public readonly GridSize2D Source;
			public readonly GridSize2D Other;
			public readonly GridSize2D Expected;

			public MaxTest(GridSize2D source, GridSize2D other, GridSize2D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridSize2D result = Source.Max(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Max({Other}) -> {Expected}";
			}
		}

		private static readonly MaxTest[] m_MaxTests = new MaxTest[]
		{
			new MaxTest(new GridSize2D(4, 5), new GridSize2D(1, 2), new GridSize2D(4, 5)),
			new MaxTest(new GridSize2D(1, 2), new GridSize2D(4, 5), new GridSize2D(4, 5)),
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
			GridSize2D size = new GridSize2D(1, 2);
			FastBinaryWriter writer = new FastBinaryWriter(64);
			byte[] bytes = size.WriteToByteArray(writer);
			GridSize2D deserialized = new GridSize2D(bytes.ToBinaryReader());
			Assert.AreEqual(size, deserialized);
		}
		#endregion
	}
}
