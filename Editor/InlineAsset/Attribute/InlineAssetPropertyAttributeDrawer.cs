using System;
using System.Collections.Generic;
using System.Reflection;
using ProceduralLevel.Common.Unity;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
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
			RectPair pair = position.CutTop(20f);
			if(value == null)
			{
				DrawCreateAsset(pair.A, property, label);
			}
			else
			{
				DrawCurrentAsset(pair.A, property, value, label);
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			float height = base.GetPropertyHeight(property, label);

			if(Attribute.DrawEditor && (!Attribute.Expandable || property.isExpanded))
			{
				if(m_PrevEditor != null)
				{
					SerializedProperty iterator = m_PrevEditor.serializedObject.GetIterator();
					while(iterator.NextVisible(true))
					{
						height += EditorGUI.GetPropertyHeight(property, true);
					}
				}
			}

			return height;
		}


		private void DrawCreateAsset(Rect position, SerializedProperty property, GUIContent label)
		{
			RectPair pair = position.CutLeft(EditorGUIUtility.labelWidth);
			Type fieldType = fieldInfo.FieldType;
			if(fieldType.IsArray)
			{
				fieldType = fieldType.GetElementType();
			}
			else if(fieldType.IsGenericType) //lists
			{
				fieldType = fieldType.GetGenericArguments()[0];
			}
			EditorGUI.LabelField(pair.A, label);
			if(GUI.Button(pair.B, fieldType.Name))
			{
				List<Type> validTypes = GetAllAssignableTo(fieldType);
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
			RectPair deletePair = position.CutRight(EditorGUIUtility.singleLineHeight);
			EditorGUI.BeginDisabledGroup(!assetAttribute.AllowExternal);
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
			if(AssetDatabase.IsSubAsset(property.objectReferenceInstanceIDValue))
			{
				AssetDatabase.RemoveObjectFromAsset(property.objectReferenceValue);
			}
			property.objectReferenceValue = null;
			property.serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(target);
			AssetDatabase.SaveAssetIfDirty(target);
		}
		#endregion
	}
}
