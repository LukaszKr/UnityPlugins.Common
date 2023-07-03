using System;
using System.Collections.Generic;
using System.Reflection;
using ProceduralLevel.Common.Unity;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProceduralLevel.Common.Editor
{
	[CustomPropertyDrawer(typeof(InlineAssetAttribute), true)]
	public class InlineAssetPropertyAttributeDrawer : APropertyAttributeDrawer<InlineAssetAttribute>
	{
		private UnityEditor.Editor m_PrevEditor;

		protected override void Draw(Rect position, SerializedProperty property, GUIContent label)
		{
			Object value = property.objectReferenceValue;
			if(value == null)
			{
				DrawCreateAsset(position, property, label);
			}
			else
			{
				DrawCurrentAsset(position, property, value, label);
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return base.GetPropertyHeight(property, label);
		}

		private void DrawCreateAsset(Rect position, SerializedProperty property, GUIContent label)
		{
			RectPair pair = position.CutLeft(EditorGUIUtility.labelWidth);
			EditorGUI.LabelField(pair.A, label);
			if(GUI.Button(pair.B, fieldInfo.FieldType.Name))
			{
				List<Type> validTypes = GetAllAssignableTo(fieldInfo.FieldType);
				validTypes.Sort((a, b) => a.Name.CompareTo(b.Name));
				GenericMenu menu = new GenericMenu();
				int count = validTypes.Count;
				for(int x = 0; x < count; ++x)
				{
					Type type = validTypes[x];
					menu.AddItem(new GUIContent(type.Name), false, () => CreateAssetOfType(property, type));
				}
				menu.ShowAsContext();
			}
		}

		private void DrawCurrentAsset(Rect position, SerializedProperty property, Object target, GUIContent label)
		{
			InlineAssetAttribute assetAttribute = Attribute;
			EnsureName(property, target);
			RectPair labelPair = position.CutLeft(EditorGUIUtility.labelWidth);
			position = labelPair.B;
			if(assetAttribute.DrawEditor && assetAttribute.Expandable)
			{
				property.isExpanded = EditorGUI.Foldout(labelPair.A, property.isExpanded, property.displayName);
			}
			else
			{
				EditorGUI.LabelField(labelPair.A, property.displayName);
			}
			RectPair deletePair = position.CutRight(32);
			EditorGUI.BeginDisabledGroup(true);
			EditorGUI.ObjectField(deletePair.A, target, target.GetType(), false);
			EditorGUI.EndDisabledGroup();
			if(GUI.Button(deletePair.B, "X"))
			{
				DeleteAsset(property);
			}
			if(assetAttribute.DrawEditor && (!assetAttribute.Expandable || property.isExpanded))
			{
				UnityEditor.Editor.CreateCachedEditor(target, null, ref m_PrevEditor);
				EditorGUI.indentLevel++;
				m_PrevEditor.OnInspectorGUI();
				EditorGUI.indentLevel--;
			}
		}

		public static List<Type> GetAllAssignableTo(Type baseType)
		{
			List<Type> validTypes = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for(int x = 0; x < assemblies.Length; ++x)
			{
				Assembly assembly = assemblies[x];
				Type[] types = assembly.GetTypes();
				for(int y = 0; y < types.Length; ++y)
				{
					Type type = types[y];
					if(!type.IsAbstract && baseType.IsAssignableFrom(type))
					{
						validTypes.Add(type);
					}
				}
			}
			return validTypes;
		}

		private void EnsureName(SerializedProperty property, Object target)
		{
			string expectedName = $"{property.name}_{target.GetType().Name}";
			if(target.name != expectedName)
			{
				target.name = expectedName;
			}
		}

		#region Asset
		private void CreateAssetOfType(SerializedProperty property, Type type)
		{
			ScriptableObject instance = ScriptableObject.CreateInstance(type);
			Object target = property.serializedObject.targetObject;
			EnsureName(property, target);
			AssetDatabase.AddObjectToAsset(instance, target);
			property.objectReferenceValue = instance;
			property.serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(target);
			AssetDatabase.SaveAssetIfDirty(target);
		}

		private void DeleteAsset(SerializedProperty property)
		{
			Object target = property.serializedObject.targetObject;
			AssetDatabase.RemoveObjectFromAsset(property.objectReferenceValue);
			property.objectReferenceValue = null;
			property.serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(target);
			AssetDatabase.SaveAssetIfDirty(target);
		}
		#endregion
	}
}
