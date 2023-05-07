using Services.Quest;
using UnityEngine;
using Zenject;

namespace DI
{
    public class QuestServiceInstaller : MonoInstaller
    {
        [SerializeField] private QuestsService _questService;

        public override void InstallBindings()
        {
            Container
                .Bind<QuestsService>()
                .To<QuestsService>()
                .FromInstance(_questService)
                .AsSingle()
                .NonLazy();

        }
    }
}