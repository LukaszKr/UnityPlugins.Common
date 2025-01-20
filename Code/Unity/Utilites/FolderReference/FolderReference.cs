using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	[System.Serializable]
	public class FolderReference
	{
		public Object Value;

		public static implicit operator Object(FolderReference folder) => folder.Value;
		public static implicit operator FolderReference(Object value) => new FolderReference(value);

		public FolderReference(Object value)
		{
			Value = value;
		}
	}
}
