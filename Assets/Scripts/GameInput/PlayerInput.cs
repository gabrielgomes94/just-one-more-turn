using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameInput
{
    public class PlayerInput : MonoBehaviour
    {
        public InputAction primaryAction;
        public InputAction secondaryAction;
        public InputAction mousePosition;
        private Vector3 vectorMousePosition;
        private PrimaryActionHandler primaryActionHandler;

        private void Awake ()
        {
            primaryActionHandler = new PrimaryActionHandler();

            primaryAction.performed += primaryActionClick;
            secondaryAction.performed += secondaryActionClick;
            mousePosition.performed += trackMousePosition;
        }

        private void OnEnable() {
            primaryAction.Enable();
            secondaryAction.Enable();
            mousePosition.Enable();
        }

        private void OnDisable() {
            primaryAction.Disable();
            secondaryAction.Disable();
            mousePosition.Disable();
        }

        private void primaryActionClick(InputAction.CallbackContext context)
        {
            Debug.Log("Clicou com o esquerdo - " + this.vectorMousePosition);
            primaryActionHandler.handle(this.vectorMousePosition);
        }

        private void secondaryActionClick(InputAction.CallbackContext context)
        {
            Debug.Log("Clicou com o direito - " + this.vectorMousePosition);
        }

        private void trackMousePosition(InputAction.CallbackContext context)
        {
            this.vectorMousePosition = context.ReadValue<Vector2>();
        }

    }
}
