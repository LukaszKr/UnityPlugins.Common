using System.Diagnostics;
using Unity.CodeEditor;

namespace ProceduralLevel.Common.Editor
{
	public static class UnityDebugExt
	{
		public static void OpenFileOnSpecificLineAndColumn(StackFrame frame)
		{
			OpenFileOnSpecificLineAndColumn(frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
		}

		public static void OpenFileOnSpecificLineAndColumn(string filePath, int line, int column)
		{
			CodeEditor.CurrentEditor.OpenProject(filePath, line, column);
		}
	}
}
