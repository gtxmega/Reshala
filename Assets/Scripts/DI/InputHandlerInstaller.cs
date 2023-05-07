using Services.PlayerInput;
using UnityEngine;
using Zenject;

namespace DI
{
    public class InputHandlerInstaller : MonoInstaller
    {
        [SerializeField] private InputHandler _inputHandler;

        public override void InstallBindings()
        {
            Container
                .Bind<InputHandler>()
                .To<InputHandler>()
                .FromInstance(_inputHandler)
                .AsSingle()
                .NonLazy();
        }
    }
}