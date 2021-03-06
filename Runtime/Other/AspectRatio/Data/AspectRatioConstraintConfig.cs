using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	[CreateAssetMenu(fileName = nameof(AspectRatioConstraintConfig), menuName = CommonConsts.MENU+nameof(AspectRatioConstraintConfig))]
	public class AspectRatioConstraintConfig: ScriptableObject
	{
		public float MinAspect = 0.5f;
		public float MaxAspect = 2f;
	}
}
