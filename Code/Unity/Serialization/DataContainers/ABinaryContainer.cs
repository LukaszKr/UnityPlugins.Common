using System;
using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public abstract class ABinaryContainer<TValue> : ADataContainer, ISerializationCallbackReceiver
		where TValue : class, IBinarySerializable
	{
		[HideInInspector]
		public byte[] RawData;
		[NonSerialized]
		public TValue Value;

		public static implicit operator TValue(ABinaryContainer<TValue> container) => container?.Value;

		public virtual void Load()
		{
			if(RawData != null && RawData.Length > 0)
			{
				FastBinaryReader reader = new FastBinaryReader(RawData);
				Value = OnLoad(reader);
				GameAssert.AreEqual(RawData.Length, reader.Head);
			}
			else
			{
				Value = CreateDefault();
			}
		}

		public void ResetValue()
		{
			Value = CreateDefault();
		}

		protected abstract TValue CreateDefault();
		protected abstract TValue OnLoad(FastBinaryReader reader);

		protected abstract byte[] GetBuffer();

		#region Serialization Callbacks
		public void OnAfterDeserialize()
		{
			Load();
		}

		public void OnBeforeSerialize()
		{
			if(Value != null)
			{
				FastBinaryWriter writer = new FastBinaryWriter(GetBuffer());
				RawData = Value.WriteToByteArray(writer);
			}
		}
		#endregion

		public override string ToString()
		{
			return name;
		}
	}
}
