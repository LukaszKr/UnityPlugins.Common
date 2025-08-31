using UnityEditor;
using Object = UnityEngine.Object;

namespace UnityPlugins.Common.Editor
{
	public static class InstantiatePrefabTool
	{
		[MenuItem("GameObject/Instantiate Prefab", priority = -1000)]
		public static void InstantiatePrefab()
		{
			SelectPrefabDropdown dropdown = new SelectPrefabDropdown();
			dropdown.OnPrefabSelected.AddListener((prefab) =>
			{
				Object.Instantiate(prefab, null);
			});
			dropdown.ShowAtCurrentMousePosition();
		}
	}
}
