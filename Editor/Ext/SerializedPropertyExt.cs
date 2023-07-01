using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ProceduralLevel.Common.Editor
{
	public static class SerializedPropertyExt
	{
		public static bool IsArray(SerializedProperty property)
		{
			return (property != null && property.isArray && property.arrayElementType != "char");
		}

		#region Getter/Setter
		public static object GetPropertyValueRaw(this SerializedProperty property)
		{
			switch(property.propertyType)
			{
				case SerializedPropertyType.Boolean:
					return property.boolValue;
				case SerializedPropertyType.Float:
					return property.floatValue;
				case SerializedPropertyType.Integer:
					return property.intValue;
				case SerializedPropertyType.String:
					return property.stringValue;
				case SerializedPropertyType.Color:
					return property.colorValue;
				case SerializedPropertyType.ObjectReference:
					return property.objectReferenceValue;
				case SerializedPropertyType.Enum:
					return property.intValue;
				case SerializedPropertyType.Vector2:
					return property.vector2Value;
				case SerializedPropertyType.Vector3:
					return property.vector3Value;
				case SerializedPropertyType.Vector4:
					return property.vector4Value;
				case SerializedPropertyType.Vector2Int:
					return property.vector2IntValue;
				case SerializedPropertyType.Vector3Int:
					return property.vector3IntValue;
				case SerializedPropertyType.Rect:
					return property.rectValue;
				case SerializedPropertyType.RectInt:
					return property.rectIntValue;
				case SerializedPropertyType.Bounds:
					return property.boundsValue;
				case SerializedPropertyType.BoundsInt:
					return property.boundsIntValue;
				case SerializedPropertyType.Quaternion:
					return property.quaternionValue;
				case SerializedPropertyType.AnimationCurve:
					return property.animationCurveValue;
				default:
					throw new NotImplementedException(property.propertyType.ToString());
			}
		}

		public static void SetPropertyValueRaw(this SerializedProperty property, object value)
		{
			switch(property.propertyType)
			{
				case SerializedPropertyType.Boolean:
					property.boolValue = (bool)value;
					break;
				case SerializedPropertyType.Float:
					property.floatValue = (float)value;
					break;
				case SerializedPropertyType.Integer:
					property.intValue = (int)value;
					break;
				case SerializedPropertyType.String:
					property.stringValue = (string)value;
					break;
				case SerializedPropertyType.Color:
					property.colorValue = (Color)value;
					break;
				case SerializedPropertyType.ObjectReference:
					property.objectReferenceValue = (Object)value;
					break;
				case SerializedPropertyType.Enum:
					property.intValue = (int)value;
					break;
				case SerializedPropertyType.Vector2:
					property.vector2Value = (Vector2)value;
					break;
				case SerializedPropertyType.Vector3:
					property.vector3Value = (Vector3)value;
					break;
				case SerializedPropertyType.Vector4:
					property.vector4Value = (Vector4)value;
					break;
				case SerializedPropertyType.Vector2Int:
					property.vector2IntValue = (Vector2Int)value;
					break;
				case SerializedPropertyType.Vector3Int:
					property.vector3IntValue = (Vector3Int)value;
					break;
				case SerializedPropertyType.Rect:
					property.rectValue = (Rect)value;
					break;
				case SerializedPropertyType.RectInt:
					property.rectIntValue = (RectInt)value;
					break;
				case SerializedPropertyType.Bounds:
					property.boundsValue = (Bounds)value;
					break;
				case SerializedPropertyType.BoundsInt:
					property.boundsIntValue = (BoundsInt)value;
					break;
				case SerializedPropertyType.Quaternion:
					property.quaternionValue = (Quaternion)value;
					break;
				case SerializedPropertyType.AnimationCurve:
					property.animationCurveValue = (AnimationCurve)value;
					break;
				default:
					throw new NotImplementedException(property.propertyType.ToString());
			}
		}

		public static void SetPropertyDefault(this SerializedProperty property)
		{
			if(property.isArray)
			{
				while(property.arraySize > 0)
				{
					property.DeleteArrayElementAtIndex(0);
				}
			}
			else
			{
				switch(property.propertyType)
				{
					case SerializedPropertyType.Boolean:
						property.boolValue = default;
						break;
					case SerializedPropertyType.Float:
						property.floatValue = default;
						break;
					case SerializedPropertyType.Integer:
						property.intValue = default;
						break;
					case SerializedPropertyType.String:
						property.stringValue = default;
						break;
					case SerializedPropertyType.Color:
						property.colorValue = default;
						break;
					case SerializedPropertyType.ObjectReference:
						property.objectReferenceValue = default;
						break;
					case SerializedPropertyType.Enum:
						property.intValue = default;
						break;
					case SerializedPropertyType.Vector2:
						property.vector2Value = default;
						break;
					case SerializedPropertyType.Vector3:
						property.vector3Value = default;
						break;
					case SerializedPropertyType.Vector4:
						property.vector4Value = default;
						break;
					case SerializedPropertyType.Vector2Int:
						property.vector2IntValue = default;
						break;
					case SerializedPropertyType.Vector3Int:
						property.vector3IntValue = default;
						break;
					case SerializedPropertyType.Rect:
						property.rectValue = default;
						break;
					case SerializedPropertyType.RectInt:
						property.rectIntValue = default;
						break;
					case SerializedPropertyType.Bounds:
						property.boundsValue = default;
						break;
					case SerializedPropertyType.BoundsInt:
						property.boundsIntValue = default;
						break;
					case SerializedPropertyType.Quaternion:
						property.quaternionValue = default;
						break;
					case SerializedPropertyType.AnimationCurve:
						property.animationCurveValue = default;
						break;
					default:
						throw new NotImplementedException(property.propertyPath+":"+property.propertyType.ToString());
				}
			}
		}

		public static TValue GetPropertyValue<TValue>(this SerializedProperty property)
		{
			return (TValue)property.GetPropertyValueRaw();
		}

		public static void SetPropertyValue<TValue>(this SerializedProperty property, TValue value)
		{
			property.SetPropertyValueRaw(value);
		}

		public static Type GetPropertyType(this SerializedProperty property)
		{
			switch(property.propertyType)
			{
				case SerializedPropertyType.Boolean:
					return typeof(bool);
				case SerializedPropertyType.Float:
					return typeof(float);
				case SerializedPropertyType.Integer:
					return typeof(int);
				case SerializedPropertyType.String:
					return typeof(string);
				case SerializedPropertyType.Color:
					return typeof(Color);
				case SerializedPropertyType.ObjectReference:
					return typeof(Object);
				case SerializedPropertyType.Enum:
					return typeof(int);
				case SerializedPropertyType.Vector2:
					return typeof(Vector2);
				case SerializedPropertyType.Vector3:
					return typeof(Vector3);
				case SerializedPropertyType.Vector4:
					return typeof(Vector4);
				case SerializedPropertyType.Vector2Int:
					return typeof(Vector2Int);
				case SerializedPropertyType.Vector3Int:
					return typeof(Vector3Int);
				case SerializedPropertyType.Rect:
					return typeof(Rect);
				case SerializedPropertyType.RectInt:
					return typeof(RectInt);
				case SerializedPropertyType.Bounds:
					return typeof(Bounds);
				case SerializedPropertyType.BoundsInt:
					return typeof(BoundsInt);
				case SerializedPropertyType.Quaternion:
					return typeof(Quaternion);
				case SerializedPropertyType.AnimationCurve:
					return typeof(AnimationCurve);
				default:
					throw new NotImplementedException(property.propertyType.ToString());
			}
		}
		#endregion

		public static string ValueToString(this SerializedProperty property)
		{
			object value = property.GetPropertyValueRaw();
			if(value != null)
			{
				return value.ToString();
			}
			return string.Empty;
		}
	}
}
