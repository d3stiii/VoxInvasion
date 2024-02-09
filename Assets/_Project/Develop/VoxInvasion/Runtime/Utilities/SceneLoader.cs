using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace VoxInvasion.Runtime.Utilities
{
    public class SceneLoader
    {
        private readonly CoroutineRunner _coroutineRunner;
        private readonly ThreadService _threadService;

        public SceneLoader(CoroutineRunner coroutineRunner, ThreadService threadService)
        {
            _coroutineRunner = coroutineRunner;
            _threadService = threadService;
        }

        public void Load(string sceneName, Action onLoaded = null) =>
            _threadService.ExecuteInMainThread(() => _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded)));

        private IEnumerator LoadScene(string sceneName, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }

            var loadOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!loadOperation.isDone) yield return null;

            onLoaded?.Invoke();
        }
    }
}