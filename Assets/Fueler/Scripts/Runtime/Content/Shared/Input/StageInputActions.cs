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
                },
                {
                    ""name"": ""RotateShipLeft"",
                    ""type"": ""Value"",
                    ""id"": ""d9da90c9-3d70-4142-a1c0-8018fec48316"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateShipRight"",
                    ""type"": ""Value"",
                    ""id"": ""96aac5cf-fb23-48fb-8a12-fe9aa793db31"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveShipForward"",
                    ""type"": ""Value"",
                    ""id"": ""4c0dd1c3-143e-44ef-ab55-c3d05ab5a30f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""41d9a004-0e66-4c38-a7b6-7f43195be3d8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RestartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""536f7991-5884-4215-a481-6494d01dce3e"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1de18040-7e53-42e2-9e9d-1e4daf7e4ff3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5505408-bdf5-41b9-a793-1e03ad8306e9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35b0dea3-a147-4c5d-8ef1-32ed41d09007"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShipLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a150c6eb-02e0-4445-9728-acd4da8e46b9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45dd418f-2843-4220-bf3c-daea46aa841c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""246a0cd3-1656-46cb-b21d-78509a914384"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateShipRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a32ee76-99d5-410c-bd56-b317e3782196"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveShipForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51433100-f67b-4562-b9d6-8ae4dbdc3226"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveShipForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad1da896-7a9b-48d6-bdb7-e1dcc7b78ed1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveShipForward"",
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
            m_Player_RotateShipLeft = m_Player.FindAction("RotateShipLeft", throwIfNotFound: true);
            m_Player_RotateShipRight = m_Player.FindAction("RotateShipRight", throwIfNotFound: true);
            m_Player_MoveShipForward = m_Player.FindAction("MoveShipForward", throwIfNotFound: true);
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
        private readonly InputAction m_Player_RotateShipLeft;
        private readonly InputAction m_Player_RotateShipRight;
        private readonly InputAction m_Player_MoveShipForward;
        public struct PlayerActions
        {
            private @StageInputActions m_Wrapper;
            public PlayerActions(@StageInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @RestartLevel => m_Wrapper.m_Player_RestartLevel;
            public InputAction @RotateShipLeft => m_Wrapper.m_Player_RotateShipLeft;
            public InputAction @RotateShipRight => m_Wrapper.m_Player_RotateShipRight;
            public InputAction @MoveShipForward => m_Wrapper.m_Player_MoveShipForward;
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
                    @RotateShipLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateShipLeft;
                    @RotateShipLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateShipLeft;
                    @RotateShipLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateShipLeft;
                    @RotateShipRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateShipRight;
                    @RotateShipRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateShipRight;
                    @RotateShipRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateShipRight;
                    @MoveShipForward.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveShipForward;
                    @MoveShipForward.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveShipForward;
                    @MoveShipForward.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveShipForward;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @RestartLevel.started += instance.OnRestartLevel;
                    @RestartLevel.performed += instance.OnRestartLevel;
                    @RestartLevel.canceled += instance.OnRestartLevel;
                    @RotateShipLeft.started += instance.OnRotateShipLeft;
                    @RotateShipLeft.performed += instance.OnRotateShipLeft;
                    @RotateShipLeft.canceled += instance.OnRotateShipLeft;
                    @RotateShipRight.started += instance.OnRotateShipRight;
                    @RotateShipRight.performed += instance.OnRotateShipRight;
                    @RotateShipRight.canceled += instance.OnRotateShipRight;
                    @MoveShipForward.started += instance.OnMoveShipForward;
                    @MoveShipForward.performed += instance.OnMoveShipForward;
                    @MoveShipForward.canceled += instance.OnMoveShipForward;
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
            void OnRotateShipLeft(InputAction.CallbackContext context);
            void OnRotateShipRight(InputAction.CallbackContext context);
            void OnMoveShipForward(InputAction.CallbackContext context);
        }
    }
}
