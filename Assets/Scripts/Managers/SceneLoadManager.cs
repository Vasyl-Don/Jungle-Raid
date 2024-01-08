using System.Collections;
using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class SceneLoadManager : Singleton<SceneLoadManager>
    {
        private WindowsManager _windowsManager;
        private AudioManager _audioManager;
        [SerializeField] private Canvas _loadingCanvas;
        [SerializeField] private Slider _loadingBar;


        private const float StartLoading = 0f;
        private const float FinishLoading = 1f;
        private const float LoadingTime = 7.5f;
        private float _timeElapsed;

        private void Start()
        {
            _windowsManager = WindowsManager.Instance;
            _audioManager = AudioManager.Instance;

            StartCoroutine(StartGameCoroutine());
        }

        private void Update()
        {
            if (_loadingCanvas.gameObject.activeSelf)
            {
                _timeElapsed += Time.deltaTime;
                var percentComplete = _timeElapsed / LoadingTime;
                _loadingBar.value = Mathf.Lerp(StartLoading, FinishLoading, percentComplete);
            }
        }

        public void LoadSceneById(int sceneIdToLoad)
        {
            StartCoroutine(LoadSceneCoroutine(sceneIdToLoad));
        }

        private IEnumerator LoadSceneCoroutine(int sceneBuildIndexToLoad)
        {
            _windowsManager.BeforeLoadScene();
            _audioManager.StopMusic();
            var asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndexToLoad);
            _loadingCanvas.gameObject.SetActive(true);

            while (!asyncLoad.isDone)
            {
                yield return new WaitForSeconds(LoadingTime);
            }

            _loadingCanvas.gameObject.SetActive(false);
            _timeElapsed = 0f;
            _audioManager.SetBackgroundMusic(sceneBuildIndexToLoad);
            _windowsManager.AfterLoadScene();
        }

        private IEnumerator StartGameCoroutine()
        {
            _loadingCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(LoadingTime);
            _loadingCanvas.gameObject.SetActive(false);
            _timeElapsed = 0f;
        }
    }
}