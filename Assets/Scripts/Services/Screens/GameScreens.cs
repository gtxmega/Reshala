using Services.Events;
using Services.PlayerInput;
using Services.Quest;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Services.Screens
{
    public class GameScreens : MonoBehaviour
    {
        [Header("Quest")]
        [SerializeField] private TMP_Text _questText;

        [Header("Screens")]
        [SerializeField] private GameObject _trueCubeScreenObject;
        [SerializeField] private GameObject _falseCubeScreenObject;
        [SerializeField] private GameObject _winScreen;
        [SerializeField] private GameObject _loseScreen;
        [SerializeField] private GameObject[] _stars;

        [Header("Timers")]
        [SerializeField] private float _showTrueCubeScreenTime;
        [SerializeField] private float _showFalseCubeScreenTime;

        private IGameEvents _gameEvents;
        private InputHandler _inputHandler;
        private QuestsService _questsService;

        [Inject]
        private void Construction(IGameEvents gameEvents, InputHandler inputHandler, QuestsService questsService)
        {
            _gameEvents = gameEvents;
            _inputHandler = inputHandler;
            _questsService = questsService;

            _gameEvents.LevelLoaded += OnLevelLoaded;
            _gameEvents.LevelLose += OnLevelLose;
            _gameEvents.PlayerSelectedTrueCube += OnPlayerSelectedTrueCube;
            _gameEvents.PlayerSelectedFalseCube += OnPlayerSelectedFalseCube;
        }

        private void OnLevelLose()
        {
            ShoLoseScreen();
        }

        private void OnLevelLoaded()
        {
            UpdateQuestText();
        }

        public void ShowWinScreen(int starsCount)
        {
            for (int i = 0; i <= starsCount - 1; ++i)
            {
                _stars[i].SetActive(true);
            }

            _winScreen.SetActive(true);
        }

        public void ShoLoseScreen()
        {
            _loseScreen.SetActive(true);
        }

        private void OnPlayerSelectedFalseCube()
        {
            _inputHandler.DisableInput();
            StartCoroutine(ShowScreen(_falseCubeScreenObject, _showFalseCubeScreenTime));
        }

        private void OnPlayerSelectedTrueCube()
        {
            _inputHandler.DisableInput();
            StartCoroutine(ShowScreen(_trueCubeScreenObject, _showTrueCubeScreenTime));
        }

        private IEnumerator ShowScreen(GameObject screenObject, float timer)
        {
            screenObject.SetActive(true);

            yield return new WaitForSeconds(timer);

            UpdateQuestText();

            screenObject.SetActive(false);
            _inputHandler.EnableInput();
        }

        private void UpdateQuestText()
        {
            _questText.text = _questsService.GetCurretQuestText();
        }

        private void OnDestroy()
        {
            _gameEvents.LevelLoaded -= OnLevelLoaded;
            _gameEvents.PlayerSelectedTrueCube -= OnPlayerSelectedTrueCube;
            _gameEvents.PlayerSelectedFalseCube -= OnPlayerSelectedFalseCube;
        }
    }
}