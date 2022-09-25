using System.Collections.Generic;
using System.Reflection;
using ProceduralLevel.UnityPlugins.Common.Editor;
using UnityEditor;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Preferences
{
	public abstract class AEditorPrefs<TPrefs>
		where TPrefs : class, new()
	{
		public static TPrefs Instance;

		public abstract string Prefix { get; }
		public virtual bool SaveStatic => false;
		public virtual bool SavePrivate => false;

		private Vector2 m_Scroll;

		static AEditorPrefs()
		{
			Instance = new TPrefs();
		}

		public AEditorPrefs()
		{
			Load();
		}

		public void BeginChangeCheck()
		{
			EditorGUI.BeginChangeCheck();
		}

		public void EndChangeCheck()
		{
			if(EditorGUI.EndChangeCheck())
			{
				Save();
			}
		}

		#region GUI
		public void PreferencesGUI()
		{
			BeginChangeCheck();
			DisplayFields();
			EndChangeCheck();

			EditorGUILayout.BeginHorizontal();
			if(GUILayout.Button("Clear"))
			{
				Clear();
			}
			EditorGUILayout.EndHorizontal();
		}

		private void DisplayFields()
		{
			m_Scroll = EditorGUILayout.BeginScrollView(m_Scroll);
			if(SaveStatic)
			{
				List<FieldInfo> statics = EditorPrefsHelper.GetValidFields(typeof(TPrefs), true, SavePrivate);
				DisplayFields("Static", statics);
			}
			List<FieldInfo> properties = EditorPrefsHelper.GetValidFields(typeof(TPrefs), false, SavePrivate);
			DisplayFields("Member", properties);
			EditorGUILayout.EndScrollView();
		}

		private void DisplayFields(string header, List<FieldInfo> fields)
		{
			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.LabelField(header, EditorStyles.boldLabel);
			for(int x = 0; x < fields.Count; ++x)
			{
				FieldInfo info = fields[x];
				info.SetValue(this, EditorGUILayoutExt.FieldInfoField(this, new GUIContent(info.Name), info));
			}
			EditorGUILayout.EndVertical();
		}
		#endregion

		public void Clear()
		{
			EditorPrefsHelper.Clear<TPrefs>(Prefix, SaveStatic);
		}

		public void Load()
		{
			if(SaveStatic)
			{
				EditorPrefsHelper.Read<TPrefs>(Prefix);
			}
			EditorPrefsHelper.Read(this as TPrefs, Prefix);
		}

		public void Save()
		{
			if(SaveStatic)
			{
				EditorPrefsHelper.Write<TPrefs>(Prefix);
			}
			EditorPrefsHelper.Write(this as TPrefs, Prefix);
		}
	}
}
