using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public class StorageEntry<TValue>
	{
		[JsonIgnore]
		public readonly List<IValueConstraint<TValue>> Validators = new List<IValueConstraint<TValue>>();

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

		public void Reset()
		{
			m_Value = m_DefaultValue;
			m_Modified = false;
		}

		public bool Set(TValue value)
		{
			value = EvaluateConstraints(value);

			if(!Equals(m_Value, value))
			{
				m_Modified = true;
				m_Value = value;
				OnChanged.Invoke(m_Value);
				return true;
			}
			return false;
		}

		private TValue EvaluateConstraints(TValue value)
		{
			int count = Validators.Count;
			for(int x = 0; x < count; ++x)
			{
				IValueConstraint<TValue> validator = Validators[x];
				value = validator.Evaluate(value);
			}
			return value;
		}

		[OnDeserialized]
		internal void OnAfterDeserialize(StreamingContext context)
		{
			if(m_Modified)
			{
				m_Value = EvaluateConstraints(m_Value);
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
