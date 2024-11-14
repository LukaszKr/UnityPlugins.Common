using System;
using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class GraphUtility
	{
		public static void DrawGraph(Rect rect, int steps, bool fullHeight, Func<int, float, float> calcFunc, Color color)
		{
			EditorGUI.DrawRect(rect, Color.white);
			float dashLength = Mathf.Ceil(rect.width/steps);
			float stepSize = 1f/(float)steps;

			for(int x = 0; x < steps; ++x)
			{
				float currentValue = x*stepSize;
				float easedValue = calcFunc(x, currentValue);
				float height = (fullHeight? easedValue*rect.height: 1f);

				float posX = rect.x+currentValue*rect.width;
				float posY = rect.yMax-easedValue*rect.height;

				Rect target = new Rect(posX, posY, dashLength, height);
				EditorGUI.DrawRect(target, color);
			}
		}
	}
}
