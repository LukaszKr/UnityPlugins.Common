using System;
using System.Diagnostics;

namespace UnityPlugins.Reflection.Logic
{
	public static class TypeUtility
	{
		[DebuggerStepThrough]
		public static bool IsString(this Type type)
		{
			return typeof(string).IsAssignableFrom(type);
		}

		[DebuggerStepThrough]
		public static bool IsString(this object value)
		{
			if(value == null)
			{
				return false;
			}

			return value.GetType().IsString();
		}
	}
}
