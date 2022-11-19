using System;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity.Extended
{
	public abstract class ExtendedMonoBehaviour : MonoBehaviour
	{
		[NonSerialized]
		private Transform m_Transform;
		[NonSerialized]
		private GameObject m_GameObject;

		public Transform Transform
		{
			get
			{
				if(ReferenceEquals(m_Transform, null))
				{
					m_Transform = base.transform;
				}
				return m_Transform;
			}
		}

		public GameObject GameObject
		{
			get
			{
				if(ReferenceEquals(m_GameObject, null))
				{
					m_GameObject = base.gameObject;
				}
				return m_GameObject;
			}
		}

#pragma warning disable IDE1006 // NEVER EVER USE THOSE DIRECTLY!
		[Obsolete]
		public new Transform transform => throw new InvalidOperationException();
		[Obsolete]
		public new GameObject gameObject => throw new InvalidOperationException();
#pragma warning restore IDE1006
	}
}
