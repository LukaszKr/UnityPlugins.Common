using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Logic
{
	public enum ELogType
	{
		Info = 0,
		Warning = 1,
		Error = 2
	}

	public static class ELogTypeExt
	{
		public static readonly EnumExt<ELogType> Meta = new EnumExt<ELogType>();
	}
}
