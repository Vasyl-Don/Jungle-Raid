using Managers;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(TMP_Text))]
    public class CoinsText : MonoBehaviour
    {
        private ProgressManager _progressManager;
        private TMP_Text _coinsText;
        
        private void Start()
        {
            _progressManager = ProgressManager.Instance;
            _coinsText = GetComponent<TMP_Text>();
        }
        
        private void Update()
        {
            _coinsText.text = _progressManager.Coins.ToString();
        }
    }
}