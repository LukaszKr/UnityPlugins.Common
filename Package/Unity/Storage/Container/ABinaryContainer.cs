using System;
using System.IO;
using ProceduralLevel.Common.Ext;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public abstract class ABinaryContainer<TValue> : ADataContainer<TValue>
		where TValue : class, IBinarySerializable
	{
		[SerializeField, HideInInspector]
		private byte[] m_BinaryData;

		public override void Load()
		{
			if(m_BinaryData == null)
			{
				m_Value = Create();
				return;
			}

			try
			{
				m_Value = Create(m_BinaryData.ToBinaryReader());
			}
			catch(Exception e)
			{
				Debug.LogException(e, this);
				m_Value = Create();
			}
		}

		protected override void Save()
		{
			using(MemoryStream stream = new MemoryStream())
			{
				using(BinaryWriter writer = new BinaryWriter(stream))
				{
					m_Value.WriteToBuffer(writer);
					m_BinaryData = stream.ToArray();
				}
			}
		}

		protected abstract TValue Create();
		protected abstract TValue Create(BinaryReader reader);
	}
}
