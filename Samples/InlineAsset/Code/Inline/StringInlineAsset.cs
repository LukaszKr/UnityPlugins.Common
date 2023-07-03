using UnityEngine;

namespace ProceduralLevel.Common.Samples
{
	public class StringInlineAsset : AInlineAsset
	{
		[TextArea(3, 5)]
		public string SomeText;
	}
}
