using UnityEditor;
using Object = UnityEngine.Object;

namespace UnityPlugins.Common.Editor
{
	public static class InstantiatePrefabTool
	{
		[MenuItem("GameObject/Instantiate Prefab %q", priority = -1000)]
		public static void InstantiatePrefab()
		{
			SelectPrefabDropdown dropdown = new SelectPrefabDropdown();
			dropdown.OnPrefabSelected.AddListener((prefab) =>
			{
				Object createdObject = Object.Instantiate(prefab, null);
				Undo.RegisterCreatedObjectUndo(createdObject, $"Instantiate: '{prefab.name}'");
			});
			dropdown.ShowAtCurrentMousePosition();
		}
	}
}
