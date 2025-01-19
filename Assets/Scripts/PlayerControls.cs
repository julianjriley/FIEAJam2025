//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""569141ae-c5ff-434d-9818-7a41c7cec1b9"",
            ""actions"": [
                {
                    ""name"": ""Player1"",
                    ""type"": ""Button"",
                    ""id"": ""20809128-4dfa-440e-994a-7070bcdbb5bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Player2"",
                    ""type"": ""Button"",
                    ""id"": ""2c7f5d28-22ef-470a-bf3d-c137b88ea938"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Player3"",
                    ""type"": ""Button"",
                    ""id"": ""844e02f9-c7f3-4ba1-b021-3e834a6e7abd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Player4"",
                    ""type"": ""Button"",
                    ""id"": ""fc5caa1c-28fc-41dd-aeda-8ae5d4154263"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap,Hold"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""34394026-1f57-4c67-b574-c740e2ade1bb"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1784fa3-ed5f-4158-9cb7-cbcd88102412"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""849d2c6f-34b8-45eb-af62-d7f7a52e47c0"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01e33957-2c91-41cb-9d46-0241b61126cd"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Player4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Player1 = m_Player.FindAction("Player1", throwIfNotFound: true);
        m_Player_Player2 = m_Player.FindAction("Player2", throwIfNotFound: true);
        m_Player_Player3 = m_Player.FindAction("Player3", throwIfNotFound: true);
        m_Player_Player4 = m_Player.FindAction("Player4", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_Player1;
    private readonly InputAction m_Player_Player2;
    private readonly InputAction m_Player_Player3;
    private readonly InputAction m_Player_Player4;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Player1 => m_Wrapper.m_Player_Player1;
        public InputAction @Player2 => m_Wrapper.m_Player_Player2;
        public InputAction @Player3 => m_Wrapper.m_Player_Player3;
        public InputAction @Player4 => m_Wrapper.m_Player_Player4;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @Player1.started += instance.OnPlayer1;
            @Player1.performed += instance.OnPlayer1;
            @Player1.canceled += instance.OnPlayer1;
            @Player2.started += instance.OnPlayer2;
            @Player2.performed += instance.OnPlayer2;
            @Player2.canceled += instance.OnPlayer2;
            @Player3.started += instance.OnPlayer3;
            @Player3.performed += instance.OnPlayer3;
            @Player3.canceled += instance.OnPlayer3;
            @Player4.started += instance.OnPlayer4;
            @Player4.performed += instance.OnPlayer4;
            @Player4.canceled += instance.OnPlayer4;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @Player1.started -= instance.OnPlayer1;
            @Player1.performed -= instance.OnPlayer1;
            @Player1.canceled -= instance.OnPlayer1;
            @Player2.started -= instance.OnPlayer2;
            @Player2.performed -= instance.OnPlayer2;
            @Player2.canceled -= instance.OnPlayer2;
            @Player3.started -= instance.OnPlayer3;
            @Player3.performed -= instance.OnPlayer3;
            @Player3.canceled -= instance.OnPlayer3;
            @Player4.started -= instance.OnPlayer4;
            @Player4.performed -= instance.OnPlayer4;
            @Player4.canceled -= instance.OnPlayer4;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPlayer1(InputAction.CallbackContext context);
        void OnPlayer2(InputAction.CallbackContext context);
        void OnPlayer3(InputAction.CallbackContext context);
        void OnPlayer4(InputAction.CallbackContext context);
    }
}
