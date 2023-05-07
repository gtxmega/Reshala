using UnityEngine;

namespace Services.PlayerInput
{
    public class InputHandler : MonoBehaviour
    {
        public bool IsEnable => _isEnable;

        private bool _isEnable = true;

        public void EnableInput() => _isEnable = true;
        public void DisableInput() => _isEnable = false;

        public bool GetLeftMouseDown() => Input.GetMouseButtonDown(0);
    }
}