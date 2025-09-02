using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Observables
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class ObservableTests
	{
		[Test]
		public void Set_DifferentValue()
		{
			bool wasCalled = false;
			Observable<int> target = new Observable<int>();
			target.OnChanged.AddListener((v) => { wasCalled = true; });
			target.Set(1);
			Assert.IsTrue(wasCalled);
		}

		[Test]
		public void Set_SameValue()
		{
			bool wasCalled = false;
			Observable<int> target = new Observable<int>(0);
			target.OnChanged.AddListener((v) => { wasCalled = true; });
			target.Set(0);
			Assert.IsFalse(wasCalled);
		}

		[Test]
		public void SetSilient_DifferentValue()
		{
			bool wasCalled = false;
			Observable<int> target = new Observable<int>();
			target.OnChanged.AddListener((v) => { wasCalled = true; });
			target.SetSilient(1);
			Assert.IsFalse(wasCalled);
		}
	}
}
