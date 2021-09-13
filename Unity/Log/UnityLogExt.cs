using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.Unity
{
	public static class UnityLogExt
	{
		private static readonly MethodInfo m_LogInfo;
		private static readonly MethodInfo m_LogWarning;
		private static readonly MethodInfo m_LogError;

		static UnityLogExt()
		{
			m_LogInfo = typeof(UnityEngine.Debug).GetMethod("LogInfo", BindingFlags.NonPublic | BindingFlags.Static);
			m_LogWarning = typeof(UnityEngine.Debug).GetMethod("LogWarning", BindingFlags.NonPublic | BindingFlags.Static);
			m_LogError = typeof(UnityEngine.Debug).GetMethod("LogError", BindingFlags.NonPublic | BindingFlags.Static);
		}

		public static void LogInfo(string msg, Type cutoffPoint, EUnityLogMode mode = EUnityLogMode.All)
		{
			Log(msg, cutoffPoint, m_LogInfo, mode);
		}

		public static void LogWarning(string msg, Type cutoffPoint, EUnityLogMode mode = EUnityLogMode.All)
		{
			Log(msg, cutoffPoint, m_LogWarning, mode);
		}

		public static void LogError(string msg, Type cutoffPoint, EUnityLogMode mode = EUnityLogMode.All)
		{
			Log(msg, cutoffPoint, m_LogError, mode);
		}

		private static void Log(string msg, Type cutoffPoint, MethodInfo logMethod, EUnityLogMode mode)
		{
			if(cutoffPoint == null)
			{
				cutoffPoint = typeof(UnityLogExt);
			}

			StringBuilder message = new StringBuilder($"{msg}");
			message.AppendLine();
			StackTrace stack = new StackTrace(true);
			int frameCount = stack.FrameCount;
			bool foundEntry = false;
			bool foundCutoffPoint = false;
			bool isCutoffPoint;

			string entryFileName = "";
			int entryLine = 0;
			int entryColumn = 0;

			for(int x = 0; x < frameCount; ++x)
			{
				StackFrame frame = stack.GetFrame(x);
				MethodBase method = frame.GetMethod();
				isCutoffPoint = (method.DeclaringType == cutoffPoint);
				foundCutoffPoint |= isCutoffPoint;
				if(!foundCutoffPoint || isCutoffPoint)
				{
					continue;
				}

				if(!foundEntry)
				{
					foundEntry = true;
					entryFileName = frame.GetFileName();
					entryLine = frame.GetFileLineNumber();
					entryColumn = frame.GetFileColumnNumber();
				}

				if(foundEntry && mode.Contains(EUnityLogMode.Callstack))
				{
					string fileName = frame.GetFileName();
					int lineNumber = frame.GetFileLineNumber();
					if(string.IsNullOrEmpty(fileName))
					{
						continue;
					}

					message.Append($"{method.DeclaringType.Name}:{method.Name}()");
					message.Append($" (at <a href=\"{fileName} line=\"{lineNumber}\">");
					//the first stack message is found now we add the other stack frames to the log
					string shorterFileName = fileName.Remove(0, Application.dataPath.Length - 6); //6 for "Assets"
					message.Append($"{shorterFileName}:{lineNumber}</a>)\n");
				}
			}

			string formattedMessage = message.ToString();
			object[] args = new object[] { formattedMessage, entryFileName, entryLine, entryColumn };
			logMethod.Invoke(null, args);
		}
	}
}
