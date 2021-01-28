namespace ProceduralLevel.UnityPlugins.Common
{
	public static class TargetConsts
	{
#if UNITY_STANDALONE
		public static readonly bool IsPC = true;
#else
		public readonly static bool IsPC = false;
#endif

#if UNITY_ANDROID || UNITY_IPHONE
		public readonly static bool IsMobile = true;
#else
		public static readonly bool IsMobile = false;
#endif

#if UNITY_ANDROID
		public readonly static bool IsAndroid = true;
#else
		public static readonly bool IsAndroid = false;
#endif

#if UNITY_IPHONE
		public readonly static bool IsIOS = true;
#else
		public static readonly bool IsIOS = false;
#endif

#if UNITY_SWITCH || NN_PLUGIN_ENABLE
		public readonly static bool IsSwitch = true;
#else
		public static readonly bool IsSwitch = false;
#endif

#if UNITY_EDITOR
		public static readonly bool IsEditor = true;
#else
		public readonly static bool IsEditor = false;
#endif
	}
}
