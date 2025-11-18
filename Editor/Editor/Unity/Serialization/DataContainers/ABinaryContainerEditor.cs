using UnityEditor;
using UnityEngine;
using UnityPlugins.Common.Logic;
using UnityPlugins.Common.Unity;

namespace UnityPlugins.Common.Editor
{
	public class ABinaryContainerEditor<TContainer, TValue> : AExtendedEditor<TContainer>
		where TContainer : ABinaryContainer<TValue>
		where TValue : class, IBinarySerializable
	{
		protected override void Initialize()
		{
		}

		protected override void Draw()
		{
			DrawInfo();
			DrawAssetControls();
		}

		private void DrawInfo()
		{
			EditorGUILayout.BeginVertical("helpbox");
			{
				EditorGUILayout.LabelField($"Bytes: {Target.RawData.Length}");
			}
			EditorGUILayout.EndVertical();
		}

		private void DrawAssetControls()
		{
			EditorGUILayout.BeginHorizontal("helpbox");
			{
				if(GUILayout.Button("Save"))
				{
					Target.SaveAsset();
				}

				if(GUILayout.Button("Load"))
				{
					Target.Load();
				}
			}
			EditorGUILayout.EndHorizontal();
		}
	}
}
