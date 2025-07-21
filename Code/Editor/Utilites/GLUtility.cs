using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class GLUtility
	{
		private static Material m_Material;

		private static void EnsureMaterial()
		{
			if(m_Material == null)
			{
				m_Material = new Material(Shader.Find("Hidden/Internal-Colored"));
				m_Material.hideFlags = HideFlags.HideAndDontSave;
				//Turn on alpha blending
				m_Material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
				m_Material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				// Turn backface culling off
				m_Material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
				// Turn off depth writes
				m_Material.SetInt("_ZWrite", 0);
			}
		}

		public static void Begin()
		{
			EnsureMaterial();
			m_Material.SetPass(0);
		}
	}
}
