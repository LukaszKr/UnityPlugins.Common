using ProceduralLevel.Common.Unity;

namespace ProceduralLevel.Common.Samples
{
	internal class DeeplyNestedAsset : AInlineAsset
	{
		[InlineAsset]
		public AInlineAsset Nested = null;
	}
}
