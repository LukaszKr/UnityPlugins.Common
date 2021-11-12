using System;
using ProceduralLevel.UnityPlugins.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public class UnityLogHandler : ALogHandler
	{
		public Color InfoColor = new Color(1.0f, 1.0f, 1.0f);
		public Color WarningColor = new Color(1.0f, 1.0f, 0.6f);
		public Color ErrorColor = new Color(1.0f, 0.6f, 0.6f);

		public readonly string Channel;
		public readonly Type CutoffType = null;
		public bool Callstack = true;

		public UnityLogHandler(string channel = "", bool callstack = true, Type cutoffType = null)
		{
			Channel = channel;
			Callstack = callstack;
			if(cutoffType == null)
			{
				CutoffType = typeof(CustomLogger);
			}
			else
			{
				CutoffType = cutoffType;
			}
		}

		public override void Log(ELogType logType, string message)
		{
			if(Application.isEditor)
			{
				Color unityColor = GetColor(logType);
				string color = ColorUtility.ToHtmlStringRGB(unityColor);
				string channelStr = (string.IsNullOrEmpty(Channel)? "": $"[{Channel}]");
				string formatted = $"<color=#{color}>{channelStr}{message}</color>";

				UnityLogExt.Log(formatted, CutoffType, logType);
			}
			else
			{
				switch(logType)
				{
					case ELogType.Info:
						Debug.Log(message);
						break;
					case ELogType.Warning:
						Debug.LogWarning(message);
						break;
					case ELogType.Error:
						Debug.LogError(message);
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}

		public Color GetColor(ELogType level)
		{
			switch(level)
			{
				case ELogType.Info:
					return InfoColor;
				case ELogType.Warning:
					return WarningColor;
				case ELogType.Error:
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
