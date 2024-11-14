using System.Collections.Generic;
using System.Text;

namespace UnityPlugins.Common.Logic
{
	public static class StringExt
	{
		private static readonly StringBuilder m_SB = new StringBuilder();

		public static string JoinToString<T>(this IEnumerable<T> enumerable, string separator = ", ")
		{
			if(enumerable != null)
			{
				int count = 0;
				foreach(T item in enumerable)
				{
					if(count > 0)
					{
						m_SB.Append(separator);
					}
					m_SB.Append(item.ToString());
					++count;
				}
				string str = m_SB.ToString();
				m_SB.Length = 0;
				return str;
			}
			return string.Empty;
		}
	}
}
