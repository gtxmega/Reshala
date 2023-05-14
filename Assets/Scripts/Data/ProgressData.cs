using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class LevelSaveData
    {
        public int LevelID;
        public bool IsUnlock;
    }

    [System.Serializable]
    public class ProgressData
    {
        public bool IsExist;
        public List<LevelSaveData> Levels;
        public bool IsVolume = true;

        public ProgressData()
        {
            Levels = new List<LevelSaveData>();
        }

        public void UnlockLevel(int levelID) 
        {
            for (int i = 0; i < Levels.Count; ++i)
            {
                if(Levels[i].LevelID == levelID)
                {
                    Levels[i].IsUnlock = true;
                }
            }
        }
    }
}