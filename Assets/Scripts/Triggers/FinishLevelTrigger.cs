using Enums;
using Managers;
using UnityEngine;

namespace Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public class FinishLevelTrigger : MonoBehaviour
    {
        private GameManager _gameManager;
        [SerializeField] private int _reward;
        
        private void Start()
        {
            _gameManager = GameManager.Instance;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_gameManager.GameState == GameState.Lost) return;
            _gameManager.OnWin(_reward);
        }
    }
}