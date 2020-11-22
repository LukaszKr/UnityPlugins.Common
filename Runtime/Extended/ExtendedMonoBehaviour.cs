using System;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Extended
{
	public abstract class ExtendedMonoBehaviour: MonoBehaviour
	{
		[NonSerialized]
		private Transform _Transform;
		[NonSerialized]
		private GameObject _GameObject;

		public Transform Transform
		{
			get
			{
				if(ReferenceEquals(_Transform, null))
				{
					_Transform = base.transform;
				}
				return _Transform;
			}
		}

		public GameObject GameObject
		{
			get
			{
				if(ReferenceEquals(_GameObject, null))
				{
					_GameObject = base.gameObject;
				}
				return _GameObject;
			}
		}

#pragma warning disable IDE1006 // NEVER EVER USE THOSE DIRECTLY!
		[Obsolete]
		public new Transform transform { get { throw new InvalidOperationException(); } }
		[Obsolete]
		public new GameObject gameObject { get { throw new InvalidOperationException(); } }
#pragma warning restore IDE1006
	}
}
