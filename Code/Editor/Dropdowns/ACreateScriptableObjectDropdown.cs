using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	public abstract class ACreateScriptableObjectDropdown<TAsset> : AdvancedDropdown
		where TAsset : ScriptableObject
	{
		private readonly Dictionary<AdvancedDropdownItem, Type> m_Map = new Dictionary<AdvancedDropdownItem, Type>();
		private readonly Dictionary<string, AdvancedDropdownItem> m_Namespaces = new Dictionary<string, AdvancedDropdownItem>();

		public ACreateScriptableObjectDropdown()
			: base(new AdvancedDropdownState())
		{
		}

		protected override AdvancedDropdownItem BuildRoot()
		{
			AdvancedDropdownItem root = new AdvancedDropdownItem("Select Asset");
			foreach(Type validType in GetValidTypes(typeof(TAsset)))
			{
				AdvancedDropdownItem parent;
				string assemblyName = validType.Assembly.GetName().Name;
				if(!m_Namespaces.TryGetValue(assemblyName, out parent))
				{
					parent = new AdvancedDropdownItem(assemblyName);
					root.AddChild(parent);
					m_Namespaces[assemblyName] = parent;
				}
				AdvancedDropdownItem item = new AdvancedDropdownItem(validType.Name);
				parent.AddChild(item);
				m_Map[item] = validType;
			}
			return root;
		}

		protected override void ItemSelected(AdvancedDropdownItem item)
		{
			Type type = m_Map[item];
			CreateSO(type);
		}

		protected virtual void CreateSO(Type assetType)
		{
			ScriptableObject so = ScriptableObject.CreateInstance(assetType);
			string path = EditorAssetsUtility.GetSelectedFolderPath();
			path = $"{path}/{assetType.Name}.asset";
			AssetDatabase.CreateAsset(so, path);
		}

		protected virtual IEnumerable<Type> GetValidTypes(Type type)
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach(Assembly assembly in assemblies)
			{
				Type[] typesToCheck = assembly.GetTypes();
				foreach(Type typeToCheck in typesToCheck)
				{
					if(!typeToCheck.IsClass)
					{
						continue;
					}
					if(typeToCheck.IsAbstract)
					{
						continue;
					}
					if(!type.IsAssignableFrom(typeToCheck))
					{
						continue;
					}

					yield return typeToCheck;
				}
			}
		}
	}
}
