using Newtonsoft.Json;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public abstract class AJsonContainer<TValue> : ADataContainer<TValue>
		where TValue : class
	{
		[SerializeField, HideInInspector]
		private string m_Json;

		public void SetJson(string json, bool load = true)
		{
			m_Json = json;
			if(load)
			{
				Load();
			}
		}

		public override void Load()
		{
			if(!string.IsNullOrEmpty(m_Json))
			{
				m_Value = JsonConvert.DeserializeObject<TValue>(m_Json);
			}
			if(m_Value == null)
			{
				m_Value = CreateDefault();
			}
		}

		protected override void Save()
		{
			m_Json = JsonConvert.SerializeObject(m_Value, Formatting.Indented);
		}

		protected abstract TValue CreateDefault();
	}
}
