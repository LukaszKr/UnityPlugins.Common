using System.Collections.Generic;
using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridPoint2DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridPoint2D>
		{
			public EqualsTest(bool areEqual, GridPoint2D a, GridPoint2D b)
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
			new EqualsTest(true, new GridPoint2D(1, 2), new GridPoint2D(1, 2)),

			new EqualsTest(false, new GridPoint2D(1, 2), new GridPoint2D(1, 0)),
			new EqualsTest(false, new GridPoint2D(1, 2), new GridPoint2D(0, 2)),
			new EqualsTest(false, new GridPoint2D(1, 2), new GridPoint2D(0, 0)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion

		#region Translate
		public abstract class ATranslateTest<TEnum>
		{
			public readonly GridPoint2D Origin;
			public readonly TEnum Direction;
			public readonly int Distance;
			public readonly GridPoint2D Expected;


			public ATranslateTest(GridPoint2D origin, TEnum direction, int distance, GridPoint2D expected)
			{
				Origin = origin;
				Direction = direction;
				Distance = distance;
				Expected = expected;
			}

			public ATranslateTest(TEnum direction, GridPoint2D expected)
				: this(default, direction, 1, expected)
			{
			}

			public void Run()
			{
				GridPoint2D result = Translate(Origin, Direction, Distance);
				Assert.AreEqual(Expected, result);
			}

			public abstract GridPoint2D Translate(GridPoint2D point, TEnum direction, int distance);

			public override string ToString()
			{
				return $"{Origin} -{Direction}({Distance})-> {Expected}";
			}
		}

		#region TranslateGridCardinal
		public class TranslateGridCardinalTest : ATranslateTest<EGridCardinal2D>
		{
			public TranslateGridCardinalTest(EGridCardinal2D direction, GridPoint2D expected)
				: base(default, direction, 1, expected)
			{
			}

			public override GridPoint2D Translate(GridPoint2D point, EGridCardinal2D direction, int distance)
			{
				return point.Translate(direction, distance);
			}
		}

		private static readonly TranslateGridCardinalTest[] m_TranslateGridCardinalTests = new TranslateGridCardinalTest[]
		{
			new TranslateGridCardinalTest(EGridCardinal2D.Up, new GridPoint2D(0, -1)),
			new TranslateGridCardinalTest(EGridCardinal2D.Right, new GridPoint2D(1, 0)),
			new TranslateGridCardinalTest(EGridCardinal2D.Down, new GridPoint2D(0, 1)),
			new TranslateGridCardinalTest(EGridCardinal2D.Left, new GridPoint2D(-1, 0)),
		};

		[Test, TestCaseSource(nameof(m_TranslateGridCardinalTests))]
		public void Translate_GridCardinal(TranslateGridCardinalTest test)
		{
			test.Run();
		}
		#endregion

		#region TranslateGridDirection
		public class TranslateGridDirectionTest : ATranslateTest<EGridDirection2D>
		{
			public TranslateGridDirectionTest(EGridDirection2D direction, GridPoint2D expected)
				: base(default, direction, 1, expected)
			{
			}

			public override GridPoint2D Translate(GridPoint2D point, EGridDirection2D direction, int distance)
			{
				return point.Translate(direction, distance);
			}
		}

		private static readonly TranslateGridDirectionTest[] m_TranslateGridDirectionTests = new TranslateGridDirectionTest[]
		{
			new TranslateGridDirectionTest(EGridDirection2D.Up, new GridPoint2D(0, -1)),
			new TranslateGridDirectionTest(EGridDirection2D.UpRight, new GridPoint2D(1, -1)),
			new TranslateGridDirectionTest(EGridDirection2D.Right, new GridPoint2D(1, 0)),
			new TranslateGridDirectionTest(EGridDirection2D.DownRight, new GridPoint2D(1, 1)),
			new TranslateGridDirectionTest(EGridDirection2D.Down, new GridPoint2D(0, 1)),
			new TranslateGridDirectionTest(EGridDirection2D.DownLeft, new GridPoint2D(-1, 1)),
			new TranslateGridDirectionTest(EGridDirection2D.Left, new GridPoint2D(-1, 0)),
			new TranslateGridDirectionTest(EGridDirection2D.UpLeft, new GridPoint2D(-1, -1)),
		};

		[Test, TestCaseSource(nameof(m_TranslateGridDirectionTests))]
		public void Translate_GridDirection(TranslateGridDirectionTest test)
		{
			test.Run();
		}
		#endregion

		#region TranslateAxis
		public class TranslateGridAxisTest : ATranslateTest<EGridAxis2D>
		{
			public TranslateGridAxisTest(EGridAxis2D direction, int distance, GridPoint2D expected)
				: base(default, direction, distance, expected)
			{
			}

			public override GridPoint2D Translate(GridPoint2D point, EGridAxis2D direction, int distance)
			{
				return point.Translate(direction, distance);
			}
		}

		private static readonly TranslateGridAxisTest[] m_TranslateGridAxisTests = new TranslateGridAxisTest[]
		{
			new TranslateGridAxisTest(EGridAxis2D.X, 1, new GridPoint2D(1, 0)),
			new TranslateGridAxisTest(EGridAxis2D.X, -1, new GridPoint2D(-1, 0)),
			new TranslateGridAxisTest(EGridAxis2D.Y, 1, new GridPoint2D(0, 1)),
			new TranslateGridAxisTest(EGridAxis2D.Y, -1, new GridPoint2D(0, -1)),
		};

		[Test, TestCaseSource(nameof(m_TranslateGridAxisTests))]
		public void Translate_GridAxis(TranslateGridAxisTest test)
		{
			test.Run();
		}
		#endregion

		#region TranslateHexFlatDirection
		public class TranlateHexFlatDirectionTest : ATranslateTest<EHexFlatDirection>
		{
			public TranlateHexFlatDirectionTest(int originX, int originY, EHexFlatDirection direction, int distance, int expectedX, int expectedY)
				: base(new GridPoint2D(originX, originY), direction, distance, new GridPoint2D(expectedX, expectedY))
			{
			}

			public override GridPoint2D Translate(GridPoint2D point, EHexFlatDirection direction, int distance)
			{
				return point.Translate(direction, distance);
			}
		}

		private static readonly TranlateHexFlatDirectionTest[] m_TranslateHexFlatDirectionTests = new TranlateHexFlatDirectionTest[]
		{
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.Up, 1, 3, 2),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.UpRight, 1, 4, 3),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.DownRight, 1, 4, 4),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.Down, 1, 3, 4),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.DownLeft, 1, 2, 4),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.UpLeft, 1, 2, 3),

			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.Up, 2, 3, 1),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.UpRight, 2, 5, 2),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.DownRight, 2, 5, 4),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.Down, 2, 3, 5),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.DownLeft, 2, 1, 4),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.UpLeft, 2, 1, 2),

			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.Up, 3, 3, 0),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.UpRight, 3, 6, 2),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.DownRight, 3, 6, 5),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.Down, 3, 3, 6),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.DownLeft, 3, 0, 5),
			new TranlateHexFlatDirectionTest(3, 3, EHexFlatDirection.UpLeft, 3, 0, 2),

			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.Up, 1, 4, 2),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.UpRight, 1, 5, 2),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.DownRight, 1, 5, 3),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.Down, 1, 4, 4),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.DownLeft, 1, 3, 3),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.UpLeft, 1, 3, 2),

			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.Up, 2, 4, 1),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.UpRight, 2, 6, 2),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.DownRight, 2, 6, 4),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.Down, 2, 4, 5),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.DownLeft, 2, 2, 4),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.UpLeft, 2, 2, 2),

			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.Up, 3, 4, 0),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.UpRight, 3, 7, 1),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.DownRight, 3, 7, 4),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.Down, 3, 4, 6),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.DownLeft, 3, 1, 4),
			new TranlateHexFlatDirectionTest(4, 3, EHexFlatDirection.UpLeft, 3, 1, 1),

		};

		[Test, TestCaseSource(nameof(m_TranslateHexFlatDirectionTests))]
		public void Translate_HexFlatDirection(TranlateHexFlatDirectionTest test)
		{
			test.Run();
		}
		#endregion

		#region TranslateHexPointyDirection
		public class TranslateHexPointyDirectionTest : ATranslateTest<EHexPointyDirection>
		{
			public TranslateHexPointyDirectionTest(int originX, int originY, EHexPointyDirection direction, int distance, int expectedX, int expectedY)
				: base(new GridPoint2D(originX, originY), direction, distance, new GridPoint2D(expectedX, expectedY))

			{
			}

			public override GridPoint2D Translate(GridPoint2D point, EHexPointyDirection direction, int distance)
			{
				return point.Translate(direction, distance);
			}
		}

		private static readonly TranslateHexPointyDirectionTest[] m_TranslateHexPointyDirectionTests = new TranslateHexPointyDirectionTest[]
		{
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.UpRight, 1, 4, 2),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.Right, 1, 4, 3),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.DownRight, 1, 4, 4),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.DownLeft, 1, 3, 4),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.Left, 1, 2, 3),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.UpLeft, 1, 3, 2),

			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.UpRight, 2, 4, 1),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.Right, 2, 5, 3),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.DownRight, 2, 4, 5),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.DownLeft, 2, 2, 5),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.Left, 2, 1, 3),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.UpLeft, 2, 2, 1),

			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.UpRight, 3, 5, 0),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.Right, 3, 6, 3),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.DownRight, 3, 5, 6),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.DownLeft, 3, 2, 6),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.Left, 3, 0, 3),
			new TranslateHexPointyDirectionTest(3, 3, EHexPointyDirection.UpLeft, 3, 2, 0),

			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.UpRight, 1, 3, 3),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.Right, 1, 4, 4),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.DownRight, 1, 3, 5),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.DownLeft, 1, 2, 5),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.Left, 1, 2, 4),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.UpLeft, 1, 2, 3),

			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.UpRight, 2, 4, 2),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.Right, 2, 5, 4),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.DownRight, 2, 4, 6),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.DownLeft, 2, 2, 6),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.Left, 2, 1, 4),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.UpLeft, 2, 2, 2),

			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.UpRight, 3, 4, 1),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.Right, 3, 6, 4),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.DownRight, 3, 4, 7),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.DownLeft, 3, 1, 7),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.Left, 3, 0, 4),
			new TranslateHexPointyDirectionTest(3, 4, EHexPointyDirection.UpLeft, 3, 1, 1),
		};

		[Test, TestCaseSource(nameof(m_TranslateHexPointyDirectionTests))]
		public void Translate_HexPointyDirection(TranslateHexPointyDirectionTest test)
		{
			test.Run();
		}
		#endregion
		#endregion

		#region IsNeighbour
		public abstract class AIsNeighbourTest
		{
			public readonly GridPoint2D A;
			public readonly GridPoint2D B;
			public readonly bool Expected;

			public AIsNeighbourTest(GridPoint2D a, bool expected, GridPoint2D b)
			{
				A = a;
				B = b;
				Expected = expected;
			}

			public void Run()
			{
				bool actual = IsNeighbour(A, B);
				Assert.AreEqual(Expected, actual);
			}

			protected abstract bool IsNeighbour(GridPoint2D a, GridPoint2D b);

			public override string ToString()
			{
				if(Expected)
				{
					return $"{A} is neighbour of {B}";
				}
				return $"{A} is not neighbour of {B}";
			}
		}

		#region IsGridNeighbour
		public class IsGridNeighbourTest : AIsNeighbourTest
		{
			public IsGridNeighbourTest(GridPoint2D a, bool expected, GridPoint2D b)
				: base(a, expected, b)
			{
			}

			protected override bool IsNeighbour(GridPoint2D a, GridPoint2D b)
			{
				return a.IsGridNeighour(b);
			}
		}

		private static IEnumerable<IsGridNeighbourTest> GetIsGridNeighbourTests()
		{
			EGridDirection2D[] directions = EGridDirection2DExt.Meta.Values;
			GridPoint2D origin = new GridPoint2D(2, 2);
			foreach(EGridDirection2D direction in directions)
			{
				yield return new IsGridNeighbourTest(origin, true, origin.Translate(direction));

			}

			GridPoint2D current = origin.Translate(EGridDirection2D.DownLeft, 2);
			EGridCardinal2D[] cardinals = EGridCardinal2DExt.Meta.Values;
			foreach(EGridCardinal2D direction in cardinals)
			{
				for(int x = 0; x < 4; ++x)
				{
					current = current.Translate(direction);
					yield return new IsGridNeighbourTest(origin, false, current);
				}
			}
		}

		[Test, TestCaseSource(nameof(GetIsGridNeighbourTests))]
		public void IsNeighbour_Grid(IsGridNeighbourTest test)
		{
			test.Run();
		}
		#endregion

		#region IsHexFlatNeighbour
		public class IsHexFlatNeighbourTest : AIsNeighbourTest
		{
			public IsHexFlatNeighbourTest(GridPoint2D a, bool expected, GridPoint2D b)
				: base(a, expected, b)
			{
			}

			protected override bool IsNeighbour(GridPoint2D a, GridPoint2D b)
			{
				return a.IsHexFlatNeighbour(b);
			}
		}

		private static IEnumerable<IsHexFlatNeighbourTest> GetIsHexFlatNeighbourTests()
		{
			foreach(IsHexFlatNeighbourTest test in GenerateIsHexFlatNeighbourTests(new GridPoint2D(3, 3)))
			{
				yield return test;
			}

			foreach(IsHexFlatNeighbourTest test in GenerateIsHexFlatNeighbourTests(new GridPoint2D(4, 3)))
			{
				yield return test;
			}
		}

		private static IEnumerable<IsHexFlatNeighbourTest> GenerateIsHexFlatNeighbourTests(GridPoint2D origin)
		{
			EHexFlatDirection[] directions = EHexFlatDirectionExt.Meta.Values;
			foreach(EHexFlatDirection direction in directions)
			{
				yield return new IsHexFlatNeighbourTest(origin, true, origin.Translate(direction));
			}

			GridPoint2D current = origin.Translate(EHexFlatDirection.DownLeft, 2);
			foreach(EHexFlatDirection direction in directions)
			{
				for(int x = 0; x < 2; ++x)
				{
					current = current.Translate(direction);
					yield return new IsHexFlatNeighbourTest(origin, false, current);
				}
			}
		}

		[Test, TestCaseSource(nameof(GetIsHexFlatNeighbourTests))]
		public void IsNeighbour_HexFlat(IsHexFlatNeighbourTest test)
		{
			test.Run();
		}
		#endregion

		#region IsHexPointyNeighbour
		public class IsHexPointyNeighbourTest : AIsNeighbourTest
		{
			public IsHexPointyNeighbourTest(GridPoint2D a, bool expected, GridPoint2D b)
				: base(a, expected, b)
			{
			}

			protected override bool IsNeighbour(GridPoint2D a, GridPoint2D b)
			{
				return a.IsHexPointyNeighbour(b);
			}
		}

		private static IEnumerable<IsHexPointyNeighbourTest> GetIsHexPointyNeighbourTests()
		{
			foreach(IsHexPointyNeighbourTest test in GenerateIsHexPointyNeighbourTests(new GridPoint2D(3, 3)))
			{
				yield return test;
			}

			foreach(IsHexPointyNeighbourTest test in GenerateIsHexPointyNeighbourTests(new GridPoint2D(3, 4)))
			{
				yield return test;
			}
		}

		private static IEnumerable<IsHexPointyNeighbourTest> GenerateIsHexPointyNeighbourTests(GridPoint2D origin)
		{
			EHexPointyDirection[] directions = EHexPointyDirectionExt.Meta.Values;
			foreach(EHexPointyDirection direction in directions)
			{
				yield return new IsHexPointyNeighbourTest(origin, true, origin.Translate(direction));
			}

			GridPoint2D current = origin.Translate(EHexPointyDirection.Left, 2);
			foreach(EHexPointyDirection direction in directions)
			{
				for(int x = 0; x < 2; ++x)
				{
					current = current.Translate(direction);
					yield return new IsHexPointyNeighbourTest(origin, false, current);
				}
			}
		}

		[Test, TestCaseSource(nameof(GetIsHexPointyNeighbourTests))]
		public void IsNeighbour_HexPointy(IsHexPointyNeighbourTest test)
		{
			test.Run();
		}
		#endregion
		#endregion

		#region GetGridDirection
		public class GetGridDirectionTest
		{
			public readonly GridPoint2D Origin;
			public readonly GridPoint2D Target;
			public readonly EGridDirection2D Expected;

			public GetGridDirectionTest(int originX, int originY, EGridDirection2D expected, int targetX, int targetY)
			{
				Origin = new GridPoint2D(originX, originY);
				Expected = expected;
				Target = new GridPoint2D(targetX, targetY);
			}

			public GetGridDirectionTest(EGridDirection2D expected, int targetX, int targetY)
				: this(0, 0, expected, targetX, targetY)
			{
			}

			public void Run()
			{
				EGridDirection2D actual = Origin.GetGridDirection(Target);
				Assert.AreEqual(Expected, actual);
			}

			public override string ToString()
			{
				return $"{Target} is {Expected} from {Origin}";
			}
		}

		private static readonly GetGridDirectionTest[] m_GetGridDirectionTests = new GetGridDirectionTest[]
		{
			new GetGridDirectionTest(EGridDirection2D.Up, 0, -1),
			new GetGridDirectionTest(EGridDirection2D.UpRight, 1, -1),
			new GetGridDirectionTest(EGridDirection2D.Right, 1, 0),
			new GetGridDirectionTest(EGridDirection2D.DownRight, 1, 1),
			new GetGridDirectionTest(EGridDirection2D.Down, 0, 1),
			new GetGridDirectionTest(EGridDirection2D.DownLeft, -1, 1),
			new GetGridDirectionTest(EGridDirection2D.Left, -1, 0),
			new GetGridDirectionTest(EGridDirection2D.UpLeft, -1, -1),
		};

		[Test, TestCaseSource(nameof(m_GetGridDirectionTests))]
		public void GetGridDirection(GetGridDirectionTest test)
		{
			test.Run();
		}
		#endregion

		[Test]
		public void Get()
		{
			GridPoint2D point = new GridPoint2D(1, 2);
			Assert.AreEqual(1, point.Get(EGridAxis2D.X));
			Assert.AreEqual(2, point.Get(EGridAxis2D.Y));
		}

		[Test]
		public void Set()
		{
			GridPoint2D point = new GridPoint2D()
				.Set(EGridAxis2D.X, 1)
				.Set(EGridAxis2D.Y, 2);
			Assert.AreEqual(1, point.X);
			Assert.AreEqual(2, point.Y);
		}

		[Test]
		public void Add()
		{
			GridPoint2D point = new GridPoint2D(1, 2);
			GridPoint2D result = point.Add(new GridPoint2D(1, 2));
			Assert.AreEqual(new GridPoint2D(2, 4), result);
		}

		[Test]
		public void Subtract()
		{
			GridPoint2D point = new GridPoint2D(1, 2);
			GridPoint2D result = point.Subtract(new GridPoint2D(1, 2));
			Assert.AreEqual(new GridPoint2D(0, 0), result);
		}

		#region MinTest
		public class MinTest
		{
			public readonly GridPoint2D Source;
			public readonly GridPoint2D Other;
			public readonly GridPoint2D Expected;

			public MinTest(GridPoint2D source, GridPoint2D other, GridPoint2D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridPoint2D result = Source.Min(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Min({Other}) -> {Expected}";
			}
		}

		private static readonly MinTest[] m_MinTests = new MinTest[]
		{
			new MinTest(new GridPoint2D(1, 2), new GridPoint2D(-1, -2), new GridPoint2D(-1, -2)),
			new MinTest(new GridPoint2D(-1, -2), new GridPoint2D(1, 2), new GridPoint2D(-1, -2)),
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
			public readonly GridPoint2D Source;
			public readonly GridPoint2D Other;
			public readonly GridPoint2D Expected;

			public MaxTest(GridPoint2D source, GridPoint2D other, GridPoint2D expected)
			{
				Source = source;
				Other = other;
				Expected = expected;
			}

			public void Run()
			{
				GridPoint2D result = Source.Max(Other);
				Assert.AreEqual(result, Expected);
			}

			public override string ToString()
			{
				return $"{Source}.Max({Other}) -> {Expected}";
			}
		}

		private static readonly MaxTest[] m_MaxTests = new MaxTest[]
		{
			new MaxTest(new GridPoint2D(1, 2), new GridPoint2D(-1, -2), new GridPoint2D(1, 2)),
			new MaxTest(new GridPoint2D(-1, -2), new GridPoint2D(1, 2), new GridPoint2D(1, 2)),
		};

		[Test, TestCaseSource(nameof(m_MaxTests))]
		public void Max(MaxTest test)
		{
			test.Run();
		}
		#endregion
	}
}
