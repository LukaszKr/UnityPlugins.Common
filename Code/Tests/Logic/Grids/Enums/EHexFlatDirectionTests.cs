using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Enums
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class EHexFlatDirectionTests
	{
		public class TransformTest : TransformTest<EHexFlatDirection, EHexFlatDirection>
		{
			public TransformTest(TransformCallback callback, EHexFlatDirection source, EHexFlatDirection expected)
				: base(callback, source, expected)
			{
			}
		}

		#region GetOpposite
		private static readonly TransformTest[] m_GetOppositeTests = new TransformTest[]
		{
			new TransformTest(EHexFlatDirectionExt.GetOpposite, EHexFlatDirection.Up, EHexFlatDirection.Down),
			new TransformTest(EHexFlatDirectionExt.GetOpposite, EHexFlatDirection.UpRight, EHexFlatDirection.DownLeft),
			new TransformTest(EHexFlatDirectionExt.GetOpposite, EHexFlatDirection.DownRight, EHexFlatDirection.UpLeft),
			new TransformTest(EHexFlatDirectionExt.GetOpposite, EHexFlatDirection.Down, EHexFlatDirection.Up),
			new TransformTest(EHexFlatDirectionExt.GetOpposite, EHexFlatDirection.DownLeft, EHexFlatDirection.UpRight),
			new TransformTest(EHexFlatDirectionExt.GetOpposite, EHexFlatDirection.UpLeft, EHexFlatDirection.DownRight),
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
			new TransformTest(EHexFlatDirectionExt.GetClockwise, EHexFlatDirection.Up, EHexFlatDirection.UpRight),
			new TransformTest(EHexFlatDirectionExt.GetClockwise, EHexFlatDirection.UpRight, EHexFlatDirection.DownRight),
			new TransformTest(EHexFlatDirectionExt.GetClockwise, EHexFlatDirection.DownRight, EHexFlatDirection.Down),
			new TransformTest(EHexFlatDirectionExt.GetClockwise, EHexFlatDirection.Down, EHexFlatDirection.DownLeft),
			new TransformTest(EHexFlatDirectionExt.GetClockwise, EHexFlatDirection.DownLeft, EHexFlatDirection.UpLeft),
			new TransformTest(EHexFlatDirectionExt.GetClockwise, EHexFlatDirection.UpLeft, EHexFlatDirection.Up),
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
			new TransformTest(EHexFlatDirectionExt.GetCounterClockwise, EHexFlatDirection.Up, EHexFlatDirection.UpLeft),
			new TransformTest(EHexFlatDirectionExt.GetCounterClockwise, EHexFlatDirection.UpRight, EHexFlatDirection.Up),
			new TransformTest(EHexFlatDirectionExt.GetCounterClockwise, EHexFlatDirection.DownRight, EHexFlatDirection.UpRight),
			new TransformTest(EHexFlatDirectionExt.GetCounterClockwise, EHexFlatDirection.Down, EHexFlatDirection.DownRight),
			new TransformTest(EHexFlatDirectionExt.GetCounterClockwise, EHexFlatDirection.DownLeft, EHexFlatDirection.Down),
			new TransformTest(EHexFlatDirectionExt.GetCounterClockwise, EHexFlatDirection.UpLeft, EHexFlatDirection.DownLeft),
		};

		[Test, TestCaseSource(nameof(m_GetCounterClockwise))]
		public void GetCounterClockwise(TransformTest test)
		{
			test.Run();
		}
		#endregion
	}
}
