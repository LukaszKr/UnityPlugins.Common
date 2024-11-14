namespace UnityPlugins.Common.Logic
{
	public partial class EventBinder
	{
		public void Bind(AEvent evt, AEvent.Callback callback)
		{
			AddBinding(new EventBinding<AEvent.Callback>(evt, callback));
		}

		public void Bind<T0>(AEvent<T0> evt, AEvent<T0>.Callback callback)
		{
			AddBinding(new EventBinding<AEvent<T0>.Callback>(evt, callback));
		}

		public void Bind<T0, T1>(AEvent<T0, T1> evt, AEvent<T0, T1>.Callback callback)
		{
			AddBinding(new EventBinding<AEvent<T0, T1>.Callback>(evt, callback));
		}

		public void Bind<T0, T1, T2>(AEvent<T0, T1, T2> evt, AEvent<T0, T1, T2>.Callback callback)
		{
			AddBinding(new EventBinding<AEvent<T0, T1, T2>.Callback>(evt, callback));
		}
	}
}
