/// <summary>
/// https://github.com/marijnz/unity-toolbar-extender
/// </summary>

using System;
using UnityEngine;
using UnityEditor;
using System.Reflection;

#if UNITY_2019_1_OR_NEWER
using UnityEngine.UIElements;
#else
using UnityEngine.Experimental.UIElements;
#endif

namespace UnityPlugins.Common.Editor
{
	public static class ToolbarCallback
	{
		private static Type m_ToolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");
		static Type m_GUIViewType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GUIView");
#if UNITY_2020_1_OR_NEWER
		private static Type m_WindowBackendType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.IWindowBackend");
		private static PropertyInfo m_WindowBackend = m_GUIViewType.GetProperty("windowBackend",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		private static PropertyInfo m_viewVisualTree = m_WindowBackendType.GetProperty("visualTree",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#else
		private static PropertyInfo m_ViewVisualTree = m_GUIViewType.GetProperty("visualTree",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#endif
		private static FieldInfo m_IMGUIContainerOnGUI = typeof(IMGUIContainer).GetField("m_OnGUIHandler",
			BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
		private static ScriptableObject m_CurrentToolbar;

		/// <summary>
		/// Callback for toolbar OnGUI method.
		/// </summary>
		public static Action OnToolbarGUI;
		public static Action OnToolbarGUILeft;
		public static Action OnToolbarGUIRight;

		static ToolbarCallback()
		{
			EditorApplication.update -= OnUpdate;
			EditorApplication.update += OnUpdate;
		}

		static void OnUpdate()
		{
			// Relying on the fact that toolbar is ScriptableObject and gets deleted when layout changes
			if(m_CurrentToolbar == null)
			{
				// Find toolbar
				UnityEngine.Object[] toolbars = Resources.FindObjectsOfTypeAll(m_ToolbarType);
				m_CurrentToolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;
				if(m_CurrentToolbar != null)
				{
#if UNITY_2021_1_OR_NEWER
					FieldInfo root = m_CurrentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
					object rawRoot = root.GetValue(m_CurrentToolbar);
					VisualElement mRoot = rawRoot as VisualElement;
					RegisterCallback("ToolbarZoneLeftAlign", OnToolbarGUILeft);
					RegisterCallback("ToolbarZoneRightAlign", OnToolbarGUIRight);

					void RegisterCallback(string root, Action cb)
					{
						VisualElement toolbarZone = mRoot.Q(root);

						VisualElement parent = new VisualElement()
						{
							style =
							{
								flexGrow = 1,
								flexDirection = FlexDirection.Row,
							}
						};
						IMGUIContainer container = new IMGUIContainer();
						container.onGUIHandler += () =>
						{
							cb?.Invoke();
						};
						parent.Add(container);
						toolbarZone.Add(parent);
					}
#else
#if UNITY_2020_1_OR_NEWER
					object windowBackend = m_WindowBackend.GetValue(m_CurrentToolbar);

					// Get it's visual tree
					VisualElement visualTree = (VisualElement) m_viewVisualTree.GetValue(windowBackend, null);
#else
					// Get it's visual tree
					var visualTree = (VisualElement) m_ViewVisualTree.GetValue(m_CurrentToolbar, null);
#endif

					// Get first child which 'happens' to be toolbar IMGUIContainer
					IMGUIContainer container = (IMGUIContainer) visualTree[0];

					// (Re)attach handler
					Action handler = (Action) m_IMGUIContainerOnGUI.GetValue(container);
					handler -= OnGUI;
					handler += OnGUI;
					m_IMGUIContainerOnGUI.SetValue(container, handler);

#endif
				}
			}
		}

		static void OnGUI()
		{
			OnToolbarGUI?.Invoke();
		}
	}
}