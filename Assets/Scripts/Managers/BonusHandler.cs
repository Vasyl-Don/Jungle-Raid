using System.Linq;
using Enums;
using Gameplay;
using Helpers;
using UnityEngine;

namespace Managers
{
    public class BonusHandler : Singleton<BonusHandler>
    {
        private const float BonusWallsSpeedScale = 0.5f;
        private const float OriginalWallsSpeedScale = 1 / BonusWallsSpeedScale;
        private const float BonusTigerScale = 0.75f;
        private const float OriginalTigerScale = 1f/ BonusTigerScale;

        private const int SlowWallsPrice = 50;
        private const int SmallTigerPrice = 75;
        private const int HarmlessWallsPrice = 100;

        private ProgressManager _progressManager;

        private bool _slowWalls;
        private bool _smallTiger;
        private bool _harmlessWalls;

        private void Start()
        {
            _progressManager = ProgressManager.Instance;
        }

        public void ActivateBonus(BonusType bonusType)
        {
            switch (bonusType)
            {
                case BonusType.SlowWalls:
                    if (_progressManager.Coins < SlowWallsPrice)
                    {
                        Debug.Log("Not enough coins");
                        return;
                    }

                    _slowWalls = true;
                    _progressManager.RemoveCoins(SlowWallsPrice);
                    ChangeWallsSpeedScale(BonusWallsSpeedScale);
                    break;
                case BonusType.SmallTiger:
                    if (_progressManager.Coins < SmallTigerPrice)
                    {
                        Debug.Log("Not enough coins");
                        return;
                    }

                    _smallTiger = true;
                    _progressManager.RemoveCoins(SmallTigerPrice);
                    ChangeTigerScale(BonusTigerScale);
                    break;
                case BonusType.HarmlessWalls:
                    if (_progressManager.Coins < HarmlessWallsPrice)
                    {
                        Debug.Log("Not enough coins");
                        return;
                    }

                    _harmlessWalls = true;
                    _progressManager.RemoveCoins(HarmlessWallsPrice);
                    break;
                default:
                    Debug.LogError($"Bonus type {bonusType} not implemented");
                    break;
            }
        }

        public void DisActivateBonus(BonusType bonusType)
        {
            switch (bonusType)
            {
                case BonusType.SlowWalls:
                    if (!_slowWalls)
                        return;
                    _slowWalls = false;
                    ChangeWallsSpeedScale(OriginalWallsSpeedScale);
                    break;
                case BonusType.SmallTiger:
                    if (!_smallTiger)
                        return;
                    _smallTiger = false;
                    ChangeTigerScale(OriginalTigerScale);
                    break;
                case BonusType.HarmlessWalls:
                    if (!_harmlessWalls)
                        return;
                    _harmlessWalls = false;
                    break;
                default:
                    Debug.LogError($"Bonus type {bonusType} not implemented");
                    break;
            }
        }

        public void DisActivateAllBonuses()
        {
            if (_slowWalls)
                DisActivateBonus(BonusType.SlowWalls);
            if (_smallTiger)
                DisActivateBonus(BonusType.SmallTiger);
            if (_harmlessWalls)
                DisActivateBonus(BonusType.HarmlessWalls);
        }

        private void ChangeWallsSpeedScale(float scale)
        {
            var walls = FindObjectsOfType<Wall>().ToList();
            walls.ForEach(wall => wall.ChangeSpeedScale(scale));
        }

        private void ChangeTigerScale(float scale)
        {
            var tiger = FindObjectOfType<PlayerController>();
            var localScale = tiger.transform.localScale;
            tiger.transform.localScale = new Vector3(scale * localScale.x, scale * localScale.y, 1);
        }

        public bool IsBonusActive(BonusType bonusType)
        {
            switch (bonusType)
            {
                case BonusType.SlowWalls:
                    return _slowWalls;
                case BonusType.SmallTiger:
                    return _smallTiger;
                case BonusType.HarmlessWalls:
                    return _harmlessWalls;
                default:
                    Debug.LogError($"Bonus type {bonusType} not implemented");
                    return false;
            }
        }
    }
}