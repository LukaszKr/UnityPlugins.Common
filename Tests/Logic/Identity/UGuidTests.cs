using Newtonsoft.Json;
using NUnit.Framework;
using ProceduralLevel.Common.Logic;

namespace ProceduralLevel.Common.Tests
{
	public class UGuidTests
	{
		[Test]
		public void SerializeAndDeserialize()
		{
			UGuid<int> id = UGuid<int>.Create();
			string json = JsonConvert.SerializeObject(id);
			UGuid<int> deserialized = JsonConvert.DeserializeObject<UGuid<int>>(json);
			Assert.AreEqual(id, deserialized);
		}
	}
}
