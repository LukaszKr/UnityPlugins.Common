namespace UnityPlugins.Common.Logic
{
	public static class ObservableEventBinderExt
	{
		public static void Bind<TValue>(this EventBinder binder, Observable<TValue> observable, AEvent<TValue>.Callback callback)
		{
			binder.Bind(observable.OnChanged, callback);
		}
	}
}
