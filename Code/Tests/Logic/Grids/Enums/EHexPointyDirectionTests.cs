using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EHexPointyDirectionTests
	{
		public class TransformTest : TransformTest<EHexPointyDirection, EHexPointyDirection>
		{
			public TransformTest(TransformCallback callback, EHexPointyDirection source, EHexPointyDirection expected)
				: base(callback, source, expected)
			{
			}
		}

		#region GetOpposite
		private static readonly TransformTest[] m_GetOppositeTests = new TransformTest[]
		{
			new TransformTest(EHexPointyDirectionExt.GetOpposite, EHexPointyDirection.UpRight, EHexPointyDirection.DownLeft),
			new TransformTest(EHexPointyDirectionExt.GetOpposite, EHexPointyDirection.Right, EHexPointyDirection.Left),
			new TransformTest(EHexPointyDirectionExt.GetOpposite, EHexPointyDirection.DownRight, EHexPointyDirection.UpLeft),
			new TransformTest(EHexPointyDirectionExt.GetOpposite, EHexPointyDirection.DownLeft, EHexPointyDirection.UpRight),
			new TransformTest(EHexPointyDirectionExt.GetOpposite, EHexPointyDirection.Left, EHexPointyDirection.Right),
			new TransformTest(EHexPointyDirectionExt.GetOpposite, EHexPointyDirection.UpLeft, EHexPointyDirection.DownRight),
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
			new TransformTest(EHexPointyDirectionExt.GetClockwise, EHexPointyDirection.UpRight, EHexPointyDirection.Right),
			new TransformTest(EHexPointyDirectionExt.GetClockwise, EHexPointyDirection.Right, EHexPointyDirection.DownRight),
			new TransformTest(EHexPointyDirectionExt.GetClockwise, EHexPointyDirection.DownRight, EHexPointyDirection.DownLeft),
			new TransformTest(EHexPointyDirectionExt.GetClockwise, EHexPointyDirection.DownLeft, EHexPointyDirection.Left),
			new TransformTest(EHexPointyDirectionExt.GetClockwise, EHexPointyDirection.Left, EHexPointyDirection.UpLeft),
			new TransformTest(EHexPointyDirectionExt.GetClockwise, EHexPointyDirection.UpLeft, EHexPointyDirection.UpRight),
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
			new TransformTest(EHexPointyDirectionExt.GetCounterClockwise, EHexPointyDirection.UpRight, EHexPointyDirection.UpLeft),
			new TransformTest(EHexPointyDirectionExt.GetCounterClockwise, EHexPointyDirection.Right, EHexPointyDirection.UpRight),
			new TransformTest(EHexPointyDirectionExt.GetCounterClockwise, EHexPointyDirection.DownRight, EHexPointyDirection.Right),
			new TransformTest(EHexPointyDirectionExt.GetCounterClockwise, EHexPointyDirection.DownLeft, EHexPointyDirection.DownRight),
			new TransformTest(EHexPointyDirectionExt.GetCounterClockwise, EHexPointyDirection.Left, EHexPointyDirection.DownLeft),
			new TransformTest(EHexPointyDirectionExt.GetCounterClockwise, EHexPointyDirection.UpLeft, EHexPointyDirection.Left),
		};

		[Test, TestCaseSource(nameof(m_GetCounterClockwise))]
		public void GetCounterClockwise(TransformTest test)
		{
			test.Run();
		}
		#endregion
	}
}
