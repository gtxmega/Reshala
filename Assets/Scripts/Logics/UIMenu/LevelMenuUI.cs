using Data;
using Game;
using Services.Progress;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Logics.UIMenu
{
    public class LevelMenuUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _rootWidgets;
        [SerializeField] private LevelItemUI _levelItemPrefab;
        [SerializeField] private Sprite[] _levelSprites;

        private LevelsStorage _levelsStorage;
        private List<LevelSaveData> _allLevels;

        private GameInstance _gameInstance;

        [Inject]
        private void Init(GameInstance gameInstance)
        {
            _gameInstance = gameInstance;
        }

        private void Awake()
        {
            _levelsStorage = FindObjectOfType<LevelsStorage>();
            
            Construction();
        }

        private void Construction()
        {
            _allLevels = _levelsStorage.GetAllLevelData();

            for (int i = 0; i < _allLevels.Count; ++i)
            {
                LevelItemUI widget = Instantiate(_levelItemPrefab, _rootWidgets);

                widget.SetLevelMenuUI(this);
                widget.SetLevelID(_allLevels[i].LevelID);

                widget.SetLevelSprite(_levelSprites[i]);

                if (_allLevels[i].IsUnlock)
                {
                    widget.Unlock();
                }else
                {
                    widget.Lock();
                }
            }
        }

        public void OnSelectLevel(int index)
        {
            int levelID = _allLevels[index].LevelID;
            _gameInstance.SwitchScene(index);
        }
    }
}