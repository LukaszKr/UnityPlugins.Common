using System.Collections.Generic;

namespace ProceduralLevel.UnityPlugins.Common.Logic
{
	public class UIDComparer<T> : IEqualityComparer<UID<T>>
		where T : class
	{
		public static readonly UIDComparer<T> Instance = new UIDComparer<T>();

		private UIDComparer()
		{
		}

		public bool Equals(UID<T> x, UID<T> y)
		{
			return x.Value == y.Value;
		}

		public int GetHashCode(UID<T> obj)
		{
			return obj.Value;
		}
	}
}
