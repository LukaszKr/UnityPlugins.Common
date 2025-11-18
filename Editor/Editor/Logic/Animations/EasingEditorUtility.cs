using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Editor
{
	public static class EasingEditorUtility
	{
		public static void DrawPreview(Rect rect, EEasingType type)
		{
			Easing.Function func = type.ToFunc();
			int steps = Mathf.CeilToInt(rect.width/4f);
			float perStep = 1f/steps;

			if(Event.current.type == EventType.Repaint)
			{
				GLUtility.Begin();
				GL.Begin(GL.LINE_STRIP);
				for(int x = 0; x <= steps; ++x)
				{
					float value = 1f-func(x*perStep);
					float xOffset = rect.width*perStep*x;
					float yOffset = value*rect.height;
					Rect dotRect = new Rect(rect.x+xOffset, rect.y+yOffset, 4, 4);
					GL.Color(new Color(value, 1f-value, 0f, 1f));
					GL.Vertex(new Vector3(rect.x+xOffset, rect.y+yOffset, 0f));
				}
				GL.End();
			}
		}
	}
}
