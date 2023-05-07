using Data;
using Game;
using Level.States;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Level
{
    public class LevelInstance : MonoBehaviour
    {
        [Inject] private DiContainer _container;

        private LevelStateMachine _levelStateMachine;
        private GameInstance _gameInstance;

        public void Awake()
        {
            _levelStateMachine = new LevelStateMachine(_container);

            _levelStateMachine.Enter<LoadingLevelState>();

            _gameInstance = _container.Resolve<GameInstance>();
        }

        public void GoMenu()
        {
            SceneManager.LoadScene(GameConstants.MAIN_MENU_SCENE_INDEX);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void NextLevel()
        {
            ProgressData data = _gameInstance.Progress.ProgressData;

            int nextSceneID = SceneManager.GetActiveScene().buildIndex + 1;

            foreach(var item in data.Levels)
            {
                if(item.LevelID == nextSceneID)
                {
                    SceneManager.LoadScene(nextSceneID);
                    return;
                }
            }

            SceneManager.LoadScene(GameConstants.MAIN_MENU_SCENE_INDEX);

        }
    }
}