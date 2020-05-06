// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""PlayerInput"",
            ""id"": ""57c96cb1-f509-407b-b146-16800bea6e4c"",
            ""actions"": [
                {
                    ""name"": ""Primary"",
                    ""type"": ""Button"",
                    ""id"": ""472e5af9-95cc-4058-9c80-69b057aae4a6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Secondary"",
                    ""type"": ""Button"",
                    ""id"": ""59c944d9-b255-46f3-bf65-6049bd605dac"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Button"",
                    ""id"": ""540249c7-27e5-4d2d-8b6d-7f4587345c87"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83c1c8f4-5236-4b12-8cf6-284951fda3a0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abe6ed0f-3ee7-46d0-9dd6-1c94b3ebee73"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Secondary"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f532cf77-f5e8-4f81-b3be-e41f356c8fa7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInput
        m_PlayerInput = asset.FindActionMap("PlayerInput", throwIfNotFound: true);
        m_PlayerInput_Primary = m_PlayerInput.FindAction("Primary", throwIfNotFound: true);
        m_PlayerInput_Secondary = m_PlayerInput.FindAction("Secondary", throwIfNotFound: true);
        m_PlayerInput_MousePosition = m_PlayerInput.FindAction("MousePosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerInput
    private readonly InputActionMap m_PlayerInput;
    private IPlayerInputActions m_PlayerInputActionsCallbackInterface;
    private readonly InputAction m_PlayerInput_Primary;
    private readonly InputAction m_PlayerInput_Secondary;
    private readonly InputAction m_PlayerInput_MousePosition;
    public struct PlayerInputActions
    {
        private @Input m_Wrapper;
        public PlayerInputActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Primary => m_Wrapper.m_PlayerInput_Primary;
        public InputAction @Secondary => m_Wrapper.m_PlayerInput_Secondary;
        public InputAction @MousePosition => m_Wrapper.m_PlayerInput_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionsCallbackInterface != null)
            {
                @Primary.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnPrimary;
                @Primary.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnPrimary;
                @Primary.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnPrimary;
                @Secondary.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSecondary;
                @Secondary.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSecondary;
                @Secondary.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnSecondary;
                @MousePosition.started -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PlayerInputActionsCallbackInterface.OnMousePosition;
            }
            m_Wrapper.m_PlayerInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Primary.started += instance.OnPrimary;
                @Primary.performed += instance.OnPrimary;
                @Primary.canceled += instance.OnPrimary;
                @Secondary.started += instance.OnSecondary;
                @Secondary.performed += instance.OnSecondary;
                @Secondary.canceled += instance.OnSecondary;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
            }
        }
    }
    public PlayerInputActions @PlayerInput => new PlayerInputActions(this);
    public interface IPlayerInputActions
    {
        void OnPrimary(InputAction.CallbackContext context);
        void OnSecondary(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}
