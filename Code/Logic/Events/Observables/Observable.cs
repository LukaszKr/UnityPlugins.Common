namespace UnityPlugins.Common.Logic
{
	public class Observable<TValue>
	{
		private TValue m_Value;

		public TValue Value
		{
			set => Set(value);
			get => m_Value;
		}

		public readonly CustomEvent<TValue> OnChanged = new CustomEvent<TValue>();

		public Observable(TValue initialValue = default)
		{
			m_Value = initialValue;
		}

		public void Set(TValue newValue)
		{
			if(Equals(m_Value, newValue))
			{
				return;
			}

			m_Value = newValue;
			OnChanged.Invoke(newValue);
		}

		public void SetSilient(TValue newValue)
		{
			m_Value = Value;
		}

		public void Notify()
		{
			OnChanged.Invoke(m_Value);
		}
	}
}
