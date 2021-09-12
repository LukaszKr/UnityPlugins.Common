using System;
using ProceduralLevel.UnityPlugins.Common.Logic;
using UnityEngine;
using Logger = ProceduralLevel.UnityPlugins.Common.Logic.Logger;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public class UnityLogHandler : ALogHandler
	{
		public Color DebugColor = new Color(1f, 1f, 1f);
		public Color InfoColor = new Color(0.6f, 0.6f, 1f);
		public Color WarningColor = new Color(1f, 1f, 0.6f);
		public Color ErrorColor = new Color(1f, 0.6f, 0.6f);

		public readonly string Channel;
		public readonly Type CutoffType = null;
		public bool Callstack = true;

		public UnityLogHandler(string channel = "", bool callstack = true, Type cutoffType = null)
		{
			Channel = channel;
			Callstack = callstack;
			if(cutoffType == null)
			{
				CutoffType = typeof(Logger);
			}
			else
			{
				CutoffType = cutoffType;
			}
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
					UnityLogExt.LogInfo(formatted, CutoffType);
					break;
				case ELogLevel.Warning:
					UnityLogExt.LogWarning(formatted, CutoffType);
					break;
				case ELogLevel.Error:
					UnityLogExt.LogError(formatted, CutoffType);
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
