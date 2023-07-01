using System;
using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Unity
{
	[Flags]
	public enum EUnityLogMode
	{
		Callstack = 1 << 0,

		All = int.MaxValue
	}

	public static class EUnityLogModeExt
	{
		public static readonly EnumExt<EUnityLogMode> Meta = new EnumExt<EUnityLogMode>();

		public static bool Contains(this EUnityLogMode mode, EUnityLogMode other)
		{
			return (mode & other) == other;
		}
	}
}
