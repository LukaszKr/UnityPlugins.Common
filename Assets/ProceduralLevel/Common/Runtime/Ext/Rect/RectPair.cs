using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	public struct RectPair
	{
		public readonly Rect A;
		public readonly Rect B;

		public RectPair(Rect a, Rect b)
		{
			A = a;
			B = b;
		}

		public override string ToString()
		{
			return string.Format("[A: {0}, B: {1}]", A, B);
		}
	}
}
