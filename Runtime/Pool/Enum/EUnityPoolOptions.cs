using System;

namespace ProceduralLevel.UnityPlugins.Common.Pool
{
	[Flags]
	public enum EUnityPoolOptions
	{
		None = 0,

		DiscardOverflow = 1 << 0,
		ManageActive = 1 << 1,
		ExceptionOnEmpty = 1 << 2,

		Default = ManageActive
	}

	public static class EUnityPoolOptionsExt
	{
		public static bool Contains(this EUnityPoolOptions option, EUnityPoolOptions other)
		{
			return (option & other) == other;
		}
	}
}
