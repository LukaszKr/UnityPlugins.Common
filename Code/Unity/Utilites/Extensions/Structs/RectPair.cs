﻿using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public readonly struct RectPair
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
			return $"[{nameof(A)}: {A}, {nameof(B)}: {B}]";
		}
	}
}
