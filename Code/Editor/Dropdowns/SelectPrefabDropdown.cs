using System;
using System.IO;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityPlugins.Common.Logic;

namespace UnityPlugins.Common.Editor
{
	public class SelectPrefabDropdown : ExtendedAdvancedDropdown
	{
		public readonly CustomEvent<GameObject> OnPrefabSelected = new CustomEvent<GameObject>();

		public SelectPrefabDropdown()
			: base(new AdvancedDropdownState())
		{
		}

		protected override AdvancedDropdownItem BuildRoot()
		{
			AdvancedDropdownItem root = new AdvancedDropdownItem("Select Prefab");
			string[] guids = AssetDatabase.FindAssets("t:GameObject", new string[] { "Assets/" });
			foreach(string guid in guids)
			{
				string path = AssetDatabase.GUIDToAssetPath(guid);
				Type mainAssetType = AssetDatabase.GetMainAssetTypeAtPath(path);
				string fileName = Path.GetFileNameWithoutExtension(path);
				DropdownDataItem<string> dataItem = new DropdownDataItem<string>(fileName, path);
				root.AddChild(dataItem);
			}
			return root;
		}

		protected override void ItemSelected(AdvancedDropdownItem item)
		{
			DropdownDataItem<string> dataItem = (DropdownDataItem<string>)item;
			GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(dataItem.Value);
			OnPrefabSelected.Invoke(asset);
		}
	}
}
