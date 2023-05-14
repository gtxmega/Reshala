using Services.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameInstance : MonoBehaviour
    {
        public PlayerProgress Progress => _playerProgress;

        [SerializeField] private PlayerProgress _playerProgress;

        private static GameInstance _instance;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }else
            {
                Destroy(this);
                return;
            }

            DontDestroyOnLoad(this);

            _playerProgress.Load();
        }

        private void Start()
        {
            SceneManager.LoadScene(GameConstants.MAIN_MENU_SCENE_INDEX);
        }

        public void ChangeSound(bool isActive)
        {

        }

        public void SwitchScene(int index)
        {
            SceneManager.LoadScene(index);
        }


        public void CloseGame()
        {

        }

        private void OnApplicationQuit()
        {
            _playerProgress.Save();
        }
    }
}