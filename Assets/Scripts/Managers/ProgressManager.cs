using Data;
using Helpers;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class ProgressManager : Singleton<ProgressManager>, IDataPersistence
    {
        public int Coins { get; private set; }
        public int AvailableLevelsCount { get; private set; }

        public void LoadData(GameData data)
        {
            Coins = data.Coins;
            AvailableLevelsCount = data.AvailableLevelsCount;
        }

        public void SaveData(GameData data)
        {
            data.Coins = Coins;
            data.AvailableLevelsCount = AvailableLevelsCount;
        }
        
        public void AddCoins(int amount)
        {
            Coins += amount;
        }

        public void RemoveCoins(int amount)
        {
            Coins -= amount;
        }

        public void UnlockNextLevel()
        {
            if (SceneManager.GetActiveScene().buildIndex == AvailableLevelsCount)
                AvailableLevelsCount++;
        }
    }
}