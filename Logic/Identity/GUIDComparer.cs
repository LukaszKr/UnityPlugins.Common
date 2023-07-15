using System.Collections.Generic;

namespace ProceduralLevel.Common.Logic
{
	public class GUIDComparer<T> : IEqualityComparer<GUID<T>>
		where T : class
	{
		public static readonly GUIDComparer<T> Instance = new GUIDComparer<T>();

		private GUIDComparer()
		{
		}

		public bool Equals(GUID<T> x, GUID<T> y)
		{
			return x.Value == y.Value;
		}

		public int GetHashCode(GUID<T> obj)
		{
			return obj.GetHashCode();
		}
	}
}
