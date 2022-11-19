using System.Collections.Generic;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class UGuidComparer<T> : IEqualityComparer<UGuid<T>>
		where T : class
	{
		public static readonly UGuidComparer<T> Instance = new UGuidComparer<T>();

		private UGuidComparer()
		{
		}

		public bool Equals(UGuid<T> x, UGuid<T> y)
		{
			return x.Value == y.Value;
		}

		public int GetHashCode(UGuid<T> obj)
		{
			return obj.GetHashCode();
		}
	}
}
