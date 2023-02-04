using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Editor
{
	internal static class RevertTransformOverride
	{
		private const string NAME = "Revert Overrides";

		private const string REVERT_TRANSFORM = "CONTEXT/"+nameof(Transform)+"/"+NAME;
		private const string REVERT_RECT_TRANSFORM = "CONTEXT/"+nameof(RectTransform)+"/"+NAME;

		[MenuItem(REVERT_TRANSFORM)]
		[MenuItem(REVERT_RECT_TRANSFORM)]
		private static void Revert(MenuCommand command)
		{
			var serObj = new SerializedObject(command.context);
			var prop = serObj.GetIterator();
			while(prop.NextVisible(true))
			{
				PrefabUtility.RevertPropertyOverride(prop, InteractionMode.UserAction);
			}
		}

		[MenuItem(REVERT_TRANSFORM, validate = true)]
		[MenuItem(REVERT_RECT_TRANSFORM, validate = true)]
		private static bool Validate(MenuCommand command)
		{
			var obj = command.context;
			return PrefabUtility.IsPartOfPrefabInstance(obj);
		}
	}
}
