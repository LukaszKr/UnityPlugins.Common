using System.Diagnostics;
using ProceduralLevel.UnityPlugins.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public static partial class DebugAssert
	{
		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void IsDestroyed(GameObject go, string message)
		{
			RuntimeAssert.IsDestroyed(go, message);
		}

		[Conditional(CommmonLogicConsts.DEBUG_ASSERT)]
		public static void IsNotDestroyed(GameObject go, string message)
		{
			RuntimeAssert.IsNotDestroyed(go, message);
		}
	}
}
