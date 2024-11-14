using System;

namespace UnityPlugins.Common.Unity
{
	public abstract class AUnitySingleton<TObject> : ExtendedMonoBehaviour
		where TObject : AUnitySingleton<TObject>
	{
		[NonSerialized]
		public static TObject Instance;

		public AUnitySingleton()
		{
			Instance = this as TObject;
		}

		protected virtual void OnDestroy()
		{
			Instance = null;
		}
	}
}
