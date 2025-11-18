using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EGridAxis3DTests
	{
		public class TransformTest : TransformTest<EGridAxis3D, EGridAxis3D>
		{
			public TransformTest(TransformCallback callback, EGridAxis3D source, EGridAxis3D expected)
				: base(callback, source, expected)
			{
			}
		}

		#region GetThird
		public class GetThirdTest
		{
			public readonly EGridAxis3D AxisA;
			public readonly EGridAxis3D AxisB;
			public readonly EGridAxis3D Expected;

			public GetThirdTest(EGridAxis3D axisA, EGridAxis3D axisB, EGridAxis3D expected)
			{
				AxisA = axisA;
				AxisB = axisB;
				Expected = expected;
			}

			public void Run()
			{
				Assert.AreEqual(Expected, AxisA.GetThird(AxisB));
			}

			public override string ToString()
			{
				return $"{AxisA}:{AxisB} -> {Expected}";
			}
		}

		private static readonly GetThirdTest[] m_GetThirdTests = new GetThirdTest[]
		{
			new GetThirdTest(EGridAxis3D.X, EGridAxis3D.Y, EGridAxis3D.Z),
			new GetThirdTest(EGridAxis3D.Y, EGridAxis3D.X, EGridAxis3D.Z),
			new GetThirdTest(EGridAxis3D.Z, EGridAxis3D.Y, EGridAxis3D.X),
			new GetThirdTest(EGridAxis3D.Y, EGridAxis3D.Z, EGridAxis3D.X),
			new GetThirdTest(EGridAxis3D.Z, EGridAxis3D.X, EGridAxis3D.Y),
			new GetThirdTest(EGridAxis3D.X, EGridAxis3D.Z, EGridAxis3D.Y),
		};

		[Test, TestCaseSource(nameof(m_GetThirdTests))]
		public void GetThird(GetThirdTest test)
		{
			test.Run();
		}
		#endregion

		#region ToGridCardinals
		public class ToGridCardinalsTest
		{
			public readonly EGridAxis3D Axis;
			public readonly EGridCardinal3D[] Expected;

			public ToGridCardinalsTest(EGridAxis3D axis, params EGridCardinal3D[] expected)
			{
				Axis = axis;
				Expected = expected;
			}

			public void Run()
			{
				EGridCardinal3D[] result = Axis.ToGridCardinals();

				Assert.AreEqual(Expected.Length, result.Length);
				for(int x = 0; x < Expected.Length; ++x)
				{
					Assert.AreEqual(Expected[x], result[x]);
				}
			}

			public override string ToString()
			{
				return $"{Axis} -> [{string.Join(',', Expected)}]";
			}
		}

		private static readonly ToGridCardinalsTest[] m_ToGridCardinalsTests = new ToGridCardinalsTest[]
		{
			new ToGridCardinalsTest(EGridAxis3D.X, EGridCardinal3D.Right, EGridCardinal3D.Left),
			new ToGridCardinalsTest(EGridAxis3D.Y, EGridCardinal3D.Up, EGridCardinal3D.Down),
			new ToGridCardinalsTest(EGridAxis3D.Z, EGridCardinal3D.Front, EGridCardinal3D.Back),
		};

		[Test, TestCaseSource(nameof(m_ToGridCardinalsTests))]
		public void ToGridCardinals(ToGridCardinalsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
