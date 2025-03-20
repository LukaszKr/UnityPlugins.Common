using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public class StorageEntry<TValue>
	{
		[JsonProperty]
		private TValue m_Value;
		[JsonProperty]
		private bool m_Modified = false;

		[JsonIgnore]
		private readonly TValue m_DefaultValue;

		[JsonIgnore]
		public TValue Value
		{
			get { return m_Value; }
			set { Set(value); }
		}

		[JsonIgnore]
		public bool Modified => m_Modified;

		[JsonIgnore]
		public readonly CustomEvent<TValue> OnChanged = new CustomEvent<TValue>();

		public StorageEntry(TValue defaultValue)
		{
			m_DefaultValue = defaultValue;
			m_Value = defaultValue;
		}

		public static implicit operator TValue(StorageEntry<TValue> entry)
		{
			return entry.Value;
		}

		public bool Set(TValue value)
		{
			if(!Equals(m_Value, value))
			{
				m_Modified = true;
				m_Value = value;
				OnChanged.Invoke(m_Value);
				return true;
			}
			return false;
		}

		[OnDeserialized]
		internal void OnAfterDeserialize(StreamingContext context)
		{
			if(m_Modified)
			{
				return;
			}
			m_Value = m_DefaultValue;
		}

		public override string ToString()
		{
			return $"[{nameof(Value)}: {m_Value}, {nameof(Modified)}: {m_Modified}]";
		}
	}
}
