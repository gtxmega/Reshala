using Data;
using Services.Events;
using Services.PlayerInput;
using UnityEngine;
using Zenject;

namespace Services.Selector
{
    public class CubeSelector : MonoBehaviour
    {
        [SerializeField] private LayerMask _selectedLayers;
        [SerializeField] private float _rayMaxDistance;
        [SerializeField] private Camera _camera;

        private IGameEventsExec _gameEventsExec;
        private InputHandler _inputHandler;

        [Inject]
        private void Construction(IGameEventsExec gameEventsExec, InputHandler inputHandler)
        {
            _gameEventsExec = gameEventsExec;
            _inputHandler = inputHandler;
        }

        private void Update()
        {
            if(_inputHandler.IsEnable && _inputHandler.GetLeftMouseDown())
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out var hitResult, _rayMaxDistance, _selectedLayers))
                {
                    if(hitResult.collider.TryGetComponent<ISelected>(out var selected))
                    {
                        if(hitResult.collider.TryGetComponent<CubeActor>(out var cube))
                        {
                            _gameEventsExec.OnPlayerSelectedCube(cube);
                        }

                        selected.OnSelect();
                    }
                }
            }
        }
    }
}