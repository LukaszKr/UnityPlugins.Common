using System;

namespace UnityPlugins.Common.Logic
{
	public static class ArrayExt
	{
		#region Create
		public static TData[][] Create<TData>(GridSize2D size)
		{
			return Create<TData>(size.X, size.Y);
		}

		public static TData[][] Create<TData>(int sizeX, int sizeY)
		{
			TData[][] array = new TData[sizeX][];
			for(int x = 0; x < array.Length; ++x)
			{
				array[x] = new TData[sizeY];
			}
			return array;
		}

		public static void Create<TData>(out TData[][] output, GridSize2D size)
		{
			output = Create<TData>(size);
		}

		public static void Create<TData>(out TData[][] output, int sizeX, int sizeY)
		{
			output = Create<TData>(sizeX, sizeY);
		}

		public static TData[][][] Create<TData>(GridSize3D size)
		{
			return Create<TData>(size.X, size.Y, size.Z);
		}

		public static TData[][][] Create<TData>(int sizeX, int sizeY, int sizeZ)
		{
			TData[][][] array = new TData[sizeX][][];
			for(int x = 0; x < array.Length; ++x)
			{
				TData[][] column = new TData[sizeY][];
				array[x] = column;
				for(int y = 0; y < column.Length; ++y)
				{
					column[y] = new TData[sizeZ];
				}
			}
			return array;
		}

		public static void Create<TData>(out TData[][][] output, GridSize3D size)
		{
			output = Create<TData>(size);
		}

		public static void Create<TData>(out TData[][][] output, int sizeX, int sizeY, int sizeZ)
		{
			output = Create<TData>(sizeX, sizeY, sizeZ);
		}
		#endregion

		#region Resize
		public static Array Resize(this Array array, int newSize)
		{
			Type elementType = array.GetType().GetElementType();
			Array newArray = Array.CreateInstance(elementType, newSize);
			Array.Copy(array, newArray, Math.Min(array.Length, newArray.Length));
			return newArray;
		}

		public static void Resize<TData>(ref TData[] array, int length)
		{
			array = array.Resize(length);
		}

		public static TData[] Resize<TData>(this TData[] array, int length)
		{
			TData[] newArray = new TData[length];
			if(array == null)
			{
				return new TData[length];
			}
			int oldLength = array.Length;
			int iter = Math.Min(length, oldLength);
			for(int x = 0; x < iter; ++x)
			{
				newArray[x] = array[x];
			}
			return newArray;
		}

		public static void Resize<TData>(ref TData[][] array, GridSize2D size)
		{
			array = array.Resize(size);
		}

		public static void Resize<TData>(ref TData[][] array, int sizeX, int sizeY)
		{
			array = array.Resize(sizeX, sizeY);
		}

		public static TData[][] Resize<TData>(this TData[][] array, GridSize2D size)
		{
			return array.Resize(size.X, size.Y);
		}

		public static TData[][] Resize<TData>(this TData[][] array, int sizeX, int sizeY)
		{
			TData[][] newArray = Create<TData>(sizeX, sizeY);
			if(array == null)
			{
				return newArray;
			}

			int minSizex = Math.Min(sizeX, array.Length);
			for(int x = 0; x < minSizex; ++x)
			{
				TData[] xAxisNew = newArray[x];
				TData[] xAxis = array[x];
				int minSizeY = Math.Min(xAxisNew.Length, xAxis.Length);
				for(int y = 0; y < minSizeY; ++y)
				{
					xAxisNew[y] = xAxis[y];
				}
			}
			return newArray;
		}

		public static void Resize<TData>(ref TData[][][] array, GridSize3D size)
		{
			array = array.Resize(size);
		}

		public static void Resize<TData>(ref TData[][][] array, int sizeX, int sizeY, int sizeZ)
		{
			array = array.Resize(sizeX, sizeY, sizeZ);
		}

		public static TData[][][] Resize<TData>(this TData[][][] array, GridSize3D size)
		{
			return array.Resize(size.X, size.Y, size.Z);
		}

		public static TData[][][] Resize<TData>(this TData[][][] array, int sizeX, int sizeY, int sizeZ)
		{
			TData[][][] newArray = Create<TData>(sizeX, sizeY, sizeZ);
			if(array == null)
			{
				return newArray;
			}

			int minSizeX = Math.Min(sizeX, array.Length);
			for(int x = 0; x < minSizeX; ++x)
			{
				TData[][] xAxisNew = newArray[x];
				TData[][] xAxis = array[x];
				int minSizeY = Math.Min(xAxisNew.Length, xAxis.Length);
				for(int y = 0; y < minSizeY; ++y)
				{
					TData[] yAxisNew = xAxisNew[y];
					TData[] yAxis = xAxis[y];
					int minSizeZ = Math.Min(yAxisNew.Length, yAxis.Length);
					for(int z = 0; z < minSizeZ; ++z)
					{
						yAxisNew[z] = yAxis[z];
					}
				}
			}
			return newArray;
		}
		#endregion
	}
}
