using System.Reflection;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public abstract class ExtendedAdvancedDropdown : AdvancedDropdown
	{
		private static PropertyInfo m_MinSizeProperty = typeof(AdvancedDropdown).GetProperty("minimumSize", BindingFlags.Instance | BindingFlags.NonPublic);
		private static PropertyInfo m_MaxSizeProperty = typeof(AdvancedDropdown).GetProperty("maximumSize", BindingFlags.Instance | BindingFlags.NonPublic);

		public Vector2 MinSize
		{
			get => (Vector2)m_MinSizeProperty.GetValue(this);
			set => m_MinSizeProperty.SetValue(this, value);
		}

		public Vector2 MaxSize
		{
			get => (Vector2)m_MaxSizeProperty.GetValue(this);
			set => m_MaxSizeProperty.SetValue(this, value);
		}

		protected float MinHeight => 400f;
		protected float MaxHeight => 600f;

		public ExtendedAdvancedDropdown(AdvancedDropdownState state)
			: base(state)
		{
			SetMinHeight(MinHeight);
			SetMaxHeight(MinHeight);
		}

		public void SetWidth(float width)
		{
			SetMinWidth(width);
			SetMaxWidth(width);
		}

		public void SetHeight(float height)
		{
			SetMinHeight(height);
			SetMaxHeight(height);
		}

		public void SetMinWidth(float width)
		{
			Vector2 current = MinSize;
			current.x = width;
			MinSize = current;
		}

		public void SetMinHeight(float height)
		{
			Vector2 current = MinSize;
			current.y = height;
			MinSize = current;
		}

		public void SetMaxWidth(float width)
		{
			Vector2 current = MaxSize;
			current.x = width;
			MaxSize = current;
		}

		public void SetMaxHeight(float height)
		{
			Vector2 current = MaxSize;
			current.y = height;
			MaxSize = current;
		}
	}
}
