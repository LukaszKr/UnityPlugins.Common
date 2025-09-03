using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	public abstract class ACreateDropdown<TAsset> : ExtendedAdvancedDropdown
	{
		private readonly Dictionary<string, AdvancedDropdownItem> m_Namespaces = new Dictionary<string, AdvancedDropdownItem>();

		public ACreateDropdown()
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
				DropdownDataItem<Type> item = new DropdownDataItem<Type>(validType.Name, validType);
				parent.AddChild(item);
			}
			return root;
		}

		protected override void ItemSelected(AdvancedDropdownItem item)
		{
			Type type = ((DropdownDataItem<Type>)item).Value;
			CreateSelected(type);
		}

		protected abstract void CreateSelected(Type assetType);

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
					if(typeToCheck.IsNestedPrivate)
					{
						continue;
					}

					yield return typeToCheck;
				}
			}
		}
	}
}
