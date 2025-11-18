using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public static class ListExt
	{
		public static void Shuffle<T>(this IList<T> list, Random random)
		{
			int n = list.Count;
			while(n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}
