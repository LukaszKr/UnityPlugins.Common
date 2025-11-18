using System.Collections.Generic;
using System.Text;

namespace UnityPlugins.Common.Logic
{
	public class CSVTable
	{
		public readonly List<CSVEntry> Entries = new List<CSVEntry>();

		public CSVTable()
		{

		}

		public CSVTable(string rawCSV)
		{
			bool isInQuotes = false;
			int startFrom = 0;
			int length = rawCSV.Length;
			for(int x = 0; x < length; ++x)
			{
				if(rawCSV[x] == CSVConsts.QUOTE)
				{
					isInQuotes = !isInQuotes;
				}
				if(isInQuotes)
				{
					continue;
				}
				if(rawCSV[x] == '\n')
				{
					int colLength = x-startFrom;
					if(rawCSV[x-1] == '\r')
					{
						colLength--;
					}
					string line = rawCSV.Substring(startFrom, colLength).Trim();
					startFrom = x;
					CSVEntry entry = new CSVEntry(line);
					Entries.Add(entry);
				}
			}
		}

		public CSVEntry CreateEntry()
		{
			CSVEntry entry = new CSVEntry();
			Entries.Add(entry);
			return entry;
		}

		public string ToCSV()
		{
			StringBuilder sb = new StringBuilder();
			int count = Entries.Count;
			for(int x = 0; x < count; ++x)
			{
				CSVEntry entry = Entries[x];
				entry.ToCSV(sb);
				sb.Append('\n');
			}
			return sb.ToString();
		}
	}
}
