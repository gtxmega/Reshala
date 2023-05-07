using Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.Image;

namespace Services.Progress
{
    public class LevelsStorage : MonoBehaviour
    {
        [SerializeField] private List<LevelSaveData> _levelSaveDatas = new();
        [SerializeField] private PlayerProgress _playerProgress;

        private static LevelsStorage _instance;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

        }

        private void Start()
        {
            OnActiveSceneChanged();
        }

        private void OnActiveSceneChanged()
        {
            if (_playerProgress.ProgressData.IsExist)
            {
                _levelSaveDatas.Clear();

                for (int i = 0; i < _playerProgress.ProgressData.Levels.Count; ++i)
                {
                    _levelSaveDatas.Add(_playerProgress.ProgressData.Levels[i]);
                }
                
            }
        }

        public ref List<LevelSaveData> GetAllLevelData()
        {
            return ref _levelSaveDatas;
        }
    }
}