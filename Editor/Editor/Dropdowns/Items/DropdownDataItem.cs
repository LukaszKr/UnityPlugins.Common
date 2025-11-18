using UnityEditor.IMGUI.Controls;

namespace UnityPlugins.Common.Editor
{
	public class DropdownDataItem<T> : AdvancedDropdownItem
	{
		public readonly T Value;

		public DropdownDataItem(string name, T value)
			: base(name)
		{
			Value = value;
		}
	}
}
