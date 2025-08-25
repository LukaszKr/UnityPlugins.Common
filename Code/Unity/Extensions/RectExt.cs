using System;
using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public static class RectExt
	{
		#region Margin
		public static Rect AddMarginTop(this Rect rect, float margin)
		{
			return rect.AddMargin(margin, 0f, 0f, 0f);
		}

		public static Rect AddMarginRight(this Rect rect, float margin)
		{
			return rect.AddMargin(0f, margin, 0f, 0f);
		}

		public static Rect AddMarginBottom(this Rect rect, float margin)
		{
			return rect.AddMargin(0f, 0f, margin, 0f);
		}

		public static Rect AddMarginLeft(this Rect rect, float margin)
		{
			return rect.AddMargin(0f, 0f, 0f, margin);
		}

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

		public static void AddMargin(this Rect[] rect, float margin)
		{
			for(int x = 0; x < rect.Length; ++x)
			{
				rect[x] = rect[x].AddMargin(margin);
			}
		}

		public static void AddMargin(this Rect[] rect, float horizontal, float vertical)
		{
			for(int x = 0; x < rect.Length; ++x)
			{
				rect[x] = rect[x].AddMargin(horizontal, vertical);
			}
		}

		public static void AddMargin(this Rect[] rect, float top, float right, float bottom, float left)
		{
			for(int x = 0; x < rect.Length; ++x)
			{
				rect[x] = rect[x].AddMargin(top, right, bottom, left);
			}
		}
		#endregion

		#region Add
		public static Rect AddTop(this Rect rect, float height)
		{
			return new Rect(rect.x, rect.y-height, rect.width, rect.height+height);
		}

		public static Rect AddRight(this Rect rect, float width)
		{
			return new Rect(rect.x, rect.y, rect.width+width, rect.height);
		}

		public static Rect AddBottom(this Rect rect, float height)
		{
			return new Rect(rect.x, rect.y, rect.width, rect.height+height);
		}

		public static Rect AddLeft(this Rect rect, float width)
		{
			return new Rect(rect.x-width, rect.y, rect.width+width, rect.height);
		}
		#endregion

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

		public static RectPair CutLeft(this Rect rect, float amount)
		{
			Rect left = new Rect(rect.x, rect.y, amount, rect.height);
			Rect right = new Rect(rect.x+amount, rect.y, rect.width-amount, rect.height);
			return new RectPair(left, right);
		}

		/// <returns>Right Rectangle</returns>
		public static Rect CutLeft(this Rect rect, float amount, out Rect leftRect)
		{
			RectPair pair = rect.CutLeft(amount);
			leftRect = pair.A;
			return pair.B;
		}

		public static RectPair CutRight(this Rect rect, float amount)
		{
			Rect left = new Rect(rect.x, rect.y, rect.width-amount, rect.height);
			Rect right = new Rect(rect.x+left.width, rect.y, amount, rect.height);
			return new RectPair(left, right);
		}

		/// <returns>Left Rectangle</returns>
		public static Rect CutRight(this Rect rect, float amount, out Rect rightRect)
		{
			RectPair pair = rect.CutRight(amount);
			rightRect = pair.B;
			return pair.A;
		}

		public static RectPair CutTop(this Rect rect, float amount)
		{
			Rect top = new Rect(rect.x, rect.y, rect.width, amount);
			Rect bottom = new Rect(rect.x, rect.y+amount, rect.width, rect.height-amount);
			return new RectPair(top, bottom);
		}

		/// <returns>Bottom Rectangle</returns>
		public static Rect CutTop(this Rect rect, float amount, out Rect topRect)
		{
			RectPair pair = rect.CutTop(amount);
			topRect = pair.A;
			return pair.B;
		}

		public static RectPair CutBottom(this Rect rect, float amount)
		{
			Rect top = new Rect(rect.x, rect.y, rect.width, rect.height-amount);
			Rect bottom = new Rect(rect.x, rect.y+top.height, rect.width, amount);
			return new RectPair(top, bottom);
		}

		/// <returns>Top Rectangle</returns>
		public static Rect CutBottom(this Rect rect, float amount, out Rect bottomRect)
		{
			RectPair pair = rect.CutBottom(amount);
			bottomRect = pair.B;
			return pair.A;
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
				throw new ArgumentNullException($"{nameof(target)}");
			}
			if(ratios != null && ratios.Length > target.Length)
			{
				throw new ArgumentException($"{nameof(ratios)}({ratios.Length}) > {nameof(target)}({target.Length})");
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
