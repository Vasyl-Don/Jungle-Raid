using System.Collections;
using Enums;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Triggers
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class BonusTrigger : MonoBehaviour
    {
        private BonusHandler _bonusHandler;
        private AudioManager _audioManager;
        
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Sprite _disabledSprite;
        [SerializeField] private BonusType _bonusType;
        
        private Button _button;
        
        private const float BonusRecoveryTime = 5f;

        private void Start()
        {
            _bonusHandler = BonusHandler.Instance;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ActivateBonus);
            _audioManager = AudioManager.Instance;
        }
        
        private void ActivateBonus()
        {
            StartCoroutine(BonusCoroutine());
        }

        private IEnumerator BonusCoroutine()
        {
            _bonusHandler.ActivateBonus(_bonusType);
            if (!_bonusHandler.IsBonusActive(_bonusType))
            {
                _audioManager.PlaySound(SoundType.NotGetBonus);
                yield break;
            }
            _audioManager.PlaySound(SoundType.GetBonus);
            
            var image = GetComponent<Image>();
            image.sprite = _disabledSprite;
            
            _button.interactable = false;
            yield return new WaitForSeconds(BonusRecoveryTime);
            _bonusHandler.DisActivateBonus(_bonusType);
            _button.interactable = true;
            
            image.sprite = _enabledSprite;
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ActivateBonus);
        }
    }
}