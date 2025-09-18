using System;

namespace UnityPlugins.Common.Logic
{
	public static class RandomExt
	{
		public static int GenerateSeed()
		{
			return Guid.NewGuid().GetHashCode();
		}
	}
}
