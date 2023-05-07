using Level.States;
using System;
using System.Collections.Generic;
using Zenject;

namespace Level
{
    public class LevelStateMachine
    {
        private Dictionary<Type, ILevelState> _states;
        private ILevelState _currentState;

        public LevelStateMachine(DiContainer container)
        {
            _states = new Dictionary<Type, ILevelState>()
            {
                [typeof(LoadingLevelState)] = new LoadingLevelState(container),
                [typeof(LevelStartedState)] = new LevelStartedState(container)
            };
        }

        public void Enter<T>() where T : ILevelState
        {
            if (_states.TryGetValue(typeof(T), out ILevelState state))
            {
                _currentState?.Exit();
                _currentState = state;
                _currentState.Enter();
            }
        }
    }
}