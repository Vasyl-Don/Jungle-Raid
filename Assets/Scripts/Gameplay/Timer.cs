using System.Collections;
using Enums;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay
{
    [RequireComponent(typeof(TMP_Text))]
    public class Timer : MonoBehaviour
    {
        [SerializeField] private int[] _secondsLeftForEachLevel;
        private int _secondsLeft;
        private TMP_Text _timerText;
        private GameManager _gameManager;

        private void Start()
        {
            _timerText = GetComponent<TMP_Text>();
            _secondsLeft = _secondsLeftForEachLevel[SceneManager.GetActiveScene().buildIndex % 10];
            UpdateTimerText();
            _gameManager = GameManager.Instance;
        }

        public void StartTimer()
        {
            if (_gameManager.GameState == GameState.Playing)
                StartCoroutine(TimerCoroutine());
        }
        
        public void StopTimer()
        {
            StopCoroutine(TimerCoroutine());
        }
        
        private IEnumerator TimerCoroutine()
        {
            while (_secondsLeft > 0)
            {
                if (_secondsLeft <= 5)
                {
                    _timerText.color = Color.red;
                    AudioManager.Instance.PlaySound(SoundType.TimerTick);
                }
                
                UpdateTimerText();
                yield return new WaitForSeconds(1);
                _secondsLeft--;
            }

            if (_gameManager.GameState == GameState.Playing)
            {
                _gameManager.OnLoss();
            }
        }

        private void UpdateTimerText()
        {
            var minutes = _secondsLeft / 60;
            var seconds = _secondsLeft % 60;
            _timerText.text = $"{minutes}:{seconds:00}";
        }
    }
}