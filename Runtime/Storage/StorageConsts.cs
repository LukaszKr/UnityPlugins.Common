using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProceduralLevel.UnityPlugins.Common.Storage
{
	public static class StorageConsts
	{
		public static bool InMemory = false;
		public static string BackupSufix = "_backup";

#if UNITY_SWITCH
		public static string MountName = "GameSave";
#endif
	}
}
