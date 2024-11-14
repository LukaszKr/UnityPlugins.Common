using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

namespace UnityPlugins.Common.Unity.Ext
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class RectExtTests
	{
		private const double DELTA = 0.0001;

		private readonly Rect m_Rect = new Rect(0, 0, 100, 100);

		#region Margin
		[Test]
		public void Margin_AddMarginTop()
		{
			Rect expected = new Rect(0, 10, 100, 90);
			Rect actual = m_Rect.AddMarginTop(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMarginRight()
		{
			Rect expected = new Rect(0, 0, 90, 100);
			Rect actual = m_Rect.AddMarginRight(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMarginBottom()
		{
			Rect expected = new Rect(0, 0, 100, 90);
			Rect actual = m_Rect.AddMarginBottom(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMarginLeft()
		{
			Rect expected = new Rect(10, 0, 90, 100);
			Rect actual = m_Rect.AddMarginLeft(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_AllAtOnce()
		{
			Rect expected = new Rect(10, 10, 80, 80);
			Rect actual = m_Rect.AddMargin(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_AllAtOnce_Array()
		{
			Rect expected = new Rect(10, 10, 80, 80);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(10));
		}

		[Test]
		public void Margin_AddMargin_Vertical()
		{
			Rect expected = new Rect(00, 10, 100, 80);
			Rect actual = m_Rect.AddMargin(0, 10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_Vertical_Array()
		{
			Rect expected = new Rect(00, 10, 100, 80);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(0, 10));
		}

		[Test]
		public void Margin_AddMargin_Horizontal()
		{
			Rect expected = new Rect(10, 00, 80, 100);
			Rect actual = m_Rect.AddMargin(10, 0);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_Horizontal_Array()
		{
			Rect expected = new Rect(10, 00, 80, 100);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(10, 0));
		}

		[Test]
		public void Margin_AddMargin_Top()
		{
			Rect expected = new Rect(00, 10, 100, 90);
			Rect actual = m_Rect.AddMargin(10, 0, 0, 0);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_Top_Array()
		{
			Rect expected = new Rect(00, 10, 100, 90);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(10, 0, 0, 0));
		}

		[Test]
		public void Margin_AddMargin_Right()
		{
			Rect expected = new Rect(0, 0, 90, 100);
			Rect actual = m_Rect.AddMargin(0, 10, 0, 0);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_Right_Array()
		{
			Rect expected = new Rect(00, 0, 90, 100);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(0, 10, 0, 0));
		}

		[Test]
		public void Margin_AddMargin_Bottom()
		{
			Rect expected = new Rect(00, 00, 100, 90);
			Rect actual = m_Rect.AddMargin(0, 0, 10, 0);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_Bottom_Array()
		{
			Rect expected = new Rect(00, 00, 100, 90);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(0, 0, 10, 0));
		}

		[Test]
		public void Margin_AddMargin_Left()
		{
			Rect expected = new Rect(10, 00, 90, 100);
			Rect actual = m_Rect.AddMargin(0, 0, 0, 10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Margin_AddMargin_Left_Array()
		{
			Rect expected = new Rect(10, 00, 90, 100);
			AssertAddMarginToRectArray(m_Rect, expected, (r) => r.AddMargin(0, 0, 0, 10));
		}
		#endregion

		#region Add
		[Test]
		public void Add_AddTop()
		{
			Rect rect = new Rect(0, 0, 100, 100);
			Rect expected = new Rect(0, -10, 100, 110);
			Rect actual = m_Rect.AddTop(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Add_AddRight()
		{
			Rect expected = new Rect(0, 0, 110, 100);
			Rect actual = m_Rect.AddRight(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Add_AddBottom()
		{
			Rect expected = new Rect(0, 0, 100, 110);
			Rect actual = m_Rect.AddBottom(10);
			AssertRects(expected, actual);
		}

		[Test]
		public void Add_AddLeft()
		{
			Rect expected = new Rect(-10, 0, 110, 100);
			Rect actual = m_Rect.AddLeft(10);
			AssertRects(expected, actual);
		}
		#endregion

		#region Split
		[Test]
		public void Split_SplitHorizontal()
		{
			Rect expectedA = new Rect(0, 0, 60, 100);
			Rect expectedB = new Rect(60, 0, 40, 100);

			RectPair pair = m_Rect.SplitHorizontal(0.6f);
			AssertRects(pair.A, expectedA);
			AssertRects(pair.B, expectedB);
		}

		[Test]
		public void Split_SplitVertical()
		{
			Rect expectedA = new Rect(0, 0, 100, 60);
			Rect expectedB = new Rect(0, 60, 100, 40);

			RectPair pair = m_Rect.SplitVertical(0.6f);

			AssertRects(pair.A, expectedA);
			AssertRects(pair.B, expectedB);
		}

		[Test]
		public void Split_SplitHorizontal_Array_NoRatio()
		{
			Rect[] output = new Rect[4];
			Rect[] expected = new Rect[]
			{
				new Rect(0, 0, 25, 100),
				new Rect(25, 0, 25, 100),
				new Rect(50, 0, 25, 100),
				new Rect(75, 0, 25, 100)
			};

			m_Rect.SplitHorizontal(output);
			AssertRects(expected, output);
		}

		[Test]
		public void Split_SplitVertical_Array_WithRatio()
		{
			Rect[] output = new Rect[3];
			float[] ratios = new float[] { 0.1f, 0.4f, 0.5f };
			Rect[] expected = new Rect[]
			{
				new Rect(0, 0, 100, 10),
				new Rect(0, 10, 100, 40),
				new Rect(0, 50, 100, 50),
			};

			m_Rect.SplitVertical(output, ratios);
			AssertRects(expected, output);
		}

		[Test]
		public void Split_SplitHorizontal_Array_WithRatio()
		{
			Rect[] output = new Rect[3];
			float[] ratios = new float[] { 0.1f, 0.4f, 0.5f };
			Rect[] expected = new Rect[]
			{
				new Rect(0, 0, 10, 100),
				new Rect(10, 0, 40, 100),
				new Rect(50, 0, 50, 100),
			};

			m_Rect.SplitHorizontal(output, ratios);
			AssertRects(expected, output);
		}

		[Test]
		public void Split_SplitVertical_Array_NoRatio()
		{
			Rect[] output = new Rect[4];
			Rect[] expected = new Rect[]
			{
				new Rect(0, 0, 100, 25),
				new Rect(0, 25, 100, 25),
				new Rect(0, 50, 100, 25),
				new Rect(0, 75, 100, 25)
			};

			m_Rect.SplitVertical(output);
			AssertRects(expected, output);
		}
		#endregion

		#region Cut
		[Test]
		public void Cut_CutLeft()
		{
			RectPair pair = m_Rect.CutLeft(40);
			Rect expectedA = new Rect(0, 0, 40, 100);
			Rect expectedB = new Rect(40, 0, 60, 100);
			AssertRects(expectedA, pair.A);
			AssertRects(expectedB, pair.B);
		}

		[Test]
		public void Cut_CutLeft_Out()
		{
			Rect leftRect;
			Rect rightRect = m_Rect.CutLeft(40, out leftRect);
			Rect expectedLeftRect = new Rect(0, 0, 40, 100);
			Rect expectedRightRect = new Rect(40, 0, 60, 100);
			AssertRects(expectedLeftRect, leftRect);
			AssertRects(expectedRightRect, rightRect);
		}

		[Test]
		public void Cut_CutRight()
		{
			RectPair pair = m_Rect.CutRight(40);
			Rect expectedLeftRect = new Rect(0, 0, 60, 100);
			Rect expectedRightRect = new Rect(60, 0, 40, 100);
			AssertRects(expectedLeftRect, pair.A);
			AssertRects(expectedRightRect, pair.B);
		}

		[Test]
		public void Cut_CutRight_Out()
		{
			Rect rightRect;
			Rect leftRect = m_Rect.CutRight(40, out rightRect);
			Rect expectedLeftRect = new Rect(0, 0, 60, 100);
			Rect expectedRightRect = new Rect(60, 0, 40, 100);
			AssertRects(expectedLeftRect, leftRect);
			AssertRects(expectedRightRect, rightRect);
		}

		[Test]
		public void Cut_CutTop()
		{
			RectPair pair = m_Rect.CutTop(40);
			Rect expectedTopRect = new Rect(0, 0, 100, 40);
			Rect expectedBottomRect = new Rect(0, 40, 100, 60);
			AssertRects(expectedTopRect, pair.A);
			AssertRects(expectedBottomRect, pair.B);
		}

		[Test]
		public void Cut_CutTop_Out()
		{
			Rect topRect;
			Rect bottomRect = m_Rect.CutTop(40, out topRect);
			Rect expectedTopRect = new Rect(0, 0, 100, 40);
			Rect expectedBottomRect = new Rect(0, 40, 100, 60);
			AssertRects(expectedTopRect, topRect);
			AssertRects(expectedBottomRect, bottomRect);
		}

		[Test]
		public void Cut_CutBottom()
		{
			RectPair pair = m_Rect.CutBottom(40);
			Rect expectedTopRect = new Rect(0, 0, 100, 60);
			Rect expectedBottomRect = new Rect(0, 60, 100, 40);
			AssertRects(expectedTopRect, pair.A);
			AssertRects(expectedBottomRect, pair.B);
		}

		[Test]
		public void Cut_CutBottom_Out()
		{
			Rect bottomRect;
			Rect topRect = m_Rect.CutBottom(40, out bottomRect);
			Rect expectedTopRect = new Rect(0, 0, 100, 60);
			Rect expectedBottomRect = new Rect(0, 60, 100, 40);
			AssertRects(expectedTopRect, topRect);
			AssertRects(expectedBottomRect, bottomRect);
		}
		#endregion

		#region Helpers
		private void AssertAddMarginToRectArray(Rect rect, Rect expectedRect, Action<Rect[]> applyCallback)
		{
			Rect[] actual = new Rect[] { rect, rect };
			Rect[] expected = new Rect[] { expectedRect, expectedRect };
			applyCallback(actual);
			AssertRects(expected, actual);
		}

		private void AssertRects(Rect[] expected, Rect[] actual)
		{
			Assert.IsFalse(expected == actual);
			Assert.AreEqual(expected.Length, actual.Length);
			for(int x = 0; x < expected.Length; ++x)
			{
				AssertRects(expected[x], actual[x]);
			}
		}

		private void AssertRects(Rect expected, Rect actual)
		{
			Assert.AreEqual(expected.x, actual.x, DELTA, "x");
			Assert.AreEqual(expected.y, actual.y, DELTA, "y");
			Assert.AreEqual(expected.width, actual.width, DELTA, "width");
			Assert.AreEqual(expected.height, actual.height, DELTA, "height");
		}
		#endregion
	}
}
