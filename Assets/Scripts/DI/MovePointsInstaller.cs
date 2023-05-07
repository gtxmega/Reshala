using Logics.Movements;
using UnityEngine;
using Zenject;

namespace DI
{
    public class MovePointsInstaller : MonoInstaller
    {
        [SerializeField] private MovePoints _movePoints;

        public override void InstallBindings()
        {
            Container
                .Bind<MovePoints>()
                .To<MovePoints>()
                .FromInstance(_movePoints)
                .AsSingle()
                .NonLazy();
        }
    }
}