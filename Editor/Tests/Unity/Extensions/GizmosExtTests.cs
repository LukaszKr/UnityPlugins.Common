using System;
using NUnit.Framework;
using UnityEngine;

namespace UnityPlugins.Common.Unity.Ext
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class GizmosExtTests
	{
		#region Matrix
		[Test]
		public void Matrix()
		{
			Matrix4x4 oldMat = Gizmos.matrix;
			Matrix4x4 mat = Matrix4x4.identity;
			GizmosExt.PushMatrix(mat);
			Assert.AreEqual(Gizmos.matrix, mat);
			GizmosExt.PopMatrix();
			Assert.AreEqual(Gizmos.matrix, oldMat);
		}

		[Test]
		public void Matrix_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GizmosExt.PopMatrix());
		}
		#endregion

		#region Color
		[Test]
		public void Color_Main()
		{
			Color oldColor = Gizmos.color;
			Color color = Color.red;
			GizmosExt.PushColor(color);
			Assert.AreEqual(Gizmos.color, color);
			GizmosExt.PopColor();
			Assert.AreEqual(Gizmos.color, oldColor);
		}

		[Test]
		public void Color_Main_Pop_EmptyStack()
		{
			Assert.Throws<InvalidOperationException>(() => GizmosExt.PopColor());
		}
		#endregion
	}
}
