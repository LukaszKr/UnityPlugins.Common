using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public class GUICanvas
	{
		public readonly int ReferenceWidth;
		public readonly int ReferenceHeight;

		public float Scale;
		public float ScaleX;
		public float ScaleY;

		public int Width;
		public int Height;

		public GUICanvas(int width, int height)
		{
			ReferenceWidth = width;
			ReferenceHeight = height;
		}

		public void Use()
		{
			Width = Screen.width;
			Height = Screen.height;
			ScaleX = Width/(float)ReferenceWidth;
			ScaleY = Height/(float)ReferenceHeight;
			Scale = Mathf.Max(ScaleX, ScaleY);
			Width = Mathf.CeilToInt(Width/Scale);
			Height = Mathf.CeilToInt(Height/Scale);
			GUI.matrix = Matrix4x4.Scale(new Vector3(Scale, Scale, Scale));
		}

		public Rect GetRect()
		{
			return new Rect(0, 0, Width, Height);
		}
	}
}
