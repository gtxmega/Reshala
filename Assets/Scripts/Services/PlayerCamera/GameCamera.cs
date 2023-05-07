using Cinemachine;
using Services.Events;
using UnityEngine;
using Zenject;

namespace Services.PlayerCamera
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera;
        [SerializeField] private Animator _animator;

        private int _gameplayID = Animator.StringToHash("Gameplay");
        private int _winID = Animator.StringToHash("WinState");

        private IGameEvents _gameEvents;

        [Inject]
        private void Construction(IGameEvents gameEvents)
        {
            _gameEvents = gameEvents;

            _gameEvents.LevelWin += OnLevelWin;
        }

        private void OnLevelWin()
        {
            _camera.Follow = null;
            _animator.Play(_winID);
        }

        private void OnDestroy()
        {
            _gameEvents.LevelWin -= OnLevelWin;
        }
    }
}