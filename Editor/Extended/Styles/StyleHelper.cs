using UnityEditor;
using UnityEngine;

namespace UnityPlugins.Common.Editor
{
	public static class StyleHelper
	{
		public static readonly Color32 TransparentColor = new Color32(0, 0, 0, 255);
		public static readonly Color32 ProSkinColor = new Color32(53, 53, 53, 255);
		public static readonly Color32 FreeSkinColor = new Color32(194, 194, 194, 255);

		public static Color32 SkinColor => (EditorGUIUtility.isProSkin ? ProSkinColor : FreeSkinColor);
		public static float LineHeight => EditorGUIUtility.singleLineHeight;

		public static GUIStyle CreateBackgroundStyle(Texture2D texture)
		{
			GUIStyle style = new GUIStyle("box");
			return CreateBackgroundStyle(style, texture);
		}

		public static GUIStyle CreateBackgroundStyle(GUIStyle style, Texture2D texture)
		{
			style.normal.background = texture;
			return style;
		}

		public static Texture2D CreateFrameTexture(Color32 baseColor, Color32 borderColor, bool margin)
		{
			Texture2D texture = new Texture2D(8, 8, TextureFormat.RGBA32, false);
			for(int x = 0; x != texture.width; ++x)
			{
				for(int y = 0; y != texture.height; ++y)
				{
					if(margin)
					{
						texture.SetPixel(x, y, IsBorder(texture, x, y, false) ? TransparentColor : baseColor);
						texture.SetPixel(x, y, IsBorder(texture, x, y, true) ? borderColor : baseColor);
					}
					else
					{
						texture.SetPixel(x, y, IsBorder(texture, x, y, false) ? borderColor : baseColor);
					}
				}
			}
			texture.Apply();
			return texture;
		}

		private static bool IsBorder(Texture2D texture, int x, int y, bool margin)
		{
			if(margin)
			{
				return (x == 1 || y == 1 || x == texture.width-2 || y == texture.height-2);
			}
			return (x == 0 || y == 0 || x == texture.width-1 || y == texture.height-1);
		}
	}
}
