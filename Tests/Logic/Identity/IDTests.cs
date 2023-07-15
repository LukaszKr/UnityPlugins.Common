using Newtonsoft.Json;
using NUnit.Framework;
using ProceduralLevel.Common.Logic;

namespace ProceduralLevel.Common.Tests
{
	public class IDTests
	{
		[Test]
		public void SerializeAndDeserialize()
		{
			ID<int> id = new ID<int>(5);
			string json = JsonConvert.SerializeObject(id);
			ID<int> deserialized = JsonConvert.DeserializeObject<ID<int>>(json);
			Assert.AreEqual(id, deserialized);
		}
	}
}
