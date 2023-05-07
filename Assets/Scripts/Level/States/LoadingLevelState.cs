using Services.Events;
using UnityEngine;
using Zenject;

namespace Level.States
{
    public class LoadingLevelState : ILevelState
    {
        private readonly IGameEventsExec _gameEventsExec;

        public LoadingLevelState(DiContainer container)
        {
            _gameEventsExec = container.Resolve<IGameEventsExec>();
        }

        public void Enter()
        {
            _gameEventsExec.OnLevelLoaded();
        }

        public void Exit()
        {
            
        }
    }
}