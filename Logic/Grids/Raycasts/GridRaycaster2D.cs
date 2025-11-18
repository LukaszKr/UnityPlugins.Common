using System;
using System.Collections.Generic;

namespace UnityPlugins.Common.Logic
{
	public static class GridRaycaster2D
	{
		public static void Raycast(float startX, float startY, float directionX, float directionY, GridHit2D[] buffer)
		{
			IEnumerator<GridHit2D> enumerator = Raycast(startX, startY, directionX, directionY).GetEnumerator();

			for(int x = 0; x < buffer.Length; ++x)
			{
				enumerator.MoveNext();
				buffer[x] = enumerator.Current;
			}
		}

		public static IEnumerable<GridHit2D> Raycast(float startX, float startY, float directionX, float directionY)
		{
			int stepX = Math.Sign(directionX);
			int stepY = Math.Sign(directionY);

			if(stepX == 0 && stepY == 0)
			{
				yield break;
			}

			int currentX = (int)Math.Floor(startX);
			int currentY = (int)Math.Floor(startY);
			currentX = Math.Max(currentX, 0);
			currentY = Math.Max(currentY, 0);

			float nextBoundX = CalculateBound(currentX, startX, stepX);
			float nextBoundY = CalculateBound(currentY, startY, stepY);

			float deltaX = (1f/directionX)*stepX;
			float deltaY = (1f/directionY)*stepY;

			float travelX = nextBoundX/directionX;
			float travelY = nextBoundY/directionY;

			EGridCardinal2D xExitFace = (stepX > 0 ? EGridCardinal2D.Left : EGridCardinal2D.Right);
			EGridCardinal2D yExitFace = (stepY > 0 ? EGridCardinal2D.Down : EGridCardinal2D.Up);

			EGridCardinal2D selectedFace;
			float startDecimalX = startX-(float)Math.Truncate(startX);
			float startDecimalY = startY-(float)Math.Truncate(startY);
			if(startDecimalX < startDecimalY)
			{
				selectedFace = (directionX > 0 ? EGridCardinal2D.Left : EGridCardinal2D.Right);
			}
			else
			{
				selectedFace = (directionY > 0 ? EGridCardinal2D.Down : EGridCardinal2D.Up);
			}

			while(true)
			{
				GridPoint2D point = new GridPoint2D(currentX, currentY);
				if(travelX < travelY)
				{
					selectedFace = xExitFace;
					yield return new GridHit2D(point, selectedFace);

					currentX += stepX;
					travelX += deltaX;
				}
				else
				{
					selectedFace = yExitFace;
					yield return new GridHit2D(point, selectedFace);

					currentY += stepY;
					travelY += deltaY;
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