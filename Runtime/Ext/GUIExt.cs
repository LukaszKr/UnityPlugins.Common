using System.Collections.Generic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	public static class GUIExt
	{
		private static readonly Stack<Color> m_ColorStack = new Stack<Color>();

		public static void PushColor(Color color)
		{
			m_ColorStack.Push(GUI.color);
			GUI.color = color;
		}

		public static void PopColor()
		{
			GUI.color = m_ColorStack.Pop();
		}
	}
}
