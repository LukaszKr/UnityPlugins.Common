namespace UnityPlugins.Common.Logic
{
	public abstract class AEvent : ABaseEvent<AEvent.Callback>
	{
		public delegate void Callback();

		public abstract void Invoke();
	}

	public abstract class AEvent<T0> : ABaseEvent<AEvent<T0>.Callback>
	{
		public delegate void Callback(T0 arg0);

		public abstract void Invoke(T0 arg0);

		public override string ToString()
		{
			return base.ToString() + $"[Types({typeof(T0).Name})]";
		}
	}

	public abstract class AEvent<T0, T1> : ABaseEvent<AEvent<T0, T1>.Callback>
	{
		public delegate void Callback(T0 arg0, T1 arg1);

		public abstract void Invoke(T0 arg0, T1 arg1);

		public override string ToString()
		{
			return base.ToString() + $"[Types({typeof(T0).Name}, {typeof(T1).Name})]";
		}
	}

	public abstract class AEvent<T0, T1, T2> : ABaseEvent<AEvent<T0, T1, T2>.Callback>
	{
		public delegate void Callback(T0 arg0, T1 arg1, T2 arg2);

		public abstract void Invoke(T0 arg0, T1 arg1, T2 arg2);

		public override string ToString()
		{
			return base.ToString() + $"[Types({typeof(T0).Name}, {typeof(T1).Name}, {typeof(T2).Name})]";
		}
	}
}
