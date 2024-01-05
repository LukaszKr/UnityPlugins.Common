using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace ProceduralLevel.Preferences
{
	public static class EditorPrefsHelper
	{
		private const bool INCLUDE_PRIVATE = false;
		private static List<Type> VALID_TYPES = new List<Type> { typeof(string), typeof(int), typeof(float), typeof(bool) };

		#region Generic
		public static void Clear<DataType>(string prefix, bool staticFields, bool includePrivate = INCLUDE_PRIVATE) where DataType : class
		{
			List<FieldInfo> fields = GetValidFields(typeof(DataType), staticFields, includePrivate);
			for(int x = 0; x < fields.Count; x++)
			{
				FieldInfo field = fields[x];
				EditorPrefs.DeleteKey(prefix+field.Name);
			}
		}

		public static void Write<DataType>(string prefix, bool includePrivate = INCLUDE_PRIVATE) where DataType : class
		{
			Write(typeof(DataType), null, prefix, includePrivate);
		}

		public static void Write<DataType>(DataType obj, string prefix, bool includePrivate = INCLUDE_PRIVATE) where DataType : class
		{
			Write(typeof(DataType), obj, prefix, includePrivate);
		}

		public static void Write(Type type, string prefix, bool includePrivate = INCLUDE_PRIVATE)
		{
			Write(type, null, prefix, includePrivate);
		}

		private static void Write(Type type, object obj, string prefix, bool includePrivate)
		{
			List<FieldInfo> fields = GetValidFields(type, obj == null, includePrivate);
			for(int x = 0; x < fields.Count; x++)
			{
				FieldInfo field = fields[x];
				Set(field.FieldType, prefix+field.Name, field.GetValue(obj));
			}
		}

		public static void Read<DataType>(string prefix, bool includePrivate = INCLUDE_PRIVATE) where DataType : class
		{
			Read(typeof(DataType), null, prefix, includePrivate);
		}

		public static void Read<DataType>(DataType obj, string prefix, bool includePrivate = INCLUDE_PRIVATE) where DataType : class
		{
			Read(typeof(DataType), obj, prefix, includePrivate);
		}

		public static void Read(Type type, string prefix, bool includePrivate = INCLUDE_PRIVATE)
		{
			Read(type, null, prefix, includePrivate);
		}

		private static void Read(Type type, object obj, string prefix, bool includePrivate)
		{
			List<FieldInfo> fields = GetValidFields(type, obj == null, includePrivate);
			for(int x = 0; x < fields.Count; x++)
			{
				FieldInfo field = fields[x];
				field.SetValue(obj, Get(field.FieldType, prefix+field.Name, field.GetValue(obj)));
			}
		}

		public static List<FieldInfo> GetValidFields(Type type, bool staticFields, bool includePrivate = INCLUDE_PRIVATE)
		{
			BindingFlags flag = (staticFields ? BindingFlags.Static: BindingFlags.Instance);
			List<FieldInfo> validFields = new List<FieldInfo>();
			FilterFields(validFields, type, BindingFlags.Public | flag);
			if(includePrivate)
			{
				FilterFields(validFields, type, BindingFlags.NonPublic | flag);
			}
			return validFields;
		}

		private static void FilterFields(List<FieldInfo> validFields, Type type, BindingFlags flags)
		{
			FieldInfo[] fields = type.GetFields(flags);
			for(int x = 0; x < fields.Length; x++)
			{
				FieldInfo field = fields[x];
				if(IsFieldValid(field))
				{
					validFields.Add(field);
				}
			}
		}

		private static bool IsFieldValid(FieldInfo field)
		{
			return (field.FieldType.IsEnum || VALID_TYPES.Contains(field.FieldType)) && !field.IsInitOnly && !field.IsLiteral;
		}

		private static object Get(Type type, string key, object defaultValue)
		{
			if(type.IsEnum)
			{
				return GetInt(key, (int)defaultValue);
			}
			else if(type == typeof(string))
			{
				return GetString(key, (string)defaultValue);
			}
			else if(type == typeof(int))
			{
				return GetInt(key, (int)defaultValue);
			}
			else if(type == typeof(float))
			{
				return GetFloat(key, (float)defaultValue);
			}
			else if(type == typeof(bool))
			{
				return GetBool(key, (bool)defaultValue);
			}
			return defaultValue;
		}

		private static void Set(Type type, string key, object value)
		{
			if(type.IsEnum)
			{
				SetInt(key, value.GetHashCode());
			}
			else if(type == typeof(string))
			{
				SetString(key, (string)value);
			}
			else if(type == typeof(int))
			{
				SetInt(key, (int)value);
			}
			else if(type == typeof(float))
			{
				SetFloat(key, (float)value);
			}
			else if(type == typeof(bool))
			{
				SetBool(key, (bool)value);
			}
		}
		#endregion

		#region Basic
		public static bool GetBool(string key, bool defaultValue = false)
		{
			if(EditorPrefs.HasKey(key))
			{
				return EditorPrefs.GetBool(key);
			}
			else
			{
				return defaultValue;
			}
		}

		public static void SetBool(string key, bool value)
		{
			EditorPrefs.SetBool(key, value);
		}

		public static string GetString(string key, string defaultValue = "")
		{
			if(EditorPrefs.HasKey(key))
			{
				return EditorPrefs.GetString(key);
			}
			else
			{
				return defaultValue;
			}
		}

		public static void SetString(string key, string value)
		{
			EditorPrefs.SetString(key, value);
		}

		public static float GetFloat(string key, float defaultValue = 0f)
		{
			if(EditorPrefs.HasKey(key))
			{
				return EditorPrefs.GetFloat(key);
			}
			else
			{
				return defaultValue;
			}
		}

		public static void SetFloat(string key, float value)
		{
			EditorPrefs.SetFloat(key, value);
		}

		public static int GetInt(string key, int defaultValue = 0)
		{
			if(EditorPrefs.HasKey(key))
			{
				return EditorPrefs.GetInt(key);
			}
			else
			{
				return defaultValue;
			}
		}

		public static void SetInt(string key, int value)
		{
			EditorPrefs.SetInt(key, value);
		}
		#endregion
	}
}
