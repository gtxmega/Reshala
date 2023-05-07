using Services.Progress;
using Zenject;

namespace DI
{
    public class PlayerProgressInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var progress = FindObjectOfType<PlayerProgress>();

            Container
                .Bind<PlayerProgress>()
                .To<PlayerProgress>()
                .FromInstance(progress)
                .AsSingle()
                .NonLazy();
        }
    }
}