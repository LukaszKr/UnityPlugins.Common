using UnityEngine;

namespace ProceduralLevel.Common.Editor
{
	public abstract class AExtendedAttributePropertyDrawer<TAttribute> : AExtendedPropertyDrawer
			where TAttribute : PropertyAttribute, new()
	{
		private TAttribute m_Attribute;

		public TAttribute Attr
		{
			get
			{
				if(m_Attribute == null)
				{
					m_Attribute = (attribute != null ? (TAttribute)attribute : new TAttribute());
				}
				return m_Attribute;
			}
		}
	}
}
