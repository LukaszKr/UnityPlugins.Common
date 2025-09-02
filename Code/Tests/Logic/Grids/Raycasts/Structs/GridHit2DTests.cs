using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Raycasts
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridHit2DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridHit2D>
		{
			public EqualsTest(bool areEqual, GridHit2D a, GridHit2D b)
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
			new EqualsTest(true, new GridHit2D(1, 2, EGridCardinal2D.Right), new GridHit2D(1, 2, EGridCardinal2D.Right)),

			new EqualsTest(false, new GridHit2D(1, 2, EGridCardinal2D.Right), new GridHit2D(1, 5, EGridCardinal2D.Right)),
			new EqualsTest(false, new GridHit2D(1, 2, EGridCardinal2D.Right), new GridHit2D(1, 2, EGridCardinal2D.Down)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
