using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public class GenericEqualityComparer<T> : IEqualityComparer<T>
	{
		public static readonly GenericEqualityComparer<T> Instance = new GenericEqualityComparer<T>();

		private GenericEqualityComparer()
		{
		}

		public bool Equals(T x, T y)
		{
			return x.Equals(y);
		}

		public int GetHashCode(T obj)
		{
			return obj.GetHashCode();
		}
	}
}
