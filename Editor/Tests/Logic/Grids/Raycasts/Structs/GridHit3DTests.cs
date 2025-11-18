using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Raycasts
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridHit3DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridHit3D>
		{
			public EqualsTest(bool areEqual, GridHit3D a, GridHit3D b)
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
			new EqualsTest(true, new GridHit3D(1, 2, 3, EGridCardinal3D.Right), new GridHit3D(1, 2, 3, EGridCardinal3D.Right)),

			new EqualsTest(false, new GridHit3D(1, 2, 3, EGridCardinal3D.Right), new GridHit3D(1, 5, 3, EGridCardinal3D.Right)),
			new EqualsTest(false, new GridHit3D(1, 2, 3, EGridCardinal3D.Right), new GridHit3D(1, 2, 3, EGridCardinal3D.Down)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
