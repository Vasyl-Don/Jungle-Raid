using System.Collections.Generic;
using Enums;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Custom Containers/Level Background Music Container", fileName = "Background Music")]
    public class LevelBackgroundMusicContainer : ScriptableObject
    {
        public List<LevelBackgroundMusicModel> LevelBackgroundMusic;
    }
}