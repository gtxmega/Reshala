using Game;
using Zenject;

namespace DI
{
    public class GameInstanceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameInstance = FindObjectOfType<GameInstance>();

            Container
                .Bind<GameInstance>()
                .To<GameInstance>()
                .FromInstance(gameInstance)
                .AsSingle()
                .NonLazy();
        }
    }
}