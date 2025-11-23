using System.Linq;
using DG.Tweening;

namespace UnityPlugins.Common.Unity
{
	public static class SequenceExt
	{
		public static Sequence TryAppend(this Sequence sequence, Tween tween)
		{
			if(tween != null)
			{
				sequence.Append(tween);
			}
			return sequence;
		}

		public static Sequence TryJoin(this Sequence sequence, Tween tween)
		{
			if(tween != null)
			{
				sequence.Join(tween);
			}
			return sequence;
		}
	}
}
