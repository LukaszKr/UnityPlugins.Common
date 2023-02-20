using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public static class ColorExt
	{
		public static Color Offset(this Color color, float r, float g, float b, float a = 0f)
		{
			return new Color(color.r+r, color.g+g, color.b+b, color.a+a);
		}

		public static Color32 Offset(this Color32 color, int r, int g, int b, int a = 0)
		{
			return new Color32((byte)(color.r+r), (byte)(color.g+g), (byte)(color.b+b), (byte)(color.a+a));
		}

		public static Color Blend(this Color color, Color other, float blend)
		{
			float reverseBlend =  1f-blend;
			if(blend <= 0f)
			{
				return color;
			}
			if(blend >= 1f)
			{
				return other;
			}

			return new Color(
				color.r*reverseBlend+other.r*blend,
				color.g*reverseBlend+other.g*blend,
				color.b*reverseBlend+other.b*blend,
				color.a*reverseBlend+other.a*blend);
		}
	}
}
