using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public class GenericComparer<T> : IComparer<T>
		where T : IComparable<T>
	{
		public static GenericComparer<T> Instance = new GenericComparer<T>();

		private GenericComparer()
		{
		}

		public int Compare(T x, T y)
		{
			return x.CompareTo(y);
		}
	}
}
