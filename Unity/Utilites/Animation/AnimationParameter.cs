using System;
using DG.Tweening;

namespace UnityPlugins.Common.Unity
{
	[Serializable]
	public class AnimationParameter
	{
		public float Duration = 0.5f;
		public Ease Ease = Ease.OutSine;

		public static implicit operator float(AnimationParameter parameter) => parameter.Duration;
		public static implicit operator Ease(AnimationParameter parameter) => parameter.Ease;

		public AnimationParameter(float duration = 1f, Ease ease = Ease.Linear)
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
