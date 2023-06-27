//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Inputs/GameControls.inputactions
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

public partial class @GameControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""General"",
            ""id"": ""8848b5dd-0a28-47d9-a475-e21b1af24407"",
            ""actions"": [
                {
                    ""name"": ""1"",
                    ""type"": ""Button"",
                    ""id"": ""c46fec7c-2f15-4c38-9c3d-af6560857973"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""2"",
                    ""type"": ""Button"",
                    ""id"": ""8a489a61-cf18-49f7-ad34-4f93375bb6c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=0.01)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""3"",
                    ""type"": ""Button"",
                    ""id"": ""022b97e4-6794-47e9-aecd-9af06988df9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""4"",
                    ""type"": ""Button"",
                    ""id"": ""4330b943-9fa1-436c-8258-6788b1317eec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""T"",
                    ""type"": ""Button"",
                    ""id"": ""0f1fabde-3b6e-433f-997a-56489d42f0b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F12"",
                    ""type"": ""Button"",
                    ""id"": ""b55a481b-ac6b-4ef9-93be-6ea4cf339e1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Y"",
                    ""type"": ""Button"",
                    ""id"": ""8b782697-4cd5-48f8-90e0-b82fb4eae18c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""O"",
                    ""type"": ""Button"",
                    ""id"": ""fb07fb8e-5983-47df-a448-2cfc5dc7f19a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""37d0e2fb-09c9-42c2-beea-fed452bfb43b"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=0.01)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c412eff-e183-418f-a0b0-344d72a1aa7c"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Hold(duration=0.1,pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bb0f687-dafb-4d49-aca6-feb82a91a805"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F12"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33dce55d-3fd1-4d43-809a-03301f20df2a"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""673e8993-a6c7-4889-8bdc-67ee561cd447"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55f1ea3f-fc89-4982-8ba2-d58a91beee70"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""T"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c774e490-3a25-4301-8a85-539d3cb3c14b"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""836e2312-c898-475a-a5bb-0fac07883174"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""O"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""AnotherMap"",
            ""id"": ""be36b981-0b10-4b8e-a575-742d8fb72a87"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""7b64841d-f2f6-469a-89c6-df597f59104c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70c55ad6-3c51-4288-968a-048a757eca3c"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera"",
            ""id"": ""c284fe37-535f-42d0-a2ac-ed5c5d4b0978"",
            ""actions"": [
                {
                    ""name"": ""Movements"",
                    ""type"": ""Value"",
                    ""id"": ""c8d1d456-e18a-409f-9599-3c0d1caa7ffe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9713cf1a-fca2-4080-8d2e-3d8ada61aff7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e59d0f50-755f-4282-b462-6d32379b08f1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a79f936-9539-479b-a565-de97a3a80e42"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3386ef55-5e5a-4541-99c1-e96e03b44548"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bb75a4e2-1939-4ec8-a94d-44407c5a2fdb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General__1 = m_General.FindAction("1", throwIfNotFound: true);
        m_General__2 = m_General.FindAction("2", throwIfNotFound: true);
        m_General__3 = m_General.FindAction("3", throwIfNotFound: true);
        m_General__4 = m_General.FindAction("4", throwIfNotFound: true);
        m_General_T = m_General.FindAction("T", throwIfNotFound: true);
        m_General_F12 = m_General.FindAction("F12", throwIfNotFound: true);
        m_General_Y = m_General.FindAction("Y", throwIfNotFound: true);
        m_General_O = m_General.FindAction("O", throwIfNotFound: true);
        // AnotherMap
        m_AnotherMap = asset.FindActionMap("AnotherMap", throwIfNotFound: true);
        m_AnotherMap_Fire = m_AnotherMap.FindAction("Fire", throwIfNotFound: true);
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_Movements = m_Camera.FindAction("Movements", throwIfNotFound: true);
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

    // General
    private readonly InputActionMap m_General;
    private List<IGeneralActions> m_GeneralActionsCallbackInterfaces = new List<IGeneralActions>();
    private readonly InputAction m_General__1;
    private readonly InputAction m_General__2;
    private readonly InputAction m_General__3;
    private readonly InputAction m_General__4;
    private readonly InputAction m_General_T;
    private readonly InputAction m_General_F12;
    private readonly InputAction m_General_Y;
    private readonly InputAction m_General_O;
    public struct GeneralActions
    {
        private @GameControls m_Wrapper;
        public GeneralActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @_1 => m_Wrapper.m_General__1;
        public InputAction @_2 => m_Wrapper.m_General__2;
        public InputAction @_3 => m_Wrapper.m_General__3;
        public InputAction @_4 => m_Wrapper.m_General__4;
        public InputAction @T => m_Wrapper.m_General_T;
        public InputAction @F12 => m_Wrapper.m_General_F12;
        public InputAction @Y => m_Wrapper.m_General_Y;
        public InputAction @O => m_Wrapper.m_General_O;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void AddCallbacks(IGeneralActions instance)
        {
            if (instance == null || m_Wrapper.m_GeneralActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GeneralActionsCallbackInterfaces.Add(instance);
            @_1.started += instance.On_1;
            @_1.performed += instance.On_1;
            @_1.canceled += instance.On_1;
            @_2.started += instance.On_2;
            @_2.performed += instance.On_2;
            @_2.canceled += instance.On_2;
            @_3.started += instance.On_3;
            @_3.performed += instance.On_3;
            @_3.canceled += instance.On_3;
            @_4.started += instance.On_4;
            @_4.performed += instance.On_4;
            @_4.canceled += instance.On_4;
            @T.started += instance.OnT;
            @T.performed += instance.OnT;
            @T.canceled += instance.OnT;
            @F12.started += instance.OnF12;
            @F12.performed += instance.OnF12;
            @F12.canceled += instance.OnF12;
            @Y.started += instance.OnY;
            @Y.performed += instance.OnY;
            @Y.canceled += instance.OnY;
            @O.started += instance.OnO;
            @O.performed += instance.OnO;
            @O.canceled += instance.OnO;
        }

        private void UnregisterCallbacks(IGeneralActions instance)
        {
            @_1.started -= instance.On_1;
            @_1.performed -= instance.On_1;
            @_1.canceled -= instance.On_1;
            @_2.started -= instance.On_2;
            @_2.performed -= instance.On_2;
            @_2.canceled -= instance.On_2;
            @_3.started -= instance.On_3;
            @_3.performed -= instance.On_3;
            @_3.canceled -= instance.On_3;
            @_4.started -= instance.On_4;
            @_4.performed -= instance.On_4;
            @_4.canceled -= instance.On_4;
            @T.started -= instance.OnT;
            @T.performed -= instance.OnT;
            @T.canceled -= instance.OnT;
            @F12.started -= instance.OnF12;
            @F12.performed -= instance.OnF12;
            @F12.canceled -= instance.OnF12;
            @Y.started -= instance.OnY;
            @Y.performed -= instance.OnY;
            @Y.canceled -= instance.OnY;
            @O.started -= instance.OnO;
            @O.performed -= instance.OnO;
            @O.canceled -= instance.OnO;
        }

        public void RemoveCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGeneralActions instance)
        {
            foreach (var item in m_Wrapper.m_GeneralActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GeneralActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GeneralActions @General => new GeneralActions(this);

    // AnotherMap
    private readonly InputActionMap m_AnotherMap;
    private List<IAnotherMapActions> m_AnotherMapActionsCallbackInterfaces = new List<IAnotherMapActions>();
    private readonly InputAction m_AnotherMap_Fire;
    public struct AnotherMapActions
    {
        private @GameControls m_Wrapper;
        public AnotherMapActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_AnotherMap_Fire;
        public InputActionMap Get() { return m_Wrapper.m_AnotherMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AnotherMapActions set) { return set.Get(); }
        public void AddCallbacks(IAnotherMapActions instance)
        {
            if (instance == null || m_Wrapper.m_AnotherMapActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AnotherMapActionsCallbackInterfaces.Add(instance);
            @Fire.started += instance.OnFire;
            @Fire.performed += instance.OnFire;
            @Fire.canceled += instance.OnFire;
        }

        private void UnregisterCallbacks(IAnotherMapActions instance)
        {
            @Fire.started -= instance.OnFire;
            @Fire.performed -= instance.OnFire;
            @Fire.canceled -= instance.OnFire;
        }

        public void RemoveCallbacks(IAnotherMapActions instance)
        {
            if (m_Wrapper.m_AnotherMapActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAnotherMapActions instance)
        {
            foreach (var item in m_Wrapper.m_AnotherMapActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AnotherMapActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AnotherMapActions @AnotherMap => new AnotherMapActions(this);

    // Camera
    private readonly InputActionMap m_Camera;
    private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();
    private readonly InputAction m_Camera_Movements;
    public struct CameraActions
    {
        private @GameControls m_Wrapper;
        public CameraActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_Camera_Movements;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void AddCallbacks(ICameraActions instance)
        {
            if (instance == null || m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
            @Movements.started += instance.OnMovements;
            @Movements.performed += instance.OnMovements;
            @Movements.canceled += instance.OnMovements;
        }

        private void UnregisterCallbacks(ICameraActions instance)
        {
            @Movements.started -= instance.OnMovements;
            @Movements.performed -= instance.OnMovements;
            @Movements.canceled -= instance.OnMovements;
        }

        public void RemoveCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICameraActions instance)
        {
            foreach (var item in m_Wrapper.m_CameraActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CameraActions @Camera => new CameraActions(this);
    public interface IGeneralActions
    {
        void On_1(InputAction.CallbackContext context);
        void On_2(InputAction.CallbackContext context);
        void On_3(InputAction.CallbackContext context);
        void On_4(InputAction.CallbackContext context);
        void OnT(InputAction.CallbackContext context);
        void OnF12(InputAction.CallbackContext context);
        void OnY(InputAction.CallbackContext context);
        void OnO(InputAction.CallbackContext context);
    }
    public interface IAnotherMapActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
    public interface ICameraActions
    {
        void OnMovements(InputAction.CallbackContext context);
    }
}