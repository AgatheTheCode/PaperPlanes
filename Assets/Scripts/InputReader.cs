using UnityEngine;
using UnityEngine.InputSystem;

namespace PaperPlane
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _moveAction;
        private InputAction _fireActionP1;
        private InputAction _fireActionP2;

        public Vector2 Move => _moveAction.ReadValue<Vector2>();
        public bool FireP1 => _fireActionP1.ReadValue<float>() > 0f;
        public bool FireP2 => _fireActionP2.ReadValue<float>() > 0f;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveAction = _playerInput.actions["Move"];
            _fireActionP1 = _playerInput.actions["FireP1"];
            _fireActionP2 = _playerInput.actions["FireP2"];
        }
    }
}