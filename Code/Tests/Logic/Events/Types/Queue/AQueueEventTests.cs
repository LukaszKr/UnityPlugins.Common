using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Queue
{
	internal abstract class AQueueEventTests : AEventTests
	{
		protected override void AssertCallTable(bool[] callTable)
		{
			for(int x = 0; x < callTable.Length; ++x)
			{
				Assert.AreEqual(x == 0, callTable[x]);
			}
		}

		protected override int GetExpectedCallCount(int listenerCount)
		{
			return 1;
		}
	}
}
