using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public class ScriptableObjectGizmosComponent : ExtendedMonoBehaviour
	{
		public ScriptableObject Gizmos;

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			IScriptableObjectGizmos drawer = UnityEditor.Selection.activeObject as IScriptableObjectGizmos;
			if(drawer != null)
			{
				drawer.DrawGizmos();
				return;
			}

			drawer = Gizmos as IScriptableObjectGizmos;
			if(drawer == null)
			{
				return;
			}
			drawer.DrawGizmos();
		}
#endif
	}
}
