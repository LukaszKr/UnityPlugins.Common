using System;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public abstract class ASingletonComponent<TObject> : ExtendedMonoBehaviour
		where TObject : ASingletonComponent<TObject>
	{
		[NonSerialized]
		public static TObject Instance;

		public ASingletonComponent()
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
