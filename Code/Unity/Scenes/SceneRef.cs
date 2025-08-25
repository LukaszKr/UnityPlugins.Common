using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityPlugins.Common.Unity
{
	[Serializable]
	public class SceneRef
	{
		public string Guid;
		public string Name;

		public void Load()
		{
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(Name);
		}

		public void Load(LoadSceneMode sceneMode)
		{
			SceneManager.LoadScene(Name, sceneMode);
		}

		public AsyncOperation LoadAsync()
		{
			return SceneManager.LoadSceneAsync(Name);
		}

		public AsyncOperation LoadAsync(LoadSceneMode sceneMode)
		{
			return SceneManager.LoadSceneAsync(Name, sceneMode);
		}

		public AsyncOperation UnloadAsync()
		{
			return SceneManager.UnloadSceneAsync(Name);
		}
	}
}
