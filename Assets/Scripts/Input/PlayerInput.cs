using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputAction primaryAction;
    public InputAction secondaryAction;

    private void Awake ()
    {
        primaryAction.performed += Click;
        secondaryAction.performed += Click;
    }

    private void OnEnable() {
        primaryAction.Enable();
        secondaryAction.Enable();
    }

    private void OnDisable() {
        primaryAction.Disable();
        secondaryAction.Disable();
    }

    private void Click(InputAction.CallbackContext context)
    {
        Debug.Log("Clicou");
    }
}
