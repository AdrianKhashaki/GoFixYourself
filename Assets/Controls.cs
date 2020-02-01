// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Action Maps"",
            ""id"": ""54c4b5f1-e2dd-4074-9d81-65fad21dc5d8"",
            ""actions"": [
                {
                    ""name"": ""Red"",
                    ""type"": ""Button"",
                    ""id"": ""a3ab77ae-eeb9-4acc-b462-a4d6ddf0354f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Blue"",
                    ""type"": ""Button"",
                    ""id"": ""285636c1-8e4e-4d3e-8d0a-336262acc0f8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Yellow"",
                    ""type"": ""Button"",
                    ""id"": ""39b591f6-d527-4264-927e-bbae6f407176"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Green"",
                    ""type"": ""Button"",
                    ""id"": ""cb403061-ccbf-4ba7-822d-bb0a0608844c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01a818b8-4c8b-44e1-ba93-ff9196596980"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c5ecf7e-c15a-4ea5-8af4-9919bdf7c2b0"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Red"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04256a3a-d8db-4504-89c7-5d4b3a98ec7e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""048ca61c-ffc1-4822-8fbc-16f694bf4ef8"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Blue"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1d26923-4be2-4b5c-b3a3-7be6af950554"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Yellow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ca821a8-b236-49a5-8966-7e6a005e7732"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Yellow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4087605-6f47-49ed-a95e-4cbeae8839eb"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""Green"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d1bf328-9ba3-423b-89e8-7adcb79f0bd6"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Green"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""keyboard"",
            ""bindingGroup"": ""keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Action Maps
        m_ActionMaps = asset.FindActionMap("Action Maps", throwIfNotFound: true);
        m_ActionMaps_Red = m_ActionMaps.FindAction("Red", throwIfNotFound: true);
        m_ActionMaps_Blue = m_ActionMaps.FindAction("Blue", throwIfNotFound: true);
        m_ActionMaps_Yellow = m_ActionMaps.FindAction("Yellow", throwIfNotFound: true);
        m_ActionMaps_Green = m_ActionMaps.FindAction("Green", throwIfNotFound: true);
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

    // Action Maps
    private readonly InputActionMap m_ActionMaps;
    private IActionMapsActions m_ActionMapsActionsCallbackInterface;
    private readonly InputAction m_ActionMaps_Red;
    private readonly InputAction m_ActionMaps_Blue;
    private readonly InputAction m_ActionMaps_Yellow;
    private readonly InputAction m_ActionMaps_Green;
    public struct ActionMapsActions
    {
        private @Controls m_Wrapper;
        public ActionMapsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Red => m_Wrapper.m_ActionMaps_Red;
        public InputAction @Blue => m_Wrapper.m_ActionMaps_Blue;
        public InputAction @Yellow => m_Wrapper.m_ActionMaps_Yellow;
        public InputAction @Green => m_Wrapper.m_ActionMaps_Green;
        public InputActionMap Get() { return m_Wrapper.m_ActionMaps; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapsActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapsActions instance)
        {
            if (m_Wrapper.m_ActionMapsActionsCallbackInterface != null)
            {
                @Red.started -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnRed;
                @Red.performed -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnRed;
                @Red.canceled -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnRed;
                @Blue.started -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnBlue;
                @Blue.performed -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnBlue;
                @Blue.canceled -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnBlue;
                @Yellow.started -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnYellow;
                @Yellow.performed -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnYellow;
                @Yellow.canceled -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnYellow;
                @Green.started -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnGreen;
                @Green.performed -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnGreen;
                @Green.canceled -= m_Wrapper.m_ActionMapsActionsCallbackInterface.OnGreen;
            }
            m_Wrapper.m_ActionMapsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Red.started += instance.OnRed;
                @Red.performed += instance.OnRed;
                @Red.canceled += instance.OnRed;
                @Blue.started += instance.OnBlue;
                @Blue.performed += instance.OnBlue;
                @Blue.canceled += instance.OnBlue;
                @Yellow.started += instance.OnYellow;
                @Yellow.performed += instance.OnYellow;
                @Yellow.canceled += instance.OnYellow;
                @Green.started += instance.OnGreen;
                @Green.performed += instance.OnGreen;
                @Green.canceled += instance.OnGreen;
            }
        }
    }
    public ActionMapsActions @ActionMaps => new ActionMapsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get
        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.FindControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    public interface IActionMapsActions
    {
        void OnRed(InputAction.CallbackContext context);
        void OnBlue(InputAction.CallbackContext context);
        void OnYellow(InputAction.CallbackContext context);
        void OnGreen(InputAction.CallbackContext context);
    }
}
