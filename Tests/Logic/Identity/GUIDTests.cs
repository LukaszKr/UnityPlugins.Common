using Newtonsoft.Json;
using NUnit.Framework;
using ProceduralLevel.Common.Logic;

namespace ProceduralLevel.Common.Tests
{
	public class GUIDTests
	{
		[Test]
		public void SerializeAndDeserialize()
		{
			GUID<int> id = GUID<int>.Create();
			string json = JsonConvert.SerializeObject(id);
			GUID<int> deserialized = JsonConvert.DeserializeObject<GUID<int>>(json);
			Assert.AreEqual(id, deserialized);
		}
	}
}
