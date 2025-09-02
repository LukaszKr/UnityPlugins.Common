using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridPoint3DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridPoint3D>
		{
			public EqualsTest(bool areEqual, GridPoint3D a, GridPoint3D b)
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
			new EqualsTest(true, new GridPoint3D(1, 2, 3), new GridPoint3D(1, 2, 3)),

			new EqualsTest(false, new GridPoint3D(1, 2, 3), new GridPoint3D(0, 2, 3)),
			new EqualsTest(false, new GridPoint3D(1, 2, 3), new GridPoint3D(1, 0, 3)),
			new EqualsTest(false, new GridPoint3D(1, 2, 3), new GridPoint3D(1, 2, 0)),
			new EqualsTest(false, new GridPoint3D(1, 2, 3), new GridPoint3D(0, 0, 0)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region TranslateGridCardinal
		public class TranslateGridCardinal
		{
			public readonly GridPoint3D Origin;
			public readonly EGridCardinal3D Direction;
			public readonly int Distance;
			public readonly GridPoint3D Expected;

			public TranslateGridCardinal(GridPoint3D origin, EGridCardinal3D direction, int distance, GridPoint3D expected)
			{
				Origin = origin;
				Direction = direction;
				Distance = distance;
				Expected = expected;
			}

			public TranslateGridCardinal(EGridCardinal3D direction, GridPoint3D expected)
				: this(default, direction, 1, expected)
			{
			}

			public void Run()
			{
				Assert.AreEqual(Expected, Origin.Translate(Direction, Distance));
			}

			public override string ToString()
			{
				return $"{Origin} -{Direction}({Distance})-> {Expected}";
			}
		}

		private static readonly TranslateGridCardinal[] m_TranslateGridCardinalTests = new TranslateGridCardinal[]
		{
			new TranslateGridCardinal(EGridCardinal3D.Up, new GridPoint3D(0, 1, 0)),
			new TranslateGridCardinal(EGridCardinal3D.Down, new GridPoint3D(0, -1, 0)),
			new TranslateGridCardinal(EGridCardinal3D.Left, new GridPoint3D(-1, 0, 0)),
			new TranslateGridCardinal(EGridCardinal3D.Right, new GridPoint3D(1, 0, 0)),
			new TranslateGridCardinal(EGridCardinal3D.Front, new GridPoint3D(0, 0, 1)),
			new TranslateGridCardinal(EGridCardinal3D.Back, new GridPoint3D(0, 0, -1)),
		};

		[Test, TestCaseSource(nameof(m_TranslateGridCardinalTests))]
		public void Translate_GridCardinal(TranslateGridCardinal test)
		{
			test.Run();
		}
		#endregion

		#region TranslateGridAxis
		public class TranslateGridAxisTest
		{
			public readonly GridPoint3D Origin;
			public readonly EGridAxis3D Axis;
			public readonly int Distance;
			public readonly GridPoint3D Expected;

			public TranslateGridAxisTest(GridPoint3D origin, EGridAxis3D axis, int distance, GridPoint3D expected)
			{
				Origin = origin;
				Axis = axis;
				Distance = distance;
				Expected = expected;
			}

			public TranslateGridAxisTest(EGridAxis3D axis, int distance, GridPoint3D expected)
				: this(default, axis, distance, expected)
			{
			}

			public void Run()
			{
				Assert.AreEqual(Expected, Origin.Translate(Axis, Distance));
			}

			public override string ToString()
			{
				return $"{Origin} -{Axis}({Distance})-> {Expected}";
			}
		}

		private static readonly TranslateGridAxisTest[] m_TranslateGridAxisTests = new TranslateGridAxisTest[]
		{
			new TranslateGridAxisTest(EGridAxis3D.X, 1, new GridPoint3D(1, 0, 0)),
			new TranslateGridAxisTest(EGridAxis3D.X, -1, new GridPoint3D(-1, 0, 0)),
			new TranslateGridAxisTest(EGridAxis3D.Y, 1, new GridPoint3D(0, 1, 0)),
			new TranslateGridAxisTest(EGridAxis3D.Y, -1, new GridPoint3D(0, -1, 0)),
			new TranslateGridAxisTest(EGridAxis3D.Z, 1, new GridPoint3D(0, 0, 1)),
			new TranslateGridAxisTest(EGridAxis3D.Z, -1, new GridPoint3D(0, 0, -1)),
		};

		[Test, TestCaseSource(nameof(m_TranslateGridAxisTests))]
		public void Translate_GridAxis(TranslateGridAxisTest test)
		{
			test.Run();
		}
		#endregion

		[Test]
		public void Get()
		{
			GridPoint3D point = new GridPoint3D(1, 2, 3);
			Assert.AreEqual(1, point.Get(EGridAxis3D.X));
			Assert.AreEqual(2, point.Get(EGridAxis3D.Y));
			Assert.AreEqual(3, point.Get(EGridAxis3D.Z));
		}

		[Test]
		public void Set()
		{
			GridPoint3D point = new GridPoint3D()
				.Set(EGridAxis3D.X, 1)
				.Set(EGridAxis3D.Y, 2)
				.Set(EGridAxis3D.Z, 3);
			Assert.AreEqual(1, point.X);
			Assert.AreEqual(2, point.Y);
			Assert.AreEqual(3, point.Z);
		}

		[Test]
		public void Add()
		{
			GridPoint3D point = new GridPoint3D(1, 2, 3);
			GridPoint3D result = point.Add(new GridPoint3D(1, 2, 3));
			Assert.AreEqual(new GridPoint3D(2, 4, 6), result);
		}

		[Test]
		public void Subtract()
		{
			GridPoint3D point = new GridPoint3D(1, 2, 3);
			GridPoint3D result = point.Subtract(new GridPoint3D(1, 2, 3));
			Assert.AreEqual(new GridPoint3D(0, 0, 0), result);
		}

		#region MinTest
		public class MinTest
		{
			public readonly GridPoint3D Source;
			public readonly GridPoint3D Other;
			public readonly GridPoint3D Expected;

			public MinTest(GridPoint3D source, GridPoint3D other, GridPoint3D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridPoint3D result = Source.Min(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Min({Other}) -> {Expected}";
			}
		}

		private static readonly MinTest[] m_MinTests = new MinTest[]
		{
			new MinTest(new GridPoint3D(1, 2, 3), new GridPoint3D(-1, -2, -3), new GridPoint3D(-1, -2, -3)),
			new MinTest(new GridPoint3D(-1, -2, -3), new GridPoint3D(1, 2, 3), new GridPoint3D(-1, -2, -3)),
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
			public readonly GridPoint3D Source;
			public readonly GridPoint3D Other;
			public readonly GridPoint3D Expected;

			public MaxTest(GridPoint3D source, GridPoint3D other, GridPoint3D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridPoint3D result = Source.Max(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Max({Other}) -> {Expected}";
			}
		}

		private static readonly MaxTest[] m_MaxTests = new MaxTest[]
		{
			new MaxTest(new GridPoint3D(1, 2, 3), new GridPoint3D(-1, -2, -3), new GridPoint3D(1, 2, 3)),
			new MaxTest(new GridPoint3D(-1, -2, -3), new GridPoint3D(1, 2, 3), new GridPoint3D(1, 2, 3)),
		};

		[Test, TestCaseSource(nameof(m_MaxTests))]
		public void Max(MaxTest test)
		{
			test.Run();
		}
		#endregion
	}
}
