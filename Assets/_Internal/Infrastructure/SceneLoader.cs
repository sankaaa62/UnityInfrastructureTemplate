using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Internal.Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void LoadScene(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadSceneCoroutine(name, onLoaded));
        }
        
        private IEnumerator LoadSceneCoroutine(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(name);

            while (!loadOperation.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}