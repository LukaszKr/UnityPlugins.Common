using System;
using System.Threading.Tasks;
using UnityEngine;

namespace ProceduralLevel.UnityPlugins.Common.MultiThreading
{
	public static class ThreadHelper
	{
		#region Thread
		private static readonly Task[] m_TaskBuffer;
		#endregion

		static ThreadHelper()
		{
			m_TaskBuffer = new Task[Math.Max(1, SystemInfo.processorCount)];
		}

		public static void RunAndWaitAll(Action action)
		{
			int taskCount = m_TaskBuffer.Length;
			if(taskCount == 1)
			{
				action();
				return;
			}

			for(int x = 0; x < taskCount; ++x)
			{
				m_TaskBuffer[x] = Task.Run(action);
			}
			Task.WaitAll(m_TaskBuffer);
			for(int x = 0; x < taskCount; ++x)
			{
				m_TaskBuffer[x].Dispose();
				m_TaskBuffer[x] = null;
			}
		}
	}
}
