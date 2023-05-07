using Services.Events;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Logics.Movements
{
    public class CatMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private int _currentIndex;

        private IGameEvents _gameEvents;
        private MovePoints _movePoints;

        [Inject]
        private void Construction(IGameEvents gameEvents, MovePoints movePoints)
        {
            _gameEvents = gameEvents;
            _movePoints = movePoints;

            _gameEvents.PlayerSelectedTrueCube += OnPlayerSelectedTrueCube;
        }

        private void OnPlayerSelectedTrueCube()
        {
            var position = _movePoints.GetMovePoint(_currentIndex, out var isFinish);

            _agent.SetDestination(position);
            ++_currentIndex;
            
        }

        private void OnDestroy()
        {
            _gameEvents.PlayerSelectedTrueCube -= OnPlayerSelectedTrueCube;
        }
    }
}