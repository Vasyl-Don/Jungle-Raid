using Enums;
using Gameplay;
using Helpers;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private WindowsManager _windowsManager;
        private ProgressManager _progressManager;
        private AudioManager _audioManager;
        private BonusHandler _bonusHandler;
        
        public GameState GameState { get; private set; }
        
        private Timer _timer;
        
        private void Start()
        {
            _windowsManager = WindowsManager.Instance;
            _progressManager = ProgressManager.Instance;
            _audioManager = AudioManager.Instance;
            _bonusHandler = BonusHandler.Instance;
        }

        public void OnStartPlaying()
        {
            GameState = GameState.Playing;
            _timer = FindObjectOfType<Timer>();
            _timer.StartTimer();
        }

        public void OnWin(int reward)
        {
            GameState = GameState.Won;
            _bonusHandler.DisActivateAllBonuses();
            _timer.StopTimer();
            _windowsManager.ShowWindow(WindowType.WinScreen);
            _progressManager.AddCoins(reward);
            _progressManager.UnlockNextLevel();
            _audioManager.StopMusic();
            _audioManager.PlaySound(SoundType.Win);
        }
        
        public void OnLoss()
        {
            GameState = GameState.Lost;
            _bonusHandler.DisActivateAllBonuses();
            _timer.StopTimer();
            _windowsManager.ShowWindow(WindowType.DeathScreen);
            _audioManager.StopMusic();
            _audioManager.PlaySound(SoundType.Loss);
        }
    }
}