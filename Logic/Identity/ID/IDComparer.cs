using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public class IDComparer<T> : IEqualityComparer<ID<T>>
		where T : class
	{
		public static readonly IDComparer<T> Instance = new IDComparer<T>();

		private IDComparer()
		{
		}

		public bool Equals(ID<T> x, ID<T> y)
		{
			return x.Value == y.Value;
		}

		public int GetHashCode(ID<T> obj)
		{
			return obj.Value;
		}
	}
}
