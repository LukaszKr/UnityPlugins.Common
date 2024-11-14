using System;

namespace UnityPlugins.Common.Logic
{
	public class EnumExt<TEnum>
		where TEnum : Enum
	{
		public readonly TEnum[] Values;
		public readonly int MinValue;
		public readonly int MaxValue;

		public EnumExt()
		{
			Values = (TEnum[])Enum.GetValues(typeof(TEnum));
			Array.Sort(Values);
			MinValue = Values[0].GetHashCode();
			MaxValue = Values[Values.Length-1].GetHashCode();
		}
	}
}
