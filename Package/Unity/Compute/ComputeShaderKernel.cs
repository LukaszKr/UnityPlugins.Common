using UnityEngine;

namespace ProceduralLevel.Common.Unity
{
	public readonly struct ComputeShaderKernel
	{
		public readonly ComputeShader Shader;
		public readonly int Kernel;
		public readonly int ThreadGroupX;
		public readonly int ThreadGroupY;
		public readonly int ThreadGroupZ;

		public ComputeShaderKernel(ComputeShader computeShader, string kernelName)
		{
			Shader = computeShader;
			Kernel = computeShader.FindKernel(kernelName);
			uint x, y, z;
			computeShader.GetKernelThreadGroupSizes(Kernel, out x, out y, out z);
			ThreadGroupX = (int)x;
			ThreadGroupY = (int)y;
			ThreadGroupZ = (int)z;
		}

		public void Dispatch(int groupX, int groupY = 1, int groupZ = 1)
		{
			int groupXCount = Mathf.CeilToInt((float)groupX / ThreadGroupX);
			int groupYCount = Mathf.CeilToInt((float)groupY / ThreadGroupY);
			int groupZCount = Mathf.CeilToInt((float)groupZ / ThreadGroupZ);
			Shader.Dispatch(Kernel, groupXCount, groupYCount, groupZCount);
		}
	}
}
