using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Custom
{
	internal abstract class ACustomEventTests : AEventTests
	{
		protected override void AssertCallTable(bool[] callTable)
		{
			for(int x = 0; x < callTable.Length; ++x)
			{
				Assert.IsTrue(callTable[x]);
			}
		}

		protected override int GetExpectedCallCount(int listenerCount)
		{
			return listenerCount;
		}
	}
}
