using Data;
using Game;
using UnityEngine;

namespace Services.Progress
{
    public class PlayerProgress : MonoBehaviour
    {
        [SerializeField] private LevelsStorage _levelsStorage;

        public ProgressData ProgressData => _progressData;

        private ProgressData _progressData;

        private static PlayerProgress _instance;

        private void Awake()
        {
            if( _instance == null )
            {
                _instance = this;
            }else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }

        public void ClearProgress()
        {
            _progressData.Levels.Clear();
        }

        public void Save()
        {
            _progressData.IsExist = true;

            string dataJson = _progressData.ToJson();

            PlayerPrefs.SetString(GameConstants.SAVE_DATA_KEY, dataJson);

            Debug.Log(dataJson);
        }

        public ProgressData Load()
        {
            if(PlayerPrefs.HasKey(GameConstants.SAVE_DATA_KEY))
            {
                string dataJson = PlayerPrefs.GetString(GameConstants.SAVE_DATA_KEY);

                _progressData = dataJson.ToDesirialize<ProgressData>();
            }else
            {
                _progressData = new ProgressData();
                _progressData.Levels = _levelsStorage.GetAllLevelData();
            }

            return _progressData;
        }
    }
}