﻿using System;
using System.IO;
using ProceduralLevel.Common.Ext;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public abstract class ABinarySO<TObject> : ScriptableObject
		where TObject : class, IBinarySerializable, new()
	{
		[SerializeField, HideInInspector]
		private byte[] m_RawData;

		private TObject m_Value;

		public TObject Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}

		public void Load()
		{
			if(m_RawData == null)
			{
				m_Value = new TObject();
				return;
			}

			try
			{
				m_Value = Create(m_RawData.ToBinaryReader());
			}
			catch(Exception e)
			{
				Debug.LogException(e, this);
				m_Value = new TObject();
			}
		}

		protected abstract TObject Create(BinaryReader reader);

#if UNITY_EDITOR
		public void Editor_Save()
		{
			using(MemoryStream stream = new MemoryStream())
			{
				using(BinaryWriter writer = new BinaryWriter(stream))
				{
					m_Value.WriteToBuffer(writer);
					m_RawData = stream.ToArray();
					UnityEditor.EditorUtility.SetDirty(this);
				}
			}
		}

		public void Editor_RecordObject(string reason)
		{
			UnityEditor.Undo.RecordObject(this, reason);
		}
#endif
	}
}