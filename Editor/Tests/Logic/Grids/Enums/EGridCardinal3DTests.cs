using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EGridCardinal3DTests
	{
		public class TransformTest : TransformTest<EGridCardinal3D, EGridCardinal3D>
		{
			public TransformTest(TransformCallback callback, EGridCardinal3D source, EGridCardinal3D expected)
				: base(callback, source, expected)
			{
			}
		}

		public class AxisTest : TransformTest<EGridCardinal3D, EGridAxis3D>
		{
			public AxisTest(TransformCallback callback, EGridCardinal3D source, EGridAxis3D expected)
				: base(callback, source, expected)
			{
			}
		}

		#region GetOpposite
		private static readonly TransformTest[] m_GetOppositeTests = new TransformTest[]
		{
			new TransformTest(EGridCardinal3DExt.GetOpposite, EGridCardinal3D.Up, EGridCardinal3D.Down),
			new TransformTest(EGridCardinal3DExt.GetOpposite, EGridCardinal3D.Down, EGridCardinal3D.Up),
			new TransformTest(EGridCardinal3DExt.GetOpposite, EGridCardinal3D.Left, EGridCardinal3D.Right),
			new TransformTest(EGridCardinal3DExt.GetOpposite, EGridCardinal3D.Right, EGridCardinal3D.Left),
			new TransformTest(EGridCardinal3DExt.GetOpposite, EGridCardinal3D.Front, EGridCardinal3D.Back),
			new TransformTest(EGridCardinal3DExt.GetOpposite, EGridCardinal3D.Back, EGridCardinal3D.Front),
		};

		[Test, TestCaseSource(nameof(m_GetOppositeTests))]
		public void GetOpposite(TransformTest test)
		{
			test.Run();
		}
		#endregion

		#region ToAxis
		private static readonly AxisTest[] m_ToAxis = new AxisTest[]
		{
			new AxisTest(EGridCardinal3DExt.ToAxis, EGridCardinal3D.Up, EGridAxis3D.Y),
			new AxisTest(EGridCardinal3DExt.ToAxis, EGridCardinal3D.Down, EGridAxis3D.Y),
			new AxisTest(EGridCardinal3DExt.ToAxis, EGridCardinal3D.Left, EGridAxis3D.X),
			new AxisTest(EGridCardinal3DExt.ToAxis, EGridCardinal3D.Right, EGridAxis3D.X),
			new AxisTest(EGridCardinal3DExt.ToAxis, EGridCardinal3D.Front, EGridAxis3D.Z),
			new AxisTest(EGridCardinal3DExt.ToAxis, EGridCardinal3D.Back, EGridAxis3D.Z),
		};

		[Test, TestCaseSource(nameof(m_ToAxis))]
		public void ToAxis(AxisTest test)
		{
			test.Run();
		}
		#endregion
	}
}
