using UnityEngine;

namespace UnityPlugins.Common.Unity
{
	public static class ApplicationExt
	{
		/// <summary>
		/// Quit that works in editor
		/// </summary>
		public static void Quit()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
			Application.Quit();
		}
	}
}
