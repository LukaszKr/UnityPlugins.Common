﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProceduralLevel.Common.Unity.Extended;
using UnityEngine;

namespace ProceduralLevel.Common.Unity.Pool
{
	public sealed class UnityPool<TEntry>
		where TEntry : ExtendedMonoBehaviour, IUnityPoolEntry
	{
		private readonly Stack<TEntry> m_Pool;
		public readonly int Capacity;

		private readonly Transform m_Parent;
		private readonly TEntry m_Prefab;
		private readonly EUnityPoolOptions m_Options;

		public int UnusedCount => m_Pool.Count;
		public string Name => m_Parent.name;

		public UnityPool(Transform parent, TEntry prefab, int initialCapacity, EUnityPoolOptions options)
		{
			m_Pool = new Stack<TEntry>(initialCapacity);
			Capacity = initialCapacity;

			m_Parent = parent;
			m_Prefab = prefab;
			m_Options = options;
		}

		public void Prefill()
		{
			for(int x = 0; x < Capacity; ++x)
			{
				TEntry entry = CreateEntry();
				PushEntry(entry);
			}
		}

		public TEntry Get()
		{
			if(m_Pool.Count > 0)
			{
				TEntry pooled = m_Pool.Pop();
				if(m_Options.Contains(EUnityPoolOptions.ManageActive))
				{
					pooled.GameObject.SetActive(true);
				}
				pooled.OnGetFromPool();
				return pooled;
			}
			if(m_Options.Contains(EUnityPoolOptions.ExceptionOnEmpty))
			{
				throw new System.Exception();
			}
			return CreateEntry();
		}

		public void Get(TEntry[] entries)
		{
			int length = entries.Length;
			for(int x = 0; x < length; ++x)
			{
				entries[x] = Get();
			}
		}

		public void Return(TEntry entry)
		{
			if(m_Options.Contains(EUnityPoolOptions.DiscardOverflow) && m_Pool.Count > Capacity)
			{
				DestroyEntry(entry);
			}
			else
			{
				if(m_Parent && entry)
				{
					entry.OnReturnToPool();
					PushEntry(entry);
				}
				else
				{
					DestroyEntry(entry);
				}
			}
		}

		private void PushEntry(TEntry entry)
		{
			if(m_Options.Contains(EUnityPoolOptions.ManageActive))
			{
				entry.GameObject.SetActive(false);
			}
			entry.Transform.SetParent(m_Parent, false);
			m_Pool.Push(entry);
		}

		public void Return(TEntry[] entries)
		{
			int length = entries.Length;
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = entries[x];
				if(entry)
				{
					Return(entry);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private TEntry CreateEntry()
		{
			return Object.Instantiate(m_Prefab, m_Parent);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void DestroyEntry(TEntry entry)
		{
			Object.Destroy(entry.GameObject);
		}
	}
}
