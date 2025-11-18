using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityPlugins.Common.Editor
{
	public static class InstantiatePrefabTool
	{
		[MenuItem("GameObject/Instantiate Prefab %q", priority = -1000)]
		public static void InstantiatePrefab()
		{
			SelectPrefabDropdown dropdown = new SelectPrefabDropdown();
			dropdown.OnPrefabSelected.AddListener(InstantiatePrefab);
			dropdown.ShowAsContext();
		}

		public static void InstantiatePrefab(GameObject prefab)
		{
			GameObject parent = Selection.activeGameObject;
			Transform parentTransform = (parent? parent.transform: null);
			if(parentTransform == null)
			{
				PrefabStage stage = PrefabStageUtility.GetCurrentPrefabStage();
				if(stage != null)
				{
					parentTransform = stage.prefabContentsRoot.transform;
				}
			}
			Object createdObject = PrefabUtility.InstantiatePrefab(prefab, parentTransform);
			int cloneIndex = createdObject.name.LastIndexOf("(Clone)");
			if(cloneIndex > 0)
			{
				createdObject.name = createdObject.name.Substring(0, cloneIndex);
			}
			Undo.RegisterCreatedObjectUndo(createdObject, $"Instantiate: '{prefab.name}'");
		}
	}
}
