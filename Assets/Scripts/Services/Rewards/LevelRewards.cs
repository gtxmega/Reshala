using DI;
using Services.Events;
using Services.Progress;
using Services.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Services.Rewards
{
    [System.Serializable]
    public struct StarsRewards
    {
        public int MinMissPlayCount;
        public int StarsCount;
    }

    public class LevelRewards : MonoBehaviour
    {
        [SerializeField] private StarsRewards[] _rewards;

        private int _countFalse;

        private IGameEvents _gameEvents;
        private GameScreens _gameScreens;
        private PlayerProgress _playerProgress;

        [Inject]
        private void Construction(IGameEvents gameEvents, GameScreens gameScreens, PlayerProgress playerProgress)
        {
            _gameEvents = gameEvents;
            _gameScreens = gameScreens;
            _playerProgress = playerProgress;

            _gameEvents.LevelWin += OnLevelWin;
            _gameEvents.PlayerSelectedFalseCube += OnPlayerSelectedFalseCube;
        }

        private void OnPlayerSelectedFalseCube()
        {
            ++_countFalse;
        }

        private void OnLevelWin()
        {
            int countStars = 0;
            for (int i = 0; i < _rewards.Length; ++i)
            {
                if (_countFalse <= _rewards[i].MinMissPlayCount)
                {
                    countStars = _rewards[i].StarsCount;
                    break;
                }

            }

            _playerProgress.ProgressData.UnlockLevel(SceneManager.GetActiveScene().buildIndex + 1);
            _playerProgress.Save();

            _gameScreens.ShowWinScreen(countStars);
        }

        private void OnDestroy()
        {
            _gameEvents.LevelWin -= OnLevelWin;
            _gameEvents.PlayerSelectedFalseCube -= OnPlayerSelectedFalseCube;
        }
    }
}