using System.Runtime.Serialization;
using Newtonsoft.Json;
using ProceduralLevel.Common.Event;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public class StorageEntry<TValue>
	{
		[JsonProperty]
		private TValue m_Value;
		[JsonProperty]
		private bool m_UseDefault = true;

		[JsonIgnore]
		private readonly TValue m_DefaultValue;

		[JsonIgnore]
		public TValue Value
		{
			get { return m_Value; }
			set
			{
				if(!Equals(m_Value, value))
				{
					m_UseDefault = false;
					m_Value = value;
					OnChanged.Invoke(m_Value);
				}
			}
		}

		[JsonIgnore]
		public bool IsDefault { get { return m_UseDefault; } }

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

		[OnDeserialized]
		internal void OnAfterDeserialize(StreamingContext context)
		{
			if(m_UseDefault)
			{
				m_Value = m_DefaultValue;
			}
		}

		public override string ToString()
		{
			return string.Format("[Value: {0}, UseDefault: {1}]",
				m_Value, m_UseDefault);
		}
	}
}
