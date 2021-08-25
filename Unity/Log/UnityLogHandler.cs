using System;
using ProceduralLevel.UnityPlugins.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public class UnityLogHandler : ALogHandler
	{
		public Color DebugColor = new Color(1f, 1f, 1f);
		public Color InfoColor = new Color(0.6f, 0.6f, 1f);
		public Color WarningColor = new Color(1f, 1f, 0.6f);
		public Color ErrorColor = new Color(1f, 0.6f, 0.6f);

		public readonly string Channel;

		public UnityLogHandler(string channel = "")
		{
			Channel = channel;
		}

		public override void Log(ELogLevel level, string message)
		{
			Color unityColor = GetColor(level);
			string color = ColorUtility.ToHtmlStringRGB(unityColor);
			string channelStr = (string.IsNullOrEmpty(Channel)? "": $"[{Channel}]");
			string formatted = $"<color=#{color}>{channelStr}{message}</color>";

			switch(level)
			{
				case ELogLevel.Info:
				case ELogLevel.Debug:
					UnityLogExt.LogInfo(formatted, typeof(UnityLogHandler));
					break;
				case ELogLevel.Warning:
					UnityLogExt.LogWarning(formatted, typeof(UnityLogHandler));
					break;
				case ELogLevel.Error:
					UnityLogExt.LogError(formatted, typeof(UnityLogHandler));
					break;
			}
		}

		public Color GetColor(ELogLevel level)
		{
			switch(level)
			{
				case ELogLevel.Debug:
					return DebugColor;
				case ELogLevel.Info:
					return InfoColor;
				case ELogLevel.Warning:
					return WarningColor;
				case ELogLevel.Error:
					return ErrorColor;
				default:
					throw new NotImplementedException();
			}
		}

		public override void Log(Exception e)
		{
			Debug.LogException(e);
		}
	}
}
