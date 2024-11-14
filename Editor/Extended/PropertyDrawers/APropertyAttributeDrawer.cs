using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public abstract class APropertyAttributeDrawer<PropertyType> : AExtendedPropertyDrawer
		where PropertyType : PropertyAttribute
	{
		public PropertyType Attribute => attribute as PropertyType;
	}
}
