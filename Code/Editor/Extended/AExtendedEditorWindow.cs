using UnityEditor;

namespace UnityPlugins.Common.Editor
{
	public abstract class AExtendedEditorWindow : EditorWindow
	{
		private bool m_Initialize = false;
		private bool m_Compiling = false;

		public abstract string Title { get; }

		protected bool DisableOnCompile = true;

		private int m_LastWidth;
		private int m_LastHeight;

		public float Width => position.width;
		public float Height => position.height;

		public void OnEnable()
		{
			m_Initialize = false;
		}

		public void OnDisable()
		{
			if(m_Initialize)
			{
				m_Initialize = false;
				Terminate();
			}
		}

		protected abstract void Initialize();
		protected abstract void Terminate();

		public void OnGUI()
		{
			if(!this)
			{
				return;
			}

			CheckDimensions();

			titleContent.text = Title;

			if(EditorApplication.isCompiling)
			{
				m_Initialize = false;
				if(!m_Compiling)
				{
					m_Compiling = true;
					OnCompilationStart();
				}
			}
			else if(!m_Initialize)
			{
				Initialize();
				OnResize();
				m_Initialize = true;
			}

			if(!DisableOnCompile || !EditorApplication.isCompiling)
			{
				if(m_Compiling)
				{
					m_Compiling = false;
					OnCompilationEnd();
				}
				EditorGUI.BeginChangeCheck();
				Draw();
				if(EditorGUI.EndChangeCheck())
				{
					ChangesOccured();
				}
			}
			else
			{
				DrawCompilationScreen();
			}
		}

		private void CheckDimensions()
		{
			int width = (int)Width;
			int height = (int)Height;
			if(m_LastWidth != width || m_LastHeight != height)
			{
				m_LastWidth = width;
				m_LastHeight = height;
				OnResize();
			}
		}

		protected virtual void OnCompilationStart() { }
		protected virtual void OnCompilationEnd() { }

		protected virtual void OnResize() { }
		protected abstract void Draw();
		protected virtual void ChangesOccured() { }

		protected virtual void DrawCompilationScreen()
		{
			EditorGUILayout.LabelField("Scripts are compiling, please wait.");
		}
	}
}
