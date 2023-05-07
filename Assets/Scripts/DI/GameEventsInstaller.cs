using Services.Events;
using System.Collections;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameEventsInstaller : MonoInstaller
    {
        [SerializeField] private GameEvents _gameEvents;

        public override void InstallBindings()
        {
            Container
                .Bind<IGameEvents>()
                .To<GameEvents>()
                .FromInstance(_gameEvents)
                .NonLazy();

            Container
                .Bind<IGameEventsExec>()
                .To<GameEvents>()
                .FromInstance(_gameEvents)
                .NonLazy();
        }
    }
}