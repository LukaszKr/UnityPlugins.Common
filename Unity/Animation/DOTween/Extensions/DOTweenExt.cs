#if DOTWEEN
using DG.Tweening;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public static class DOTweenExt
	{
		public static Tween DOSize(this SpriteRenderer renderer, Vector2 target, float duration)
		{
			return DOTween.To(() => renderer.size, (v) => { renderer.size = v; }, target, duration);
		}
	}
}
#endif