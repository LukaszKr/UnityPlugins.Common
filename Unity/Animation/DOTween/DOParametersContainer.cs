using DG.Tweening;

namespace UnityPlugins.Common.Unity
{
	public class DOParametersContainer : ADataContainer
	{
		public DOParameters Parameters = new DOParameters(0.5f, Ease.OutSine);

		public static implicit operator float(DOParametersContainer container) => container.Parameters.Duration;
		public static implicit operator Ease(DOParametersContainer container) => container.Parameters.Ease;
	}
}
