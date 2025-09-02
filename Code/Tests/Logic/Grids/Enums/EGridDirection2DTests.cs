using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EGridDirection2DTests
	{
		public class TransformTest : TransformTest<EGridDirection2D, EGridDirection2D>
		{
			public TransformTest(TransformCallback callback, EGridDirection2D source, EGridDirection2D expected)
				: base(callback, source, expected)
			{
			}
		}

		public class AxisTest : TransformTest<EGridDirection2D, EGridAxis2D>
		{
			public AxisTest(TransformCallback callback, EGridDirection2D source, EGridAxis2D expected)
				: base(callback, source, expected)
			{
			}
		}

		#region GetOpposite
		private static readonly TransformTest[] m_GetOppositeTests = new TransformTest[]
		{
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.Up, EGridDirection2D.Down),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.UpRight, EGridDirection2D.DownLeft),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.Right, EGridDirection2D.Left),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.DownRight, EGridDirection2D.UpLeft),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.Down, EGridDirection2D.Up),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.DownLeft, EGridDirection2D.UpRight),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.Left, EGridDirection2D.Right),
			new TransformTest(EGridDirection2DExt.GetOpposite, EGridDirection2D.UpLeft, EGridDirection2D.DownRight),
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
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.Up, EGridDirection2D.UpRight),
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.UpRight, EGridDirection2D.Right),
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.Right, EGridDirection2D.DownRight),
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.DownRight, EGridDirection2D.Down),
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.Down, EGridDirection2D.DownLeft),
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.DownLeft, EGridDirection2D.Left),
			new TransformTest(EGridDirection2DExt.GetClockwise, EGridDirection2D.Left, EGridDirection2D.UpLeft),
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
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.Up, EGridDirection2D.UpLeft),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.UpRight, EGridDirection2D.Up),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.Right, EGridDirection2D.UpRight),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.DownRight, EGridDirection2D.Right),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.Down, EGridDirection2D.DownRight),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.DownLeft, EGridDirection2D.Down),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.Left, EGridDirection2D.DownLeft),
			new TransformTest(EGridDirection2DExt.GetCounterClockwise, EGridDirection2D.UpLeft, EGridDirection2D.Left),
		};

		[Test, TestCaseSource(nameof(m_GetCounterClockwise))]
		public void GetCounterClockwise(TransformTest test)
		{
			test.Run();
		}
		#endregion
	}
}
