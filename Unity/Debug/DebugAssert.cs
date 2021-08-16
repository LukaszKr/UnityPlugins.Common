using System.Diagnostics;
using ProceduralLevel.UnityPlugins.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public static partial class DebugAssert
	{
		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void IsDestroyed(GameObject go, string message)
		{
			if(go)
			{
				throw new DebugAssertException($"[IsDestroyed, {message}]");
			}
		}

		[Conditional(AssertLogicConsts.EDITOR_CONDITIONAL)]
		public static void IsNotDestroyed(GameObject go, string message)
		{
			if(!go)
			{
				throw new DebugAssertException($"[IsNotDestroyed, {message}]");
			}
		}
	}
}
