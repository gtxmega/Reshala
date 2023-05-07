using Services.Screens;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameScreensInstaller : MonoInstaller
    {
        [SerializeField] private GameScreens _gameScreens;

        public override void InstallBindings()
        {
            Container
                .Bind<GameScreens>()
                .To<GameScreens>()
                .FromInstance(_gameScreens)
                .AsSingle()
                .NonLazy();
        }
    }
}