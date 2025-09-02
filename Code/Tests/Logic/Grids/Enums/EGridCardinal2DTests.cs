using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EGridCardinal2DTests
	{
		public class TransformTest : TransformTest<EGridCardinal2D, EGridCardinal2D>
		{
			public TransformTest(TransformCallback callback, EGridCardinal2D source, EGridCardinal2D expected)
				: base(callback, source, expected)
			{
			}
		}

		public class AxisTest : TransformTest<EGridCardinal2D, EGridAxis2D>
		{
			public AxisTest(TransformCallback callback, EGridCardinal2D source, EGridAxis2D expected)
				: base(callback, source, expected)
			{
			}
		}

		#region ToGridDirection
		public class ToGridDirectionTest : TransformTest<EGridCardinal2D, EGridDirection2D>
		{
			public ToGridDirectionTest(EGridCardinal2D source, EGridDirection2D expected)
				: base(EGridCardinal2DExt.ToGridDirection, source, expected)
			{
			}
		}

		private static ToGridDirectionTest[] m_ToGridDirectionTests = new ToGridDirectionTest[]
		{
			new ToGridDirectionTest(EGridCardinal2D.Up, EGridDirection2D.Up),
			new ToGridDirectionTest(EGridCardinal2D.Right, EGridDirection2D.Right),
			new ToGridDirectionTest(EGridCardinal2D.Down, EGridDirection2D.Down),
			new ToGridDirectionTest(EGridCardinal2D.Left, EGridDirection2D.Left)
		};

		[Test, TestCaseSource(nameof(m_ToGridDirectionTests))]
		public void ToGridDirection(ToGridDirectionTest test)
		{
			test.Run();
		}
		#endregion

		#region GetOpposite
		private static readonly TransformTest[] m_GetOppositeTests = new TransformTest[]
		{
			new TransformTest(EGridCardinal2DExt.GetOpposite, EGridCardinal2D.Up, EGridCardinal2D.Down),
			new TransformTest(EGridCardinal2DExt.GetOpposite, EGridCardinal2D.Right, EGridCardinal2D.Left),
			new TransformTest(EGridCardinal2DExt.GetOpposite, EGridCardinal2D.Down, EGridCardinal2D.Up),
			new TransformTest(EGridCardinal2DExt.GetOpposite, EGridCardinal2D.Left, EGridCardinal2D.Right),
		};

		[Test, TestCaseSource(nameof(m_GetOppositeTests))]
		public void GetOpposite(TransformTest test)
		{
			test.Run();
		}
		#endregion

		#region GetClockwise
		private static readonly TransformTest[] m_GetClockwiseTests = new TransformTest[]
		{
			new TransformTest(EGridCardinal2DExt.GetClockwise, EGridCardinal2D.Up, EGridCardinal2D.Right),
			new TransformTest(EGridCardinal2DExt.GetClockwise, EGridCardinal2D.Right, EGridCardinal2D.Down),
			new TransformTest(EGridCardinal2DExt.GetClockwise, EGridCardinal2D.Down, EGridCardinal2D.Left),
			new TransformTest(EGridCardinal2DExt.GetClockwise, EGridCardinal2D.Left, EGridCardinal2D.Up),
		};

		[Test, TestCaseSource(nameof(m_GetClockwiseTests))]
		public void GetClockwise(TransformTest test)
		{
			test.Run();
		}
		#endregion

		#region GetCounterClockwise
		private static readonly TransformTest[] m_GetCounterClockwise = new TransformTest[]
		{
			new TransformTest(EGridCardinal2DExt.GetCounterClockwise, EGridCardinal2D.Up, EGridCardinal2D.Left),
			new TransformTest(EGridCardinal2DExt.GetCounterClockwise, EGridCardinal2D.Right, EGridCardinal2D.Up),
			new TransformTest(EGridCardinal2DExt.GetCounterClockwise, EGridCardinal2D.Down, EGridCardinal2D.Right),
			new TransformTest(EGridCardinal2DExt.GetCounterClockwise, EGridCardinal2D.Left, EGridCardinal2D.Down),
		};

		[Test, TestCaseSource(nameof(m_GetCounterClockwise))]
		public void GetCounterClockwise(TransformTest test)
		{
			test.Run();
		}
		#endregion

		#region ToAxis
		private static readonly AxisTest[] m_ToAxis = new AxisTest[]
		{
			new AxisTest(EGridCardinal2DExt.ToAxis, EGridCardinal2D.Up, EGridAxis2D.Y),
			new AxisTest(EGridCardinal2DExt.ToAxis, EGridCardinal2D.Down, EGridAxis2D.Y),
			new AxisTest(EGridCardinal2DExt.ToAxis, EGridCardinal2D.Left, EGridAxis2D.X),
			new AxisTest(EGridCardinal2DExt.ToAxis, EGridCardinal2D.Right, EGridAxis2D.X),
		};

		[Test, TestCaseSource(nameof(m_ToAxis))]
		public void ToAxis(AxisTest test)
		{
			test.Run();
		}
		#endregion
	}
}
