namespace UnityPlugins.Common.Logic
{
	public enum EEasingType
	{
		Linear,

		InQuad,
		OutQuad,
		InOutQuad,

		InCubic,
		OutCubic,
		InOutCubic,

		InQuart,
		OutQuart,
		InOutQuart,

		InQuint,
		OutQuint,
		InOutQuint,

		InSine,
		OutSine,
		InOutSine,

		InExpo,
		OutExpo,
		InOutExpo,

		InCirc,
		OutCirc,
		InOutCirc,

		InElastic,
		OutElastic,
		InOutElastic,

		InBack,
		OutBack,
		InOutBack,

		InBounce,
		OutBounce,
		InOutBounce,
	}

	public static class EEasingTypeExt
	{
		public static readonly EnumExt<EEasingType> Meta = new EnumExt<EEasingType>();

		public static float Evaluate(this EEasingType method, float progress)
		{
			Easing.Function func = method.ToFunc();
			return func(progress);
		}

		public static Easing.Function ToFunc(this EEasingType type)
		{
			return Easing.All[(int)type];
		}
	}
}
