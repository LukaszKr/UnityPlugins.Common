using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridBounds3DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridBounds3D>
		{
			public EqualsTest(bool areEqual, GridBounds3D a, GridBounds3D b)
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
			new EqualsTest(true, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(1, 2, 3, 4, 5, 6)),

			new EqualsTest(false, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(0, 2, 3, 4, 5, 6)),
			new EqualsTest(false, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(1, 0, 3, 4, 5, 6)),
			new EqualsTest(false, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(1, 2, 0, 4, 5, 6)),
			new EqualsTest(false, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(1, 2, 3, 0, 5, 6)),
			new EqualsTest(false, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(1, 2, 3, 4, 0, 6)),
			new EqualsTest(false, new GridBounds3D(1, 2, 3, 4, 5, 6), new GridBounds3D(1, 2, 3, 4, 5, 0)),
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
			public readonly GridBounds3D Bounds;
			public readonly int X;
			public readonly int Y;
			public readonly int Z;
			public readonly bool Expected;

			public ContainsTest(GridBounds3D bounds, int x, int y, int z, bool expected)
			{
				Bounds = bounds;
				X = x;
				Y = y;
				Z = z;
				Expected = expected;
			}

			public ContainsTest(int x, int y, int z, bool expected)
				: this(new GridBounds3D(1, 1, 1, 5, 5, 5), x, y, z, expected)
			{
			}

			public void Run()
			{
				GridPoint3D point = new GridPoint3D(X, Y, Z);
				Assert.AreEqual(Expected, Bounds.Contains(X, Y, Z));
				Assert.AreEqual(Expected, Bounds.Contains(point));
			}

			public override string ToString()
			{
				string result = (Expected? "contains": "doesn't contain");
				return $"{Bounds} {result} ({X}, {Y}, {Z})";
			}
		}

		private static readonly ContainsTest[] m_ContainsTests = new ContainsTest[]
		{
			new ContainsTest(1, 1, 1, true),
			new ContainsTest(4, 4, 4, true),

			new ContainsTest(0, 1, 1, false),
			new ContainsTest(1, 0, 1, false),
			new ContainsTest(1, 1, 0, false),
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

		#region ContainsBounds
		public class ContainsBoundsTest
		{
			public readonly GridBounds3D Bounds;
			public readonly GridBounds3D ToCheck;
			public readonly bool Expected;

			public ContainsBoundsTest(GridBounds3D bounds, GridBounds3D toCheck, bool expected)
			{
				Bounds = bounds;
				ToCheck = toCheck;
				Expected = expected;
			}

			public ContainsBoundsTest(GridBounds3D toCheck, bool expected)
				: this(new GridBounds3D(1, 1, 1, 5, 5, 5), toCheck, expected)
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
			new ContainsBoundsTest(new GridBounds3D(1, 1, 1, 5, 5, 5), true),

			new ContainsBoundsTest(new GridBounds3D(0, 1, 1, 5, 5, 5), false),
			new ContainsBoundsTest(new GridBounds3D(1, 0, 1, 5, 5, 5), false),
			new ContainsBoundsTest(new GridBounds3D(1, 1, 0, 5, 5, 5), false),
			new ContainsBoundsTest(new GridBounds3D(1, 1, 1, 6, 5, 5), false),
			new ContainsBoundsTest(new GridBounds3D(1, 1, 1, 5, 6, 5), false),
			new ContainsBoundsTest(new GridBounds3D(1, 1, 1, 5, 5, 6), false),
		};

		[Test, TestCaseSource(nameof(m_ContainsBoundsTests))]
		public void ContainsBounds(ContainsBoundsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
