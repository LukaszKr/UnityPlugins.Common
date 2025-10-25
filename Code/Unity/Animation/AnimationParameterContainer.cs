using DG.Tweening;

namespace UnityPlugins.Common.Unity
{
	public class AnimationParameterContainer : ADataContainer
	{
		public AnimationParameter Parameters = new AnimationParameter(0.5f, Ease.OutSine);

		public static implicit operator float(AnimationParameterContainer container) => container.Parameters.Duration;
		public static implicit operator Ease(AnimationParameterContainer container) => container.Parameters.Ease;
	}
}
