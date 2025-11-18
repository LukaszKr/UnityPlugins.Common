using System;
using NUnit.Framework;
using UnityEngine;

namespace UnityPlugins.Common.Unity.Ext
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GUIExtTests
	{
		#region Enabled
		[Test]
		public void Enabled()
		{
			bool oldEnabled = GUI.enabled;
			bool enabled = true;
			GUIExt.PushEnabled(enabled);
			Assert.AreEqual(GUI.enabled, enabled);
			GUIExt.PopEnabled();
			Assert.AreEqual(GUI.enabled, oldEnabled);
		}

		[Test]
		public void Enabled_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GUIExt.PopEnabled());
		}
		#endregion

		#region Matrix
		[Test]
		public void Matrix()
		{
			Matrix4x4 oldMat = GUI.matrix;
			Matrix4x4 mat = Matrix4x4.identity;
			GUIExt.PushMatrix(mat);
			Assert.AreEqual(GUI.matrix, mat);
			GUIExt.PopMatrix();
			Assert.AreEqual(GUI.matrix, oldMat);
		}

		[Test]
		public void Matrix_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GUIExt.PopMatrix());
		}
		#endregion

		#region Color
		[Test]
		public void Color_Main()
		{
			Color oldColor = GUI.color;
			Color color = Color.red;
			GUIExt.PushColor(color);
			Assert.AreEqual(GUI.color, color);
			GUIExt.PopColor();
			Assert.AreEqual(GUI.color, oldColor);
		}

		[Test]
		public void Color_Main_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GUIExt.PopColor());
		}

		[Test]
		public void Color_Background()
		{
			Color oldColor = GUI.backgroundColor;
			Color color = Color.red;
			GUIExt.PushBackgroundColor(color);
			Assert.AreEqual(GUI.backgroundColor, color);
			GUIExt.PopBackgroundColor();
			Assert.AreEqual(GUI.backgroundColor, oldColor);
		}

		[Test]
		public void Color_Background_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GUIExt.PopBackgroundColor());
		}

		[Test]
		public void Color_Content()
		{
			Color oldColor = GUI.contentColor;
			Color color = Color.red;
			GUIExt.PushContentColor(color);
			Assert.AreEqual(GUI.contentColor, color);
			GUIExt.PopContentColor();
			Assert.AreEqual(GUI.contentColor, oldColor);
		}

		[Test]
		public void Color_Content_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GUIExt.PopContentColor());
		}
		#endregion
	}
}
