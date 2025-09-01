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
		private readonly Dictionary<string, AdvancedDropdownItem> m_LabelCategories = new Dictionary<string, AdvancedDropdownItem>();

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
				dataItem.icon = (Texture2D)AssetDatabase.GetCachedIcon(path);
				string[] labels = AssetDatabase.GetLabels(new GUID(guid));
				if(labels.Length > 0)
				{
					foreach(string label in labels)
					{
						GetCategory(root, label).AddChild(dataItem);
					}
				}
				else
				{
					root.AddChild(dataItem);
				}
			}
			return root;
		}

		protected override void ItemSelected(AdvancedDropdownItem item)
		{
			DropdownDataItem<string> dataItem = (DropdownDataItem<string>)item;
			GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(dataItem.Value);
			OnPrefabSelected.Invoke(asset);
		}

		private AdvancedDropdownItem GetCategory(AdvancedDropdownItem root, string label)
		{
			AdvancedDropdownItem item;
			if(!m_LabelCategories.TryGetValue(label, out item))
			{
				item = new AdvancedDropdownItem(label);
				m_LabelCategories[label] = item;
				root.AddChild(item);
			}
			return item;
		}
	}
}
