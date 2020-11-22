using System;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common
{
	public static class RectExt
	{
		public static Rect AddMargin(this Rect rect, float margin)
		{
			return rect.AddMargin(margin, margin, margin, margin);
		}

		public static Rect AddMargin(this Rect rect, float horizontal, float vertical)
		{
			return rect.AddMargin(vertical, horizontal, vertical, horizontal);
		}

		public static Rect AddMargin(this Rect rect, float top, float right, float bottom, float left)
		{
			return new Rect(rect.x+left, rect.y+top, rect.width-right-left, rect.height-bottom-top);
		}

		public static void AddMargin(this Rect[] rect, float horizontal, float vertical)
		{
			for(int x = 0; x < rect.Length; ++x)
			{
				rect[x] = rect[x].AddMargin(horizontal, vertical);
			}
		}

		public static RectPair SplitHorizontal(this Rect rect, float leftToRightRatio)
		{
			float leftWidth = rect.width*leftToRightRatio;
			Rect left = new Rect(rect.x, rect.y, leftWidth, rect.height);
			Rect right = new Rect(rect.x+leftWidth, rect.y, rect.width-leftWidth, rect.height);
			return new RectPair(left, right);
		}

		public static RectPair SplitVertical(this Rect rect, float topToBottomRation)
		{
			float topHeight = rect.height*topToBottomRation;
			Rect top = new Rect(rect.x, rect.y, rect.width, topHeight);
			Rect bottom = new Rect(rect.x, rect.y+topHeight, rect.width, rect.height-topHeight);
			return new RectPair(top, bottom);
		}

		public static void SplitHorizontal(this Rect rect, Rect[] target, float[] ratios = null)
		{
			Split(rect, target, ratios, HorizontalSplitCallback);
		}

		public static void SplitVertical(this Rect rect, Rect[] target, float[] ratios = null)
		{
			Split(rect, target, ratios, VerticalSplitCallback);
		}

		public static RectPair CutLeft(this Rect rect, float width)
		{
			Rect left = new Rect(rect.x, rect.y, width, rect.height);
			Rect right = new Rect(rect.x+width, rect.y, rect.width-width, rect.height);
			return new RectPair(left, right);
		}

		public static RectPair CutRight(this Rect rect, float width)
		{
			Rect left = new Rect(rect.x, rect.y, rect.width-width, rect.height);
			Rect right = new Rect(rect.x+left.width, rect.y, width, rect.height);
			return new RectPair(left, right);
		}

		public static RectPair CutTop(this Rect rect, float height)
		{
			Rect top = new Rect(rect.x, rect.y, rect.width, height);
			Rect bottom = new Rect(rect.x, rect.y+height, rect.width, rect.height-height);
			return new RectPair(top, bottom);
		}

		public static RectPair CutBottom(this Rect rect, float height)
		{
			Rect top = new Rect(rect.x, rect.y, rect.width, rect.height-height);
			Rect bottom = new Rect(rect.x, rect.y+top.height, rect.width, height);
			return new RectPair(top, bottom);
		}

		private static void Split(Rect rect, Rect[] target, float[] ratios, NextPositionDelegate nextPositionCallback)
		{
			AssertArrays(target, ratios);

			int length = (ratios != null? ratios.Length: target.Length);
			Vector2 offset = new Vector2(0f, 0f);
			float avgRatio = 1f/length;
			for(int x = 0; x < length; x++)
			{
				float ratio = (ratios != null? ratios[x]: avgRatio);
				Rect size = nextPositionCallback(rect, ratio);
				target[x] = new Rect(rect.x+offset.x, rect.y+offset.y, size.width, size.height);
				offset += size.position;
			}
		}

		#region Helper
		private static void AssertArrays(Rect[] target, float[] ratios)
		{
			if(target == null)
			{
				throw new ArgumentNullException();
			}
			if(ratios != null && ratios.Length > target.Length)
			{
				throw new ArgumentException();
			}
		}

		private static Rect VerticalSplitCallback(Rect rect, float ratio)
		{
			float height = rect.height*ratio;
			return new Rect(0, height, rect.width, height);
		}

		private static Rect HorizontalSplitCallback(Rect rect, float ratio)
		{
			float width = rect.width*ratio;
			return new Rect(width, 0, width, rect.height);
		}

		private delegate Rect NextPositionDelegate(Rect rect, float ratio);
		#endregion
	}
}
