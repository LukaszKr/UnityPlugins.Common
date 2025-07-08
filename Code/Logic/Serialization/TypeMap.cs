using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public class TypeMap
	{
		private readonly Dictionary<Type, string> m_TypeToKey = new Dictionary<Type, string>(GenericEqualityComparer<Type>.Instance);
		private readonly Dictionary<string, Type> m_KeyToType = new Dictionary<string, Type>(GenericEqualityComparer<string>.Instance);

		public void Clear()
		{
			m_TypeToKey.Clear();
			m_KeyToType.Clear();
		}

		public bool Contains(Type type)
		{
			return m_TypeToKey.ContainsKey(type);
		}

		public bool Contains(string key)
		{
			return m_KeyToType.ContainsKey(key);
		}

		public string Get(Type type)
		{
			return m_TypeToKey[type];
		}

		public Type Get(string id)
		{
			return m_KeyToType[id];
		}

		public bool TryAdd(Type type, string key)
		{
			string existingKey;
			if(m_TypeToKey.TryGetValue(type, out existingKey))
			{
				if(!existingKey.Equals(key))
				{
					throw new ArgumentException($"{type.Name}: {existingKey} =/= {key}");
				}
				return false;
			}
			Add(type, key);
			return true;
		}

		public void Add(Type type, string key)
		{
			m_TypeToKey.Add(type, key);
			m_KeyToType.Add(key, type);
		}

		public void Remove(Type type)
		{
			string key = Get(type);
			m_KeyToType.Remove(key);
			m_TypeToKey.Remove(type);
		}

		public void Remove(string key)
		{
			Type type = Get(key);
			m_KeyToType.Remove(key);
			m_TypeToKey.Remove(type);
		}
	}
}
