using Services.Events;
using Zenject;

namespace Level.States
{
    public class LevelStartedState : ILevelState
    {
        private readonly IGameEventsExec _gameEventsExec;

        public LevelStartedState(DiContainer container)
        {
            _gameEventsExec = container.Resolve<IGameEventsExec>();
        }

        public void Enter()
        {
            _gameEventsExec.OnGameStarted();
        }

        public void Exit()
        {
            
        }
    }
}