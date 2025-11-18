using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Serialization.CSV
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	public class CSVEntryTests
	{
		[Test]
		public void QuotesAreEscaped()
		{
			CSVEntry entry = new CSVEntry();
			entry.Columns.Add($"{CSVConsts.QUOTE}Hello{CSVConsts.QUOTE}");
			Assert.AreEqual($"{CSVConsts.QUOTE}{CSVConsts.QUOTE}{CSVConsts.QUOTE}Hello{CSVConsts.QUOTE}{CSVConsts.QUOTE}{CSVConsts.QUOTE}", entry.ToCSV());
		}

		[Test]
		public void SeparatorBetweenColumns()
		{
			CSVEntry entry = new CSVEntry();
			entry.Columns.Add("Hello");
			entry.Columns.Add("World");
			Assert.AreEqual($"{CSVConsts.QUOTE}Hello{CSVConsts.QUOTE}{CSVConsts.SEPARATOR}{CSVConsts.QUOTE}World{CSVConsts.QUOTE}", entry.ToCSV());
		}

		[Test]
		public void FromSimpleString()
		{
			CSVEntry entry = new CSVEntry($"{CSVConsts.QUOTE}Hello{CSVConsts.QUOTE},{CSVConsts.QUOTE}World{CSVConsts.QUOTE}");
			Assert.AreEqual(2, entry.Columns.Count);
			Assert.AreEqual("Hello", entry.Columns[0]);
			Assert.AreEqual("World", entry.Columns[1]);
		}

		[Test]
		public void FromSimpleString_NoQuotes()
		{
			CSVEntry entry = new CSVEntry($"Hello,World");
			Assert.AreEqual(2, entry.Columns.Count);
			Assert.AreEqual("Hello", entry.Columns[0]);
			Assert.AreEqual("World", entry.Columns[1]);
		}
	}
}
