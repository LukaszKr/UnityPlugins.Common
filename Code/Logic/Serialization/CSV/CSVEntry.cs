using System.Collections.Generic;
using System.Text;

namespace UnityPlugins.Common.Logic
{
	public class CSVEntry
	{
		public readonly List<string> Columns = new List<string>();

		public CSVEntry()
		{

		}

		public CSVEntry(string raw)
		{
			int startFrom = 0;
			bool isInQuotes = false;
			bool columnQuoted = false;

			for(int x = 0; x < raw.Length; ++x)
			{
				char currentChar = raw[x];
				if(currentChar == CSVConsts.QUOTE)
				{
					if(!columnQuoted)
					{
						columnQuoted = true;
						startFrom += 1;
					}
					isInQuotes = !isInQuotes;
				}
				if(isInQuotes)
				{
					continue;
				}

				bool isLastChar = x == raw.Length-1;

				if(currentChar != CSVConsts.SEPARATOR && !isLastChar)
				{
					continue;
				}
				int colLength = x-startFrom;
				if(!columnQuoted)
				{
					if(isLastChar)
					{
						colLength += 1;
					}
				}
				else if(!isLastChar)
				{
					colLength -= 1;
				}
				string col = raw.Substring(startFrom, colLength);
				if(col.Contains(CSVConsts.DOUBLE_QUOTE))
				{
					col = col.Replace(CSVConsts.DOUBLE_QUOTE, CSVConsts.SINGLE_QUOTE);
				}
				Columns.Add(col);
				startFrom = x+1;
				columnQuoted = false;
			}
		}

		public override string ToString()
		{
			return string.Join('"', Columns);
		}

		public string ToCSV()
		{
			StringBuilder sb = new StringBuilder();
			ToCSV(sb);
			return sb.ToString();
		}

		public void ToCSV(StringBuilder sb)
		{
			int count = Columns.Count;
			for(int x = 0; x < count; ++x)
			{
				string col = Columns[x];
				if(col == null)
				{
					col = string.Empty;
				}
				if(x > 0)
				{
					sb.Append(CSVConsts.SEPARATOR);
				}
				sb.Append(CSVConsts.QUOTE);
				if(col.Contains(CSVConsts.QUOTE))
				{
					col = col.Replace(CSVConsts.SINGLE_QUOTE, CSVConsts.DOUBLE_QUOTE);
				}
				sb.Append(col);
				sb.Append(CSVConsts.QUOTE);
			}
		}
	}
}
