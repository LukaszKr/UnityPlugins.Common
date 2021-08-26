using ProceduralLevel.UnityPlugins.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public static partial class RuntimeAssert
	{
		public static void IsDestroyed(GameObject go, string message)
		{
			if(go)
			{
				throw new AssertException($"[IsDestroyed, {message}]");
			}
		}

		public static void IsNotDestroyed(GameObject go, string message)
		{
			if(!go)
			{
				throw new AssertException($"[IsNotDestroyed, {message}]");
			}
		}
	}
}
