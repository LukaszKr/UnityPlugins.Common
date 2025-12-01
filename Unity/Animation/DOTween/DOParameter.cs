#if DOTWEEN
using System;
using DG.Tweening;

namespace UnityPlugins.Common.Unity
{
	[Serializable]
	public class DOParameter
	{
		public float Duration = 0.5f;
		public Ease Ease = Ease.OutSine;

		public static implicit operator float(DOParameter parameter) => parameter.Duration;
		public static implicit operator Ease(DOParameter parameter) => parameter.Ease;

		public DOParameter(float duration = 1f, Ease ease = Ease.Linear)
		{
			Duration = duration;
			Ease = ease;
		}

		public override string ToString()
		{
			return $"[{nameof(Duration)}: {Duration}s, {Ease}]";
		}
	}
}
#endif