using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public static class StorageEntryEventBinderExt
	{
		public static void Bind<TValue>(this EventBinder binder, StorageEntry<TValue> observable, AEvent<TValue>.Callback callback)
		{
			binder.Bind(observable.OnChanged, callback);
		}
	}
}
