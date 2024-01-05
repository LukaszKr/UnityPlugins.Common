using UnityEditor;

namespace ProceduralLevel.Common.Editor
{
	//needed to avoid "getting control x's position in group with only x controls when doing repaint"
	[CanEditMultipleObjects]
	[CustomEditor(typeof(UnityEngine.Object), true)]
	public class UnityObjectEditor : UnityEditor.Editor
	{
	}
}
