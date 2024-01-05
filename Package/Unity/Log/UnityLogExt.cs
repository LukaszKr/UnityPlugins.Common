using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using ProceduralLevel.Common.Logic;
using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public static class UnityLogExt
	{
		private static readonly MethodInfo m_LogInfo;
		private static readonly MethodInfo m_LogWarning;
		private static readonly MethodInfo m_LogError;

		private static readonly int m_AssetPathLength;

		static UnityLogExt()
		{
			string assetPath = Application.dataPath;
			//Remove Asset
			assetPath = assetPath.Substring(0, assetPath.Length - 6);
			m_AssetPathLength = assetPath.Length;

			Type debugType = typeof(UnityEngine.Debug);

			m_LogInfo = debugType.GetMethod("LogInformation", BindingFlags.NonPublic | BindingFlags.Static);
			m_LogWarning = debugType.GetMethod("LogCompilerWarning", BindingFlags.NonPublic | BindingFlags.Static);
			m_LogError = debugType.GetMethod("LogCompilerError", BindingFlags.NonPublic | BindingFlags.Static);
		}

		public static void Log(string msg, Type cutoffPoint, ELogType logType, EUnityLogMode mode = EUnityLogMode.All)
		{
			if(cutoffPoint == null)
			{
				cutoffPoint = typeof(UnityLogExt);
			}

			StringBuilder message = new StringBuilder($"{msg}");
			StackTrace stack = new StackTrace(true);
			int frameCount = stack.FrameCount;
			bool foundEntry = false;
			bool foundCutoffPoint = (cutoffPoint == null);
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
					if(fileName == null)
					{
						fileName = string.Empty;
					}
					fileName = fileName.Replace('\\', '/');
					int lineNumber = frame.GetFileLineNumber();
					if(string.IsNullOrEmpty(fileName))
					{
						continue;
					}

					message.AppendLine();
					message.Append($"{method.DeclaringType.FullName}:{method.Name} ()");
					message.Append($" (at <a href=\"{fileName}\" line=\"{lineNumber}\">");
					if(fileName.Length > m_AssetPathLength)
					{
						fileName = fileName.Remove(0, m_AssetPathLength);
					}
					message.Append($"{fileName}:{lineNumber}</a>)");
				}
			}

			string formattedMessage = message.ToString();

			object[] args = new object[] { formattedMessage, entryFileName, entryLine, entryColumn };

			switch(logType)
			{
				case ELogType.Info:
					m_LogInfo.Invoke(null, args);
					break;
				case ELogType.Warning:
					m_LogWarning.Invoke(null, args);
					break;
				case ELogType.Error:
					m_LogError.Invoke(null, args);
					break;
			}
		}
	}
}
