using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Editor
{
	public static class SerializationHelper
	{
		public static List<FieldInfo> GetSerializableFields(Type type)
		{
			FieldInfo[] publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
			FieldInfo[] privateFields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			List<FieldInfo> fields = new List<FieldInfo>(publicFields.Length);

			for(int x = 0; x < publicFields.Length; ++x)
			{
				FieldInfo field = publicFields[x];
				if(field.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length == 0)
				{
					fields.Add(field);
				}
			}

			for(int x = 0; x < privateFields.Length; ++x)
			{
				FieldInfo field = privateFields[x];
				if(field.GetCustomAttributes(typeof(SerializableAttribute), true).Length == 0)
				{
					fields.Add(field);
				}
			}

			return fields;
		}
	}
}
