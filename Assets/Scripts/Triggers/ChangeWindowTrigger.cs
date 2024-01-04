using Enums;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Triggers
{
    [RequireComponent(typeof(Button))]
    public class ChangeWindowTrigger : MonoBehaviour
    {
        [SerializeField] private WindowType _windowTypeToShow;
        [SerializeField] private SoundType _soundTypeToPlay;
        
        private WindowsManager _windowsManager;
        private AudioManager _audioManager;

        private void Start()
        {
            _windowsManager = WindowsManager.Instance;
            _audioManager = AudioManager.Instance;
        }

        public void DoChangeWindow()
        {
            _audioManager.PlaySound(SoundType.ButtonClick);
            _audioManager.PlaySound(_soundTypeToPlay);
            _windowsManager.HideLastWindow();
            _windowsManager.ShowWindow(_windowTypeToShow);
        }
    }
}