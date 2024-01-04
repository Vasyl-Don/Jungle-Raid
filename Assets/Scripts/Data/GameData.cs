namespace Data
{
    [System.Serializable]
    public class GameData
    {
        public AudioSettings AudioSettings;
        public int AvailableLevelsCount;
        public int Coins;
        
        public GameData()
        {
            AvailableLevelsCount = 10;
            Coins = 200;
            
            AudioSettings.MusicVolume = 1f;
            AudioSettings.MusicTurnedOn = true;
            AudioSettings.SoundsVolume = 1f;
            AudioSettings.SoundTurnedOn = true;
        }
    }
}