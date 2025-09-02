using NUnit.Framework;
using UnityPlugins.Common.Tests;

namespace UnityPlugins.Common.Logic.Grids.Structs
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GridPlane3DTests
	{
		#region Equals
		public class EqualsTest : EqualsTest<GridPlane3D>
		{
			public EqualsTest(bool areEqual, GridPlane3D a, GridPlane3D b)
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
			new EqualsTest(true, new GridPlane3D(EGridAxis3D.X, EGridAxis3D.Y), new GridPlane3D(EGridAxis3D.X, EGridAxis3D.Y)),

			new EqualsTest(false, new GridPlane3D(EGridAxis3D.X, EGridAxis3D.Y), new GridPlane3D(EGridAxis3D.Z, EGridAxis3D.Y)),
			new EqualsTest(false, new GridPlane3D(EGridAxis3D.X, EGridAxis3D.Y), new GridPlane3D(EGridAxis3D.X, EGridAxis3D.Z)),
		};

		[Test, TestCaseSource(nameof(m_EqualsTests))]
		public void Equals(EqualsTest test)
		{
			test.Run();
		}
		#endregion
	}
}
