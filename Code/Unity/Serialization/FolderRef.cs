using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	[System.Serializable]
	public class FolderRef
	{
		public Object Value;

		public static implicit operator Object(FolderRef folder) => folder.Value;
		public static implicit operator FolderRef(Object value) => new FolderRef(value);

		public FolderRef(Object value)
		{
			Value = value;
		}
	}
}
