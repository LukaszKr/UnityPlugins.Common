using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Events.Stack
{
	internal abstract class AStackEventTests : AEventTests
	{
		protected override void AssertCallTable(bool[] callTable)
		{
			for(int x = 0; x < callTable.Length; ++x)
			{
				Assert.AreEqual(x == callTable.Length-1, callTable[x]);
			}
		}

		protected override int GetExpectedCallCount(int listenerCount)
		{
			return 1;
		}
	}
}
