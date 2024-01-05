using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.Common.Editor
{
	public static class RevertOverrideTool
	{
		private const string NAME = "Revert Overrides";

		private const string MENU_REVERT_TRANSFORM = "CONTEXT/"+nameof(Transform)+"/"+NAME;
		private const string MENU_REVERT_RECT_TRANSFORM = "CONTEXT/"+nameof(RectTransform)+"/"+NAME;

		[MenuItem(MENU_REVERT_TRANSFORM)]
		[MenuItem(MENU_REVERT_RECT_TRANSFORM)]
		private static void Revert(MenuCommand command)
		{
			Revert(command.context);

		}

		[MenuItem(MENU_REVERT_TRANSFORM, validate = true)]
		[MenuItem(MENU_REVERT_RECT_TRANSFORM, validate = true)]
		private static bool Validate(MenuCommand command)
		{
			Object obj = command.context;
			return PrefabUtility.IsPartOfPrefabInstance(obj);
		}

		public static void Revert(Object target)
		{
			SerializedObject serializedObject = new SerializedObject(target);
			Revert(serializedObject);
		}

		public static void Revert(SerializedObject target)
		{
			SerializedProperty prop = target.GetIterator();
			while(prop.NextVisible(true))
			{
				PrefabUtility.RevertPropertyOverride(prop, InteractionMode.UserAction);
			}
		}
	}
}
