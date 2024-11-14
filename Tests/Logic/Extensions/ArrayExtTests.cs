using System;
using NUnit.Framework;

namespace UnityPlugins.Common.Logic.Ext
{
	[Category(CommonTestsConsts.CATEGORY_ASSEMBLY)]
	internal class ArrayExtTests
	{
		[Test, Description("Create 2D array.")]
		public void Create2D()
		{
			int[][] array = ArrayExt.Create<int>(4, 5);
			AssertArraySize2D(array, 4, 5);
		}

		[Test, Description("Create 3D array.")]
		public void Create3D()
		{
			int[][][] array3D = ArrayExt.Create<int>(4, 5, 6);

			AssertArraySize3D(array3D, 4, 5, 6);
		}

		#region Resize1D
		[Test, Description("Resize 1D array. If new length is different, change size.")]
		[TestCase(5, Description = "Same")]
		[TestCase(4, Description = "Smaller")]
		[TestCase(6, Description = "Larger")]
		public void Resize1D(int sizeX)
		{
			int[] original = new int[] { 5, 4, 3, 2, 1 };
			int[] resized = original.Resize(sizeX);

			Assert.IsFalse(original == resized);
			Assert.AreEqual(sizeX, resized.Length);
			int lengthX = Math.Min(sizeX, original.Length);
			for(int x = 0; x < lengthX; ++x)
			{
				Assert.AreEqual(original[x], resized[x]);
			}
		}
		#endregion

		#region Resize2D
		[Test, Description("Resize 2D array. If new length is smaller, create smaller array.")]
		[TestCase(5, 5, Description = "Same Size")]
		[TestCase(4, 4, Description = "Smaller")]
		[TestCase(4, 5, Description = "Smaller X")]
		[TestCase(5, 4, Description = "Smaller Y")]
		[TestCase(6, 6, Description = "Larger")]
		[TestCase(6, 5, Description = "Larger X")]
		[TestCase(5, 6, Description = "Larger Y")]
		public void Resize2D(int sizeX, int sizeY)
		{
			int[][] original = ArrayExt.Create<int>(5, 5);
			for(int x = 0; x < original.Length; ++x)
			{
				int[] yOriginal = original[x];
				for(int y = 0; y < yOriginal.Length; ++y)
				{
					yOriginal[y] = y+1;
				}
			}
			int[][] resized = original.Resize(sizeX, sizeY);

			Assert.IsFalse(original == resized);
			Assert.AreEqual(sizeX, resized.Length);
			int lengthX = Math.Min(sizeX, original.Length);
			for(int x = 0; x < lengthX; ++x)
			{
				int[] yOriginal = original[x];
				int[] yResized = resized[x];
				Assert.IsFalse(yOriginal == yResized);
				Assert.AreEqual(sizeY, yResized.Length);
				int lengthY = Math.Min(sizeY, yOriginal.Length);
				for(int y = 0; y < lengthY; ++y)
				{
					Assert.AreEqual(yOriginal[y], yResized[y]);
				}
			}
		}
		#endregion

		#region Resize3D
		[Test, Description("Resize 3D array. If new length is smaller, create smaller array.")]
		[TestCase(5, 5, 5, Description = "Same")]
		[TestCase(4, 4, 4, Description = "Smaller")]
		[TestCase(4, 5, 5, Description = "Smaller X")]
		[TestCase(5, 4, 5, Description = "Smaller Y")]
		[TestCase(5, 5, 4, Description = "Smaller Z")]
		[TestCase(6, 6, 6, Description = "Larger")]
		[TestCase(6, 5, 5, Description = "Larger X")]
		[TestCase(5, 6, 5, Description = "Larger Y")]
		[TestCase(5, 5, 6, Description = "Larger Z")]
		public void Resize3D(int sizeX, int sizeY, int sizeZ)
		{
			int[][][] original = ArrayExt.Create<int>(5, 5, 5);
			for(int x = 0; x < original.Length; ++x)
			{
				int[][] yOriginal = original[x];
				for(int y = 0; y < yOriginal.Length; ++y)
				{
					int[] zOriginal = yOriginal[y];
					for(int z = 0; z < zOriginal.Length; ++z)
					{
						zOriginal[z] = z+1;
					}
				}
			}
			int[][][] resized = original.Resize(sizeX, sizeY, sizeZ);

			Assert.IsFalse(original == resized);
			Assert.AreEqual(sizeX, resized.Length);
			int lengthX = Math.Min(sizeX, original.Length);
			for(int x = 0; x < lengthX; ++x)
			{
				int[][] yOriginal = original[x];
				int[][] yResized = resized[x];
				Assert.IsFalse(yOriginal == yResized);
				Assert.AreEqual(sizeY, yResized.Length);
				int lengthY = Math.Min(sizeY, yOriginal.Length);
				for(int y = 0; y < lengthY; ++y)
				{
					int[] zOriginal = yOriginal[y];
					int[] zResized = yResized[y];
					Assert.IsFalse(zOriginal == zResized);
					Assert.AreEqual(sizeZ, zResized.Length);
					int lengthZ = Math.Min(sizeZ, zOriginal.Length);
					for(int z = 0; z < lengthZ; ++z)
					{
						Assert.AreEqual(zOriginal[z], zResized[z]);
					}
				}
			}
		}
		#endregion

		#region Helpers
		private void AssertArraySize2D<T>(T[][] array, int sizeX, int sizeY)
		{
			Assert.IsNotNull(array);
			Assert.AreEqual(sizeX, array.Length);
			for(int x = 0; x < array.Length; ++x)
			{
				T[] xArray = array[x];
				Assert.IsNotNull(xArray);
				Assert.AreEqual(sizeY, xArray.Length);
			}
		}

		private void AssertArraySize3D<T>(T[][][] array, int sizeX, int sizeY, int sizeZ)
		{
			Assert.IsNotNull(array);
			Assert.AreEqual(sizeX, array.Length);
			for(int x = 0; x < array.Length; ++x)
			{
				T[][] xArray = array[x];
				Assert.IsNotNull(xArray);
				Assert.AreEqual(sizeY, xArray.Length);
				for(int y = 0; y < xArray.Length; ++y)
				{
					T[] yArray = xArray[y];
					Assert.IsNotNull(yArray);
					Assert.AreEqual(sizeZ, yArray.Length);
				}
			}
		}
		#endregion
	}
}
