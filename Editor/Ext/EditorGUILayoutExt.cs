using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.Common.Editor
{
	public static class EditorGUILayoutExt
	{
		private const int INT_INDEX = 0;
		private const int FLOAT_INDEX = 1;
		private const int BOOL_INDEX = 2;
		private const int STRING_INDEX = 3;
		private const int ENUM_INDEX = 4;

		private delegate object ValueOptionsCallback(object value, params GUILayoutOption[] options);
		private delegate object ValueStyleOptionsCallback(object value, GUIStyle style, params GUILayoutOption[] options);
		private delegate object LabelValueOptionsCallback(GUIContent label, object value, params GUILayoutOption[] options);
		private delegate object LabelValueStyleOptionsCallback(GUIContent label, object value, GUIStyle style, params GUILayoutOption[] options);

		private static ValueOptionsCallback[] m_ValueOptionCallbacks = new ValueOptionsCallback[]
		{
			(value, options) => { return EditorGUILayout.IntField((int)value, options); },
			(value, options) => { return EditorGUILayout.FloatField((float)value, options); },
			(value, options) => { return EditorGUILayout.Toggle((bool)value, options); },
			(value, options) => { return EditorGUILayout.TextField((string)value, options); },
			(value, options) => { return EditorGUILayout.EnumFlagsField((Enum)value, options); }
};

		private static ValueStyleOptionsCallback[] m_ValueStyleOptionsCallbacks = new ValueStyleOptionsCallback[]
		{
			(value, style, options) => { return EditorGUILayout.IntField((int)value, style, options); },
			(value, style, options) => { return EditorGUILayout.FloatField((float)value, style, options); },
			(value, style, options) => { return EditorGUILayout.Toggle((bool)value, style, options); },
			(value, style, options) => { return EditorGUILayout.TextField((string)value, style, options); },
			(value, style, options) => { return EditorGUILayout.EnumFlagsField((Enum)value, style, options); }
		};

		private static LabelValueOptionsCallback[] m_LabelValueOptionsCallbacks = new LabelValueOptionsCallback[]
		{
			(label, value, options) => { return EditorGUILayout.IntField(label, (int)value, options); },
			(label, value, options) => { return EditorGUILayout.FloatField(label, (float)value, options); },
			(label, value, options) => { return EditorGUILayout.Toggle(label, (bool)value, options); },
			(label, value, options) => { return EditorGUILayout.TextField(label, (string)value, options); },
			(label, value, options) => { return EditorGUILayout.EnumPopup(label, (Enum)value, options); }
		};

		private static LabelValueStyleOptionsCallback[] m_LabelValueStyleOptionsCallbacks = new LabelValueStyleOptionsCallback[]
		{
			(label, value, style, options) => { return EditorGUILayout.IntField(label, (int)value, style, options); },
			(label, value, style, options) => { return EditorGUILayout.FloatField(label, (float)value, style, options); },
			(label, value, style, options) => { return EditorGUILayout.Toggle(label, (bool)value, style, options); },
			(label, value, style, options) => { return EditorGUILayout.TextField(label, (string)value, style, options); },
			(label, value, style, options) => { return EditorGUILayout.EnumPopup(label, (Enum)value, style, options); }
		};

		public static object FieldInfoField(object src, FieldInfo info, params GUILayoutOption[] options)
		{
			int index = TypeToIndex(info.FieldType);
			return m_ValueOptionCallbacks[index](info.GetValue(src), options);
		}

		public static object FieldInfoField(object src, FieldInfo info, GUIStyle style, params GUILayoutOption[] options)
		{
			int index = TypeToIndex(info.FieldType);
			return m_ValueStyleOptionsCallbacks[index](info.GetValue(src), style, options);
		}

		public static object FieldInfoField(object src, GUIContent label, FieldInfo info, params GUILayoutOption[] options)
		{
			int index = TypeToIndex(info.FieldType);
			return m_LabelValueOptionsCallbacks[index](label, info.GetValue(src), options);
		}

		public static object FieldInfoField(object src, GUIContent label, FieldInfo info, GUIStyle style, params GUILayoutOption[] options)
		{
			int index = TypeToIndex(info.FieldType);
			return m_LabelValueStyleOptionsCallbacks[index](label, info.GetValue(src), style, options);
		}

		private static int TypeToIndex(Type type)
		{
			if(type == typeof(int))
			{
				return INT_INDEX;
			}
			else if(type == typeof(float))
			{
				return FLOAT_INDEX;
			}
			else if(type == typeof(bool))
			{
				return BOOL_INDEX;
			}
			else if(type == typeof(string))
			{
				return STRING_INDEX;
			}
			else if(type.IsEnum)
			{
				return ENUM_INDEX;
			}
			throw new NotSupportedException();
		}
	}
}
