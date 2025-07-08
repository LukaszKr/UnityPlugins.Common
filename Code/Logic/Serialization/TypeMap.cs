using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public class TypeMap
	{
		private readonly Dictionary<Type, ID<Type>> m_TypeToID = new Dictionary<Type, ID<Type>>();
		private readonly Dictionary<ID<Type>, Type> m_IDToType = new Dictionary<ID<Type>, Type>();

		public TypeMap()
		{
		}

		public void Clear()
		{
			m_TypeToID.Clear();
			m_IDToType.Clear();
		}

		public bool Contains(Type type)
		{
			return m_TypeToID.ContainsKey(type);
		}

		public bool Contains(ID<Type> id)
		{
			return m_IDToType.ContainsKey(id);
		}

		public ID<Type> Get(Type type)
		{
			return m_TypeToID[type];
		}

		public Type Get(ID<Type> id)
		{
			return m_IDToType[id];
		}

		public bool TryAdd(Type type, ID<Type> id)
		{
			ID<Type> existingId;
			if(m_TypeToID.TryGetValue(type, out existingId))
			{
				if(existingId != id)
				{
					throw new ArgumentException($"{type.Name}: {existingId} =/= {id}");
				}
				return false;
			}
			Add(type, id);
			return true;
		}

		public void Add(Type type, ID<Type> id)
		{
			m_TypeToID.Add(type, id);
			m_IDToType.Add(id, type);
		}

		public void Remove(Type type)
		{
			ID<Type> id = Get(type);
			m_IDToType.Remove(id);
			m_TypeToID.Remove(type);
		}

		public void Remove(ID<Type> id)
		{
			Type type = Get(id);
			m_IDToType.Remove(id);
			m_TypeToID.Remove(type);
		}
	}
}
