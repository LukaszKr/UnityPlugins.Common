using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Unity
{
	public enum EUnityPathType
	{
		Streaming = 0,
		Persistent = 1,
		Assets = 2,
		Absolute = 3,
		Project = 4
	}

	public static class EUnityPathTypeExt
	{
		public static readonly EnumExt<EUnityPathType> Meta = new EnumExt<EUnityPathType>();
	}
}
