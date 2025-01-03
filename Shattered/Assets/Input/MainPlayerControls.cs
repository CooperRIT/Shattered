//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/MainPlayerControls.inputactions
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

public partial class @MainPlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainPlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainPlayerControls"",
    ""maps"": [
        {
            ""name"": ""BasicControls"",
            ""id"": ""3f93211d-bb05-4393-8068-dfa5c7e2df7e"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""a9fbb8c3-66ea-4147-8115-1d81826430b4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f0b217ed-3d76-4d7c-a8a4-2fc4ef1c0b5c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextWave"",
                    ""type"": ""Button"",
                    ""id"": ""3b4374ae-4d84-4b20-bdf3-808004cde994"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""5ab9bd54-790e-4076-8b06-600a5839ab31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""8800bbf4-bc0e-4ca8-b9f2-0a650839aa4f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""5528b7d2-5db6-4699-8b25-2a0b95f2a1b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ChangeCamera"",
                    ""type"": ""Button"",
                    ""id"": ""b763d8d2-0602-45e8-9758-2414a60668e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1a9648ae-8ed1-4e9e-b670-8a3b35cae924"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7e479168-8f51-4532-a7ac-cc41f0b090b5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6b589969-ffae-4390-ac46-df495958efcf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d3e38b0-3e88-4e3e-a324-e47b036bade0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ae57eda-6149-4e12-b7f7-0c75fbb20ed0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""785c7c00-5a32-40e1-9e73-43482f102bfa"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""104f22b0-2ab7-47c5-ac8e-07d34e516b1d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4196a373-f2fe-44b2-b4cd-52dff61e7032"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextWave"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c78f468d-a0ea-4de7-92fc-24ced268170a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""020b7fd4-7511-4f02-968a-2a8826bcecaf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3c04026-e39b-441d-a637-bbfe47757f4a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bcf67d7-9b62-432a-b3e7-713740eaed9f"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MouseControls"",
            ""id"": ""7a69f83f-f56d-41df-941d-6e3f76581387"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""f2e21b8e-8c9c-4826-9863-5b1a6285e687"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bc1b8bcd-6991-455f-8bfb-fa1a39bc5440"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlacingControls"",
            ""id"": ""7e38782b-e67d-4464-a195-957b6a7c6b8e"",
            ""actions"": [
                {
                    ""name"": ""ExitPlacingMode"",
                    ""type"": ""Button"",
                    ""id"": ""d488af5e-188a-4a0c-a113-25439966849c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""EnterPlacingMode"",
                    ""type"": ""Button"",
                    ""id"": ""6bad78ed-b2dd-4b25-a6d0-3cd9f99fe05b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PlaceTower"",
                    ""type"": ""Button"",
                    ""id"": ""7b55f93f-ed60-4a9e-ba1b-e8ddcb8a2aa3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3cadf336-788b-4d2f-9e4a-d577305f2c9d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitPlacingMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bff2af28-48ec-4956-a200-a1a388d116b9"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterPlacingMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53acc06f-98b3-49fa-ab46-22be072b272d"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceTower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicControls
        m_BasicControls = asset.FindActionMap("BasicControls", throwIfNotFound: true);
        m_BasicControls_WASD = m_BasicControls.FindAction("WASD", throwIfNotFound: true);
        m_BasicControls_Interact = m_BasicControls.FindAction("Interact", throwIfNotFound: true);
        m_BasicControls_NextWave = m_BasicControls.FindAction("NextWave", throwIfNotFound: true);
        m_BasicControls_Restart = m_BasicControls.FindAction("Restart", throwIfNotFound: true);
        m_BasicControls_Attack = m_BasicControls.FindAction("Attack", throwIfNotFound: true);
        m_BasicControls_Pause = m_BasicControls.FindAction("Pause", throwIfNotFound: true);
        m_BasicControls_ChangeCamera = m_BasicControls.FindAction("ChangeCamera", throwIfNotFound: true);
        // MouseControls
        m_MouseControls = asset.FindActionMap("MouseControls", throwIfNotFound: true);
        m_MouseControls_MousePosition = m_MouseControls.FindAction("MousePosition", throwIfNotFound: true);
        // PlacingControls
        m_PlacingControls = asset.FindActionMap("PlacingControls", throwIfNotFound: true);
        m_PlacingControls_ExitPlacingMode = m_PlacingControls.FindAction("ExitPlacingMode", throwIfNotFound: true);
        m_PlacingControls_EnterPlacingMode = m_PlacingControls.FindAction("EnterPlacingMode", throwIfNotFound: true);
        m_PlacingControls_PlaceTower = m_PlacingControls.FindAction("PlaceTower", throwIfNotFound: true);
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

    // BasicControls
    private readonly InputActionMap m_BasicControls;
    private List<IBasicControlsActions> m_BasicControlsActionsCallbackInterfaces = new List<IBasicControlsActions>();
    private readonly InputAction m_BasicControls_WASD;
    private readonly InputAction m_BasicControls_Interact;
    private readonly InputAction m_BasicControls_NextWave;
    private readonly InputAction m_BasicControls_Restart;
    private readonly InputAction m_BasicControls_Attack;
    private readonly InputAction m_BasicControls_Pause;
    private readonly InputAction m_BasicControls_ChangeCamera;
    public struct BasicControlsActions
    {
        private @MainPlayerControls m_Wrapper;
        public BasicControlsActions(@MainPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_BasicControls_WASD;
        public InputAction @Interact => m_Wrapper.m_BasicControls_Interact;
        public InputAction @NextWave => m_Wrapper.m_BasicControls_NextWave;
        public InputAction @Restart => m_Wrapper.m_BasicControls_Restart;
        public InputAction @Attack => m_Wrapper.m_BasicControls_Attack;
        public InputAction @Pause => m_Wrapper.m_BasicControls_Pause;
        public InputAction @ChangeCamera => m_Wrapper.m_BasicControls_ChangeCamera;
        public InputActionMap Get() { return m_Wrapper.m_BasicControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicControlsActions set) { return set.Get(); }
        public void AddCallbacks(IBasicControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_BasicControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BasicControlsActionsCallbackInterfaces.Add(instance);
            @WASD.started += instance.OnWASD;
            @WASD.performed += instance.OnWASD;
            @WASD.canceled += instance.OnWASD;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @NextWave.started += instance.OnNextWave;
            @NextWave.performed += instance.OnNextWave;
            @NextWave.canceled += instance.OnNextWave;
            @Restart.started += instance.OnRestart;
            @Restart.performed += instance.OnRestart;
            @Restart.canceled += instance.OnRestart;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @ChangeCamera.started += instance.OnChangeCamera;
            @ChangeCamera.performed += instance.OnChangeCamera;
            @ChangeCamera.canceled += instance.OnChangeCamera;
        }

        private void UnregisterCallbacks(IBasicControlsActions instance)
        {
            @WASD.started -= instance.OnWASD;
            @WASD.performed -= instance.OnWASD;
            @WASD.canceled -= instance.OnWASD;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @NextWave.started -= instance.OnNextWave;
            @NextWave.performed -= instance.OnNextWave;
            @NextWave.canceled -= instance.OnNextWave;
            @Restart.started -= instance.OnRestart;
            @Restart.performed -= instance.OnRestart;
            @Restart.canceled -= instance.OnRestart;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @ChangeCamera.started -= instance.OnChangeCamera;
            @ChangeCamera.performed -= instance.OnChangeCamera;
            @ChangeCamera.canceled -= instance.OnChangeCamera;
        }

        public void RemoveCallbacks(IBasicControlsActions instance)
        {
            if (m_Wrapper.m_BasicControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBasicControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_BasicControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BasicControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BasicControlsActions @BasicControls => new BasicControlsActions(this);

    // MouseControls
    private readonly InputActionMap m_MouseControls;
    private List<IMouseControlsActions> m_MouseControlsActionsCallbackInterfaces = new List<IMouseControlsActions>();
    private readonly InputAction m_MouseControls_MousePosition;
    public struct MouseControlsActions
    {
        private @MainPlayerControls m_Wrapper;
        public MouseControlsActions(@MainPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_MouseControls_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_MouseControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseControlsActions set) { return set.Get(); }
        public void AddCallbacks(IMouseControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_MouseControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MouseControlsActionsCallbackInterfaces.Add(instance);
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
        }

        private void UnregisterCallbacks(IMouseControlsActions instance)
        {
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
        }

        public void RemoveCallbacks(IMouseControlsActions instance)
        {
            if (m_Wrapper.m_MouseControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMouseControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_MouseControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MouseControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MouseControlsActions @MouseControls => new MouseControlsActions(this);

    // PlacingControls
    private readonly InputActionMap m_PlacingControls;
    private List<IPlacingControlsActions> m_PlacingControlsActionsCallbackInterfaces = new List<IPlacingControlsActions>();
    private readonly InputAction m_PlacingControls_ExitPlacingMode;
    private readonly InputAction m_PlacingControls_EnterPlacingMode;
    private readonly InputAction m_PlacingControls_PlaceTower;
    public struct PlacingControlsActions
    {
        private @MainPlayerControls m_Wrapper;
        public PlacingControlsActions(@MainPlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ExitPlacingMode => m_Wrapper.m_PlacingControls_ExitPlacingMode;
        public InputAction @EnterPlacingMode => m_Wrapper.m_PlacingControls_EnterPlacingMode;
        public InputAction @PlaceTower => m_Wrapper.m_PlacingControls_PlaceTower;
        public InputActionMap Get() { return m_Wrapper.m_PlacingControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlacingControlsActions set) { return set.Get(); }
        public void AddCallbacks(IPlacingControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlacingControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlacingControlsActionsCallbackInterfaces.Add(instance);
            @ExitPlacingMode.started += instance.OnExitPlacingMode;
            @ExitPlacingMode.performed += instance.OnExitPlacingMode;
            @ExitPlacingMode.canceled += instance.OnExitPlacingMode;
            @EnterPlacingMode.started += instance.OnEnterPlacingMode;
            @EnterPlacingMode.performed += instance.OnEnterPlacingMode;
            @EnterPlacingMode.canceled += instance.OnEnterPlacingMode;
            @PlaceTower.started += instance.OnPlaceTower;
            @PlaceTower.performed += instance.OnPlaceTower;
            @PlaceTower.canceled += instance.OnPlaceTower;
        }

        private void UnregisterCallbacks(IPlacingControlsActions instance)
        {
            @ExitPlacingMode.started -= instance.OnExitPlacingMode;
            @ExitPlacingMode.performed -= instance.OnExitPlacingMode;
            @ExitPlacingMode.canceled -= instance.OnExitPlacingMode;
            @EnterPlacingMode.started -= instance.OnEnterPlacingMode;
            @EnterPlacingMode.performed -= instance.OnEnterPlacingMode;
            @EnterPlacingMode.canceled -= instance.OnEnterPlacingMode;
            @PlaceTower.started -= instance.OnPlaceTower;
            @PlaceTower.performed -= instance.OnPlaceTower;
            @PlaceTower.canceled -= instance.OnPlaceTower;
        }

        public void RemoveCallbacks(IPlacingControlsActions instance)
        {
            if (m_Wrapper.m_PlacingControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlacingControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlacingControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlacingControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlacingControlsActions @PlacingControls => new PlacingControlsActions(this);
    public interface IBasicControlsActions
    {
        void OnWASD(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnNextWave(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnChangeCamera(InputAction.CallbackContext context);
    }
    public interface IMouseControlsActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
    }
    public interface IPlacingControlsActions
    {
        void OnExitPlacingMode(InputAction.CallbackContext context);
        void OnEnterPlacingMode(InputAction.CallbackContext context);
        void OnPlaceTower(InputAction.CallbackContext context);
    }
}
