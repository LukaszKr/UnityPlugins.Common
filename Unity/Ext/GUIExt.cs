using System.Collections.Generic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public static class GUIExt
	{
		private static readonly Stack<Color> m_ColorStack = new Stack<Color>();
		private static readonly Stack<Color> m_BackgroundColorStack = new Stack<Color>();
		private static readonly Stack<Color> m_ContentColorStack = new Stack<Color>();

		public static void PushColor(Color color)
		{
			m_ColorStack.Push(GUI.color);
			GUI.color = color;
		}

		public static void PopColor()
		{
			GUI.color = m_ColorStack.Pop();
		}

		public static void PushBackgroundColor(Color color)
		{
			m_BackgroundColorStack.Push(GUI.color);
			GUI.backgroundColor = color;
		}

		public static void PopBackgroundColor()
		{
			GUI.color = m_BackgroundColorStack.Pop();
		}

		public static void PushContentColor(Color color)
		{
			m_ContentColorStack.Push(GUI.color);
			GUI.contentColor = color;
		}

		public static void PopContentColor()
		{
			GUI.color = m_ContentColorStack.Pop();
		}
	}
}
