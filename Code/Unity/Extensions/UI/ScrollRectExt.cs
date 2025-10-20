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
			//0.5 is probably a pivot one of the elements, but it's not scrollrect, content or child
			endPos.x += rectTransform.rect.width*0.5f;
			endPos.y -= rectTransform.rect.height*0.5f;

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
