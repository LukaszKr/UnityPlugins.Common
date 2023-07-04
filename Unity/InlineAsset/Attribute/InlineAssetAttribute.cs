using System;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InlineAssetAttribute : PropertyAttribute
	{
		public readonly bool DrawEditor;
		public readonly bool Expandable;
		public readonly bool AllowExternal;

		public InlineAssetAttribute(bool drawEditor = true, bool expandable = true, bool allowExternal = false)
		{
			DrawEditor = drawEditor;
			Expandable = expandable;
			AllowExternal = allowExternal;
		}
	}
}
