using System;
using System.Collections.Generic;
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
		private readonly Dictionary<Type, AdvancedDropdownItem> m_Groups = new Dictionary<Type, AdvancedDropdownItem>();

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
				AdvancedDropdownItem parent;
				if(!m_Groups.TryGetValue(mainAssetType, out parent))
				{
					parent = new AdvancedDropdownItem(mainAssetType.Name);
					m_Groups[mainAssetType] = parent;
					root.AddChild(parent);
				}
				string fileName = Path.GetFileNameWithoutExtension(path);
				DropdownDataItem<string> dataItem = new DropdownDataItem<string>(fileName, path);
				parent.AddChild(dataItem);
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
