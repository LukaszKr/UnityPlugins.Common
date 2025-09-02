using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public static class GridRaycaster3D
	{
		public static void Raycast(float startX, float startY, float startZ, float directionX, float directionY, float directionZ, GridHit3D[] buffer)
		{
			IEnumerator<GridHit3D> enumerator = Raycast(startX, startY, startZ, directionX, directionY, directionZ).GetEnumerator();

			for(int x = 0; x < buffer.Length; ++x)
			{
				enumerator.MoveNext();
				buffer[x] = enumerator.Current;
			}
		}

		public static IEnumerable<GridHit3D> Raycast(float startX, float startY, float startZ, float directionX, float directionY, float directionZ)
		{
			int stepX = Math.Sign(directionX);
			int stepY = Math.Sign(directionY);
			int stepZ = Math.Sign(directionZ);

			if(stepX == 0 && stepY == 0 && stepZ == 0)
			{
				yield break;
			}

			int currentX = (int)Math.Floor(startX);
			int currentY = (int)Math.Floor(startY);
			int currentZ = (int)Math.Floor(startZ);

			float nextBoundX = CalculateBound(currentX, startX, stepX);
			float nextBoundY = CalculateBound(currentY, startY, stepY);
			float nextBoundZ = CalculateBound(currentZ, startZ, stepZ);

			float deltaX = (1f/directionX)*stepX;
			float deltaY = (1f/directionY)*stepY;
			float deltaZ = (1f/directionZ)*stepZ;

			float travelX = nextBoundX/directionX;
			float travelY = nextBoundY/directionY;
			float travelZ = nextBoundZ/directionZ;

			EGridCardinal3D xExitFace = (stepX > 0 ? EGridCardinal3D.Left : EGridCardinal3D.Right);
			EGridCardinal3D yExitFace = (stepY > 0 ? EGridCardinal3D.Down : EGridCardinal3D.Up);
			EGridCardinal3D zExitFace = (stepZ > 0 ? EGridCardinal3D.Back : EGridCardinal3D.Front);

			EGridCardinal3D selectedFace;
			float startDecimalX = startX-(float)Math.Truncate(startX);
			float startDecimalY = startY-(float)Math.Truncate(startY);
			float startDecimalZ = startZ-(float)Math.Truncate(startZ);
			if(startDecimalX < startDecimalY && startDecimalX < startDecimalZ)
			{
				selectedFace = (directionX > 0 ? EGridCardinal3D.Left : EGridCardinal3D.Right);
			}
			else if(startDecimalY < startDecimalX && startDecimalY < startDecimalZ)
			{
				selectedFace = (directionY > 0 ? EGridCardinal3D.Down : EGridCardinal3D.Up);
			}
			else
			{
				selectedFace = (directionZ > 0 ? EGridCardinal3D.Back : EGridCardinal3D.Front);
			}

			int sanity = 200;
			while(sanity > 0)
			{
				--sanity;
				GridPoint3D point = new GridPoint3D(currentX, currentY, currentZ);
				if(travelX < travelY)
				{
					if(travelX < travelZ)
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = xExitFace;

						currentX += stepX;
						travelX += deltaX;
					}
					else
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
				}
				else
				{
					if(travelY < travelZ)
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = yExitFace;

						currentY += stepY;
						travelY += deltaY;
					}
					else
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
				}
			}
		}

		private static float CalculateBound(int current, float start, int step)
		{
			if(step == 0)
			{
				return float.MaxValue;
			}
			if(step > 0)
			{
				return (current-start+step);
			}
			else
			{
				return (current-start);
			}
		}
	}
}