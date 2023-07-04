using System.Collections.Generic;
using ProceduralLevel.Common.Unity;
using UnityEngine;

namespace ProceduralLevel.Common.Samples
{
	[CreateAssetMenu(fileName = NAME, menuName = SamplesConsts.MENU+NAME)]
	public class ParentAsset : ScriptableObject
	{
		public const string NAME = nameof(ParentAsset);

		public bool bufferField;
		[InlineAsset]
		public AInlineAsset BaseAssetA;
		[InlineAsset]
		public AInlineAsset BaseAssetB;
		[InlineAsset(false)]
		public AInlineAsset[] ArrayOfAssets;
		[InlineAsset(false)]
		public List<AInlineAsset> ListOfAssets;
	}
}
