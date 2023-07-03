using System;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InlineAssetAttribute : PropertyAttribute
	{
		public bool DrawEditor;
		public bool Expandable;

		public InlineAssetAttribute(bool drawEditor = true, bool expandable = true)
		{
			DrawEditor = drawEditor;
			Expandable = expandable;
		}
	}
}
