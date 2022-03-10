// GENERATED AUTOMATICALLY FROM 'Assets/Fueler/Input/StageInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Fueler.Content.Shared.Input
{
    public class @StageInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @StageInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""StageInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f81f8482-916a-4d5a-89c9-9c11792bd760"",
            ""actions"": [
                {
                    ""name"": ""RestartLevel"",
                    ""type"": ""Button"",
                    ""id"": ""f01c69e2-2c8a-4032-bd6e-fb6cbd678f99"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""41d9a004-0e66-4c38-a7b6-7f43195be3d8"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RestartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_RestartLevel = m_Player.FindAction("RestartLevel", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_RestartLevel;
        public struct PlayerActions
        {
            private @StageInputActions m_Wrapper;
            public PlayerActions(@StageInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @RestartLevel => m_Wrapper.m_Player_RestartLevel;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @RestartLevel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestartLevel;
                    @RestartLevel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestartLevel;
                    @RestartLevel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRestartLevel;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @RestartLevel.started += instance.OnRestartLevel;
                    @RestartLevel.performed += instance.OnRestartLevel;
                    @RestartLevel.canceled += instance.OnRestartLevel;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnRestartLevel(InputAction.CallbackContext context);
        }
    }
}
