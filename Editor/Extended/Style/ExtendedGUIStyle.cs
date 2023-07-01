using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.Common.Editor
{
	//styles have to be created in OnGUI, to prevent initialization code polluting that place, let's have this!
	public class ExtendedGUIStyle
	{
		private static int _ResetCounter;

		private string m_PrototypeName = null;
		private readonly StyleInitializer m_Initializer = null;
		private GUIStyle m_Style;
		private int m_ResetCounter;

		public GUIStyle Style
		{
			get
			{
				if(m_Style == null || m_ResetCounter != _ResetCounter)
				{
					InitializeStyle();
					m_ResetCounter = _ResetCounter;
				}
				return m_Style;
			}
		}

		public static implicit operator GUIStyle(ExtendedGUIStyle style)
		{
			return style.Style;
		}

		public delegate void StyleInitializer(GUIStyle style);

		static ExtendedGUIStyle()
		{
			AssemblyReloadEvents.afterAssemblyReload += OnAfterAssemblyReloadHandler;
			EditorApplication.playModeStateChanged += OnPlayModeStateChangedHandler;
		}

		public ExtendedGUIStyle(string prototypeName)
		{
			m_PrototypeName = prototypeName;
		}

		public ExtendedGUIStyle(StyleInitializer initializer)
		{
			m_Initializer = initializer;
		}

		public ExtendedGUIStyle(string prototypeName, StyleInitializer initializer)
		{
			m_PrototypeName = prototypeName;
			m_Initializer = initializer;
		}

		private void InitializeStyle()
		{
			if(string.IsNullOrEmpty(m_PrototypeName))
			{
				m_Style = new GUIStyle();
			}
			else
			{
				m_Style = new GUIStyle(m_PrototypeName);
			}

			if(m_Initializer != null)
			{
				m_Initializer(m_Style);
			}
		}

		private static void OnAfterAssemblyReloadHandler()
		{
			ResetAll();
		}

		private static void OnPlayModeStateChangedHandler(PlayModeStateChange change)
		{
			if(change == PlayModeStateChange.EnteredPlayMode || change == PlayModeStateChange.EnteredEditMode)
			{
				ResetAll();
			}
		}


		public void Reset()
		{
			m_Style = null;
		}

		public static void ResetAll()
		{
			++_ResetCounter;
		}
	}
}
