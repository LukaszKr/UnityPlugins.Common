using System.Collections.Generic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	public static class GizmosExt
	{
		private static readonly Stack<Color> m_ColorStack = new Stack<Color>();
		private static readonly Stack<Matrix4x4> m_MatrixStack = new Stack<Matrix4x4>();

		public static void PushColor(Color color)
		{
			m_ColorStack.Push(Gizmos.color);
			Gizmos.color = color;
		}

		public static void PopColor()
		{
			Gizmos.color = m_ColorStack.Pop();
		}

		public static void PushMatrix(Matrix4x4 matrix)
		{
			m_MatrixStack.Push(Gizmos.matrix);
			Gizmos.matrix = matrix;
		}

		public static void PopMatrix()
		{
			Gizmos.matrix = m_MatrixStack.Pop();
		}
	}
}
