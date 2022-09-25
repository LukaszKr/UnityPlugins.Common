using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Editor
{
	public abstract class AExtendedEditor<DataType> : UnityEditor.Editor where DataType : Object
	{
		private bool m_Initialize = false;
		private bool m_Compiling = false;

		public DataType Target => target as DataType;

		protected bool DisableOnCompile = true;
		protected bool DrawDefault  = false;

		public float Width => Screen.width;
		public float Height => Screen.height;

		protected abstract void Initialize();

		protected virtual void OnEnable()
		{
			m_Initialize = false;
		}

		public override void OnInspectorGUI()
		{
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
				m_Initialize = true;
			}

			if(!DisableOnCompile || !EditorApplication.isCompiling)
			{
				if(m_Compiling)
				{
					m_Compiling = false;
					OnCompilationEnd();
				}
				serializedObject.Update();
				EditorGUI.BeginChangeCheck();
				if(DrawDefault)
				{
					base.OnInspectorGUI();
				}
				Draw();

				if(EditorGUI.EndChangeCheck())
				{
					Component comp = target as Component;
					if(comp != null && !Application.isPlaying)
					{
						EditorSceneManager.MarkSceneDirty(comp.gameObject.scene);
						EditorUtility.SetDirty(target);
					}
					ChangesOccured();
				}
				if(serializedObject.targetObject)
				{
					serializedObject.ApplyModifiedProperties();
				}
			}
			else
			{
				DrawCompilationScreen();
			}
		}

		protected virtual void OnCompilationStart() { }
		protected virtual void OnCompilationEnd() { }

		protected abstract void Draw();
		protected virtual void ChangesOccured() { }

		protected virtual void DrawCompilationScreen()
		{
			EditorGUILayout.LabelField("Scripts are compiling, please wait.");
		}
	}
}
