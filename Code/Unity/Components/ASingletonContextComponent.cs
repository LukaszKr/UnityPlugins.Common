using System;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public abstract class ASingletonContextComponent<TObject, TContext> : AContextComponent<TContext>
		where TObject : ASingletonContextComponent<TObject, TContext>
	{
		[NonSerialized]
		public static TObject Instance;

		public ASingletonContextComponent()
		{
			Instance = this as TObject;
		}

		protected virtual void OnDestroy()
		{
			GameAssert.AreEqual(this, Instance);
			Instance = null;
		}
	}
}
