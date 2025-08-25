using UnityEngine;
using UnityEngine.UI;

namespace UnityPlugins.Common.Unity
{
	public static class ScrollRectExt
	{
		public static Vector2 GetSnapToPositionToBringChildIntoView(this ScrollRect scrollRect, RectTransform child)
		{
			Vector2 contentPos = (Vector2)scrollRect.transform.InverseTransformPoint(scrollRect.content.position);
			Vector2 childPos = (Vector2)scrollRect.transform.InverseTransformPoint(child.position);
			Vector2 endPos = contentPos - childPos;
			//keep selected in middle if possible
			RectTransform rectTransform = scrollRect.GetComponent<RectTransform>();
			endPos.x += rectTransform.rect.width*rectTransform.pivot.x;
			endPos.y -= rectTransform.rect.height*rectTransform.pivot.y;

			if(!scrollRect.horizontal)
			{
				endPos.x = contentPos.x;
			}
			if(!scrollRect.vertical)
			{
				endPos.y = contentPos.y;
			}
			return endPos;
		}
	}
}
