using Enums;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Triggers
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class LoadSceneTrigger : MonoBehaviour
    {
        [SerializeField] private int _sceneBuildIndexToLoad;
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Sprite _disabledSprite;
        
        private AudioManager _audioManager;
        private SceneLoadManager _sceneLoadManager;
        private ProgressManager _progressManager;

        private void Awake()
        {
            _audioManager = AudioManager.Instance;
            _sceneLoadManager = SceneLoadManager.Instance;
            _progressManager = ProgressManager.Instance;
        }

        private void Start()
        {
            var image = GetComponent<Image>();
            image.sprite = _sceneBuildIndexToLoad > _progressManager.AvailableLevelsCount ? _disabledSprite : _enabledSprite;
        }
        
        public void DoLoadScene()
        {
            _audioManager.PlaySound(SoundType.ButtonClick);

            if (_sceneBuildIndexToLoad > _progressManager.AvailableLevelsCount)
                return;

            // In order to restart level, type -1 instead of build index
            if (_sceneBuildIndexToLoad == -1)
                _sceneBuildIndexToLoad = SceneManager.GetActiveScene().buildIndex;

            // In order to load next level, type -2 instead of build index
            if (_sceneBuildIndexToLoad == -2)
                _sceneBuildIndexToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            
            if (_sceneBuildIndexToLoad >= SceneManager.sceneCountInBuildSettings)
                _sceneBuildIndexToLoad = 0;
            
            _sceneLoadManager.LoadSceneById(_sceneBuildIndexToLoad);
        }
    }
}