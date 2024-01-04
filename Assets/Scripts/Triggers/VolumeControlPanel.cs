using Enums;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Triggers
{
    public class VolumeControlPanel : MonoBehaviour
    {
        private AudioManager _audioManager;

        [SerializeField] private AudioClipType _audioClipType;

        [SerializeField] private Image _turnOffOnButtonImage;
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Sprite _disabledSprite;

        private void Awake()
        {
            _audioManager = AudioManager.Instance;
        }

        private void Start()
        {
            UpdateUI();
        }

        public void DoTurnOffOnVolume()
        {
            _audioManager.PlaySound(SoundType.ButtonClick);
            _audioManager.TurnOffOnVolume(_audioClipType);
            UpdateUI();
        }

        private void UpdateUI()
        {
            var audioEnabled = true;
            switch (_audioClipType)
            {
                case AudioClipType.Music:
                    audioEnabled = _audioManager.MusicTurnedOn;
                    break;
                case AudioClipType.Sound:
                    audioEnabled = _audioManager.SoundTurnedOn;
                    break;
                case AudioClipType.None:
                    Debug.LogWarning("_audioClipType is None.");
                    break;
                default:
                    Debug.LogWarning("Something wrong with the _audioClipType in VolumeControlPanel.");
                    break;
            }

            UpdateSprite(audioEnabled);
        }

        private void UpdateSprite(bool audioEnabled)
        {
            _turnOffOnButtonImage.sprite = audioEnabled ? _enabledSprite : _disabledSprite;
        }
    }
}