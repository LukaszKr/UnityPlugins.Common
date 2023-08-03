using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.Common.Editor
{
	public static class UseAnchorsTool
	{
		private const string NAME = "Convert to Anchors";

		private const string MENU = "CONTEXT/"+nameof(RectTransform)+"/"+NAME;

		[MenuItem(MENU)]
		private static void UseAnchors()
		{
			Transform[] selection = Selection.transforms;
			int length = selection.Length;

			for(int x = 0; x < length; ++x)
			{
				Transform transform = selection[x];
				RectTransform rectTransform = transform.GetComponent<RectTransform>();
				if(rectTransform)
				{
					UseAnchors(rectTransform);
				}
			}
		}

		private static void UseAnchors(RectTransform transform)
		{
			RectTransform parentRectTranform = transform.parent.GetComponent<RectTransform>();

			Vector2 parentSize = parentRectTranform.rect.size;

			float minX = transform.offsetMin.x;
			float minY = transform.offsetMin.y;
			float maxX = transform.offsetMax.x;
			float maxY = transform.offsetMax.y;

			Vector2 anchorMin = new Vector2(minX/parentSize.x, minY/parentSize.y)+transform.anchorMin;
			Vector2 anchorMax = new Vector2(maxX/parentSize.x, maxY/parentSize.y)+transform.anchorMax;

			Undo.IncrementCurrentGroup();
			Undo.RecordObject(transform, NAME);
			transform.anchorMin = anchorMin;
			transform.anchorMax = anchorMax;
			transform.anchoredPosition = new Vector2(0f, 0f);
			transform.sizeDelta = new Vector2(0f, 0f);
		}
	}
}
