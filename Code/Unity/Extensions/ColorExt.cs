﻿using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public static class ColorExt
	{
		#region HSV - Set
		public static Color SetH(this Color rgbColor, float value)
		{
			float s, v;
			Color.RGBToHSV(rgbColor, out _, out s, out v);
			return Color.HSVToRGB(value, s, v);
		}

		public static Color SetS(this Color rgbColor, float value)
		{
			float h, v;
			Color.RGBToHSV(rgbColor, out h, out _, out v);
			return Color.HSVToRGB(h, value, v);
		}

		public static Color SetV(this Color rgbColor, float value)
		{
			float h, s;
			Color.RGBToHSV(rgbColor, out h, out s, out _);
			return Color.HSVToRGB(h, s, value);
		}
		#endregion

		#region HSV - Multiply
		public static Color MultiplyHSV(this Color rgbColor, float hMultiplier, float sMultiplier, float vMultiplier)
		{
			float h, s, v;
			Color.RGBToHSV(rgbColor, out h, out s, out v);
			return Color.HSVToRGB(h*hMultiplier, s*sMultiplier, v*vMultiplier);
		}


		public static Color MultiplyH(this Color rgbColor, float multiplier)
		{
			float h, s, v;
			Color.RGBToHSV(rgbColor, out h, out s, out v);
			return Color.HSVToRGB(h*multiplier, s, v);
		}

		public static Color MultiplyS(this Color rgbColor, float multiplier)
		{
			float h, s, v;
			Color.RGBToHSV(rgbColor, out h, out s, out v);
			return Color.HSVToRGB(h, s*multiplier, v);
		}

		public static Color MultiplyV(this Color rgbColor, float multiplier)
		{
			float h, s, v;
			Color.RGBToHSV(rgbColor, out h, out s, out v);
			return Color.HSVToRGB(h, s, v*multiplier);
		}
		#endregion
	}
}
