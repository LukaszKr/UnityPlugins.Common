using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EGridAxis2DTests
	{
		public class TransformTest : TransformTest<EGridAxis2D, EGridAxis2D>
		{
			public TransformTest(TransformCallback callback, EGridAxis2D source, EGridAxis2D expected)
				: base(callback, source, expected)
			{
			}
		}

		#region GetOther
		private static readonly TransformTest[] m_GetOtherTests = new TransformTest[]
		{
			new TransformTest(EGridAxis2DExt.GetOther, EGridAxis2D.X, EGridAxis2D.Y),
			new TransformTest(EGridAxis2DExt.GetOther, EGridAxis2D.Y, EGridAxis2D.X),
		};

		[Test, TestCaseSource(nameof(m_GetOtherTests))]
		public void GetOther(TransformTest test)
		{
			test.Run();
		}
		#endregion

		#region ToGridCardinals
		public class ToGridCardinalsTest
		{
			public readonly EGridAxis2D Axis;
			public readonly EGridCardinal2D[] Expected;

			public ToGridCardinalsTest(EGridAxis2D axis, params EGridCardinal2D[] expected)
			{
				Axis = axis;
				Expected = expected;
			}

			public void Run()
			{
				EGridCardinal2D[] result = Axis.ToGridCardinals();

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
			new ToGridCardinalsTest(EGridAxis2D.X, EGridCardinal2D.Right, EGridCardinal2D.Left),
			new ToGridCardinalsTest(EGridAxis2D.Y, EGridCardinal2D.Up, EGridCardinal2D.Down),
		};

		[Test, TestCaseSource(nameof(m_ToGridCardinalsTests))]
		public void ToGridCardinals(ToGridCardinalsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
