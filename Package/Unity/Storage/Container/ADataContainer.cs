using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public abstract class ADataContainer<TValue> : ScriptableObject, ISerializationCallbackReceiver
		where TValue : class
	{
		protected TValue m_Value;

		public TValue Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}

		public abstract void Load();
		protected abstract void Save();

#if UNITY_EDITOR
		public void Editor_Save()
		{
			Save();
			UnityEditor.EditorUtility.SetDirty(this);
		}

		public void Editor_RecordObject(string reason)
		{
			UnityEditor.Undo.RecordObject(this, reason);
		}
#endif

		#region Serialization Callbacks
		public void OnBeforeSerialize()
		{
			Save();
		}

		public void OnAfterDeserialize()
		{
			Load();
		}
		#endregion
	}
}
