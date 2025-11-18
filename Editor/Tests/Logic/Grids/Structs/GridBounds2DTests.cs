using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridBounds2DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridBounds2D>
		{
			public EqualsTest(bool areEqual, GridBounds2D a, GridBounds2D b)
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
			new EqualsTest(true, new GridBounds2D(1, 2, 3, 4), new GridBounds2D(1, 2, 3, 4)),

			new EqualsTest(false, new GridBounds2D(1, 2, 3, 4), new GridBounds2D(0, 2, 3, 4)),
			new EqualsTest(false, new GridBounds2D(1, 2, 3, 4), new GridBounds2D(1, 0, 3, 4)),
			new EqualsTest(false, new GridBounds2D(1, 2, 3, 4), new GridBounds2D(1, 2, 0, 4)),
			new EqualsTest(false, new GridBounds2D(1, 2, 3, 4), new GridBounds2D(1, 2, 3, 0)),
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
			public readonly GridBounds2D Bounds;
			public readonly int X;
			public readonly int Y;
			public readonly bool Expected;

			public ContainsTest(GridBounds2D bounds, int x, int y, bool expected)
			{
				Bounds = bounds;
				X = x;
				Y = y;
				Expected = expected;
			}

			public ContainsTest(int x, int y, bool expected)
				: this(new GridBounds2D(1, 1, 5, 5), x, y, expected)
			{
			}

			public void Run()
			{
				GridPoint2D point = new GridPoint2D(X, Y);
				Assert.AreEqual(Expected, Bounds.Contains(X, Y));
				Assert.AreEqual(Expected, Bounds.Contains(point));
			}

			public override string ToString()
			{
				string result = (Expected? "contains": "doesn't contain");
				return $"{Bounds} {result} ({X}, {Y})";
			}
		}

		private static readonly ContainsTest[] m_ContainsTests = new ContainsTest[]
		{
			new ContainsTest(1, 1, true),
			new ContainsTest(4, 4, true),

			new ContainsTest(0, 1, false),
			new ContainsTest(1, 0, false),
			new ContainsTest(5, 4, false),
			new ContainsTest(4, 5, false),
		};

		[Test, TestCaseSource(nameof(m_ContainsTests))]
		public void Contains(ContainsTest test)
		{
			test.Run();
		}
		#endregion

		#region ContainsBounds
		public class ContainsBoundsTest
		{
			public readonly GridBounds2D Bounds;
			public readonly GridBounds2D ToCheck;
			public readonly bool Expected;

			public ContainsBoundsTest(GridBounds2D bounds, GridBounds2D toCheck, bool expected)
			{
				Bounds = bounds;
				ToCheck = toCheck;
				Expected = expected;
			}

			public ContainsBoundsTest(GridBounds2D toCheck, bool expected)
				: this(new GridBounds2D(1, 1, 5, 5), toCheck, expected)
			{
			}

			public void Run()
			{
				Assert.AreEqual(Expected, Bounds.Contains(ToCheck));
			}

			public override string ToString()
			{
				string result = (Expected? "contains": "doesn't contain");
				return $"{Bounds} {result} {ToCheck}";
			}
		}

		private static readonly ContainsBoundsTest[] m_ContainsBoundsTests = new ContainsBoundsTest[]
		{
			new ContainsBoundsTest(new GridBounds2D(1, 1, 5, 5), true),

			new ContainsBoundsTest(new GridBounds2D(0, 1, 5, 5), false),
			new ContainsBoundsTest(new GridBounds2D(1, 0, 5, 5), false),
			new ContainsBoundsTest(new GridBounds2D(1, 1, 6, 5), false),
			new ContainsBoundsTest(new GridBounds2D(1, 1, 5, 6), false),
		};

		[Test, TestCaseSource(nameof(m_ContainsBoundsTests))]
		public void ContainsBounds(ContainsBoundsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
