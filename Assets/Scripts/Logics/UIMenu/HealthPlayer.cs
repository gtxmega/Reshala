using Services.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Logics.UIMenu
{
    public class HealthPlayer : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;
        [SerializeField] private int _heartCount;

        private IGameEvents _gameEvents;
        private IGameEventsExec _eventsExec;



        [Inject]
        private void Construction(IGameEvents gameEvents, IGameEventsExec eventsExec)
        {
            _gameEvents = gameEvents;
            _eventsExec = eventsExec;

            _gameEvents.PlayerSelectedFalseCube += OnPlayerSelectedFalseCube;
        }

        private void OnPlayerSelectedFalseCube()
        {
            --_heartCount;

            if((_heartCount + 1) == 0 ) 
            {
                _eventsExec.OnLevelLose();
            }else
            {
                ShowHeart();
            }
        }

        public void ShowHeart()
        {
            for (int i = 0; i < _hearts.Length; ++i)
            {
                _hearts[i].gameObject.SetActive(false);
            }

            for (int i = 0; i <= _heartCount; ++i)
            {
                _hearts[i].gameObject.SetActive(true);
            }
        }

        private void OnDestroy()
        {
            _gameEvents.PlayerSelectedFalseCube -= OnPlayerSelectedFalseCube;
        }
    }
}