//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/VRInputActions.inputactions
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

public partial class @VRInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @VRInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""VRInputActions"",
    ""maps"": [
        {
            ""name"": ""Motorcycle Controls"",
            ""id"": ""bf505325-f42b-4040-8407-4deb3105d717"",
            ""actions"": [
                {
                    ""name"": ""Grab Handle Bars Right"",
                    ""type"": ""Value"",
                    ""id"": ""28d22e18-8ae2-4ebc-9902-bf885ab1cd4a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Grab Handle Bars Left"",
                    ""type"": ""Value"",
                    ""id"": ""cb6ee7e0-90bc-40b1-b7fb-a586a6fcbc90"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Front Brake Grabbing"",
                    ""type"": ""Button"",
                    ""id"": ""8b44e71d-ae4d-4117-bc2f-1581efe6842f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Clutch Grabbing"",
                    ""type"": ""Value"",
                    ""id"": ""763eac74-33cf-4d08-b4e7-50617cee55c5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Fuel Injection"",
                    ""type"": ""Value"",
                    ""id"": ""47fd1a14-a5f4-45f7-a044-bd1461df4a38"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Turn Signals"",
                    ""type"": ""Value"",
                    ""id"": ""403b8080-c4c6-4808-92ef-36017b44d31f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Horn Button"",
                    ""type"": ""Button"",
                    ""id"": ""412e4716-5ae0-4114-9191-7ebe313e5563"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Back Brake Press"",
                    ""type"": ""Button"",
                    ""id"": ""01333e13-96bb-41a4-84a4-6c26d9a6626a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shifter Pedal Up"",
                    ""type"": ""Button"",
                    ""id"": ""cc30a282-7568-4dcd-924c-905434b77dc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shifter Pedal Down"",
                    ""type"": ""Button"",
                    ""id"": ""8d19fd33-d965-4fca-b6a2-efe87e84e26f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Button"",
                    ""id"": ""5623b560-779c-437d-8378-905008ba24e3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Turn Signals Off"",
                    ""type"": ""Button"",
                    ""id"": ""87d4aad7-f6c5-4a0f-8b2a-c9c6583a6093"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Headlight"",
                    ""type"": ""Value"",
                    ""id"": ""5f3e53d6-8a0b-427e-8486-e13b61976490"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Kill Switch"",
                    ""type"": ""Value"",
                    ""id"": ""02ae93e0-add8-4761-ac67-55dfcd3745c0"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Kill Switch Keyboard"",
                    ""type"": ""Button"",
                    ""id"": ""195aaa13-5920-4a93-9888-fbf73729df51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reset Scene"",
                    ""type"": ""Button"",
                    ""id"": ""4b933e4e-7bc5-4e02-9927-8005a23345e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TriggerMenu"",
                    ""type"": ""Button"",
                    ""id"": ""bd18d1f6-613e-4487-bd62-3f6180cc7d8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""9f2daf3c-6bfd-4565-bd85-5398031a5f42"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7b03b731-fd19-4b1f-bbd5-65d368290cd1"",
                    ""path"": ""<OculusTouchController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab Handle Bars Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f48ee7e-8d1f-42b9-b99a-6ec1e8c211bb"",
                    ""path"": ""<OculusTouchController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Front Brake Grabbing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71d9b74e-1fea-4be7-9b49-2046aa24b1ac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Front Brake Grabbing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abd09180-342d-4e42-9cf0-943e18fe23b9"",
                    ""path"": ""<OculusTouchController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clutch Grabbing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c5c41fa-b8ec-46da-ac7d-2b64c22882e0"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Clutch Grabbing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c595ae9-6bed-4578-a732-3f0eac048cf2"",
                    ""path"": ""<OculusTouchController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fuel Injection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b531e875-d320-467e-8294-44b0b5de4121"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fuel Injection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f490bb24-854e-4fe4-85f1-5c5c7a111a73"",
                    ""path"": ""<OculusTouchController>{LeftHand}/thumbstick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Signals"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c60e3bb2-4f84-43ec-912b-8ddbafaeb4a1"",
                    ""path"": ""<OculusTouchController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""323e376a-dd7e-4acc-a0d7-e63946b0fcbf"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horn Button"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be20080d-398b-4064-baa8-3701c962f206"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back Brake Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34771b38-e778-4d1b-b5d2-348dcfd8017e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shifter Pedal Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6420d5e9-f7a9-4eb6-9831-b18d15544d30"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86ed7b2d-c19e-4097-81f6-b8bbd443e164"",
                    ""path"": ""<OculusTouchController>/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c115f10-7612-43b2-8b02-0b49349d16a9"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shifter Pedal Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""142e0877-c204-4ea3-b7ef-884a6dbf274f"",
                    ""path"": ""<OculusTouchController>{LeftHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Signals Off"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf94f89d-1121-4550-8255-3aa36420dcef"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Signals Off"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7a77fa3-8ce2-429a-a39f-660311dc8b9b"",
                    ""path"": ""<OculusTouchController>{LeftHand}/thumbstick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Headlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1724565b-0c60-4d09-a1ae-cb52cecedb09"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Headlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6f43ca2-4808-4dba-90f1-346efeaae0e6"",
                    ""path"": ""<OculusTouchController>{RightHand}/thumbstick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kill Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfa08440-8596-4416-96cf-ae21a9a5f5e2"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kill Switch Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdd55700-22f6-4ba6-a62e-0af70789eb15"",
                    ""path"": ""<OculusTouchController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab Handle Bars Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ece5fc1-7eb8-45a7-aa4f-09c41ecb6a3c"",
                    ""path"": ""<OculusTouchController>{LeftHand}/menu"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset Scene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0aec02a-1cf8-4916-939f-4bc5046a0bf3"",
                    ""path"": ""<OculusTouchController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e1c1fa1-1664-4ca2-aca2-ad12d1850877"",
                    ""path"": ""<OculusTouchController>{LeftHand}/menu"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37d5a7e3-e7d8-4969-a251-669c6ff7930c"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Motorcycle Controls
        m_MotorcycleControls = asset.FindActionMap("Motorcycle Controls", throwIfNotFound: true);
        m_MotorcycleControls_GrabHandleBarsRight = m_MotorcycleControls.FindAction("Grab Handle Bars Right", throwIfNotFound: true);
        m_MotorcycleControls_GrabHandleBarsLeft = m_MotorcycleControls.FindAction("Grab Handle Bars Left", throwIfNotFound: true);
        m_MotorcycleControls_FrontBrakeGrabbing = m_MotorcycleControls.FindAction("Front Brake Grabbing", throwIfNotFound: true);
        m_MotorcycleControls_ClutchGrabbing = m_MotorcycleControls.FindAction("Clutch Grabbing", throwIfNotFound: true);
        m_MotorcycleControls_FuelInjection = m_MotorcycleControls.FindAction("Fuel Injection", throwIfNotFound: true);
        m_MotorcycleControls_TurnSignals = m_MotorcycleControls.FindAction("Turn Signals", throwIfNotFound: true);
        m_MotorcycleControls_HornButton = m_MotorcycleControls.FindAction("Horn Button", throwIfNotFound: true);
        m_MotorcycleControls_BackBrakePress = m_MotorcycleControls.FindAction("Back Brake Press", throwIfNotFound: true);
        m_MotorcycleControls_ShifterPedalUp = m_MotorcycleControls.FindAction("Shifter Pedal Up", throwIfNotFound: true);
        m_MotorcycleControls_ShifterPedalDown = m_MotorcycleControls.FindAction("Shifter Pedal Down", throwIfNotFound: true);
        m_MotorcycleControls_Throttle = m_MotorcycleControls.FindAction("Throttle", throwIfNotFound: true);
        m_MotorcycleControls_TurnSignalsOff = m_MotorcycleControls.FindAction("Turn Signals Off", throwIfNotFound: true);
        m_MotorcycleControls_Headlight = m_MotorcycleControls.FindAction("Headlight", throwIfNotFound: true);
        m_MotorcycleControls_KillSwitch = m_MotorcycleControls.FindAction("Kill Switch", throwIfNotFound: true);
        m_MotorcycleControls_KillSwitchKeyboard = m_MotorcycleControls.FindAction("Kill Switch Keyboard", throwIfNotFound: true);
        m_MotorcycleControls_ResetScene = m_MotorcycleControls.FindAction("Reset Scene", throwIfNotFound: true);
        m_MotorcycleControls_TriggerMenu = m_MotorcycleControls.FindAction("TriggerMenu", throwIfNotFound: true);
        m_MotorcycleControls_MainMenu = m_MotorcycleControls.FindAction("MainMenu", throwIfNotFound: true);
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

    // Motorcycle Controls
    private readonly InputActionMap m_MotorcycleControls;
    private IMotorcycleControlsActions m_MotorcycleControlsActionsCallbackInterface;
    private readonly InputAction m_MotorcycleControls_GrabHandleBarsRight;
    private readonly InputAction m_MotorcycleControls_GrabHandleBarsLeft;
    private readonly InputAction m_MotorcycleControls_FrontBrakeGrabbing;
    private readonly InputAction m_MotorcycleControls_ClutchGrabbing;
    private readonly InputAction m_MotorcycleControls_FuelInjection;
    private readonly InputAction m_MotorcycleControls_TurnSignals;
    private readonly InputAction m_MotorcycleControls_HornButton;
    private readonly InputAction m_MotorcycleControls_BackBrakePress;
    private readonly InputAction m_MotorcycleControls_ShifterPedalUp;
    private readonly InputAction m_MotorcycleControls_ShifterPedalDown;
    private readonly InputAction m_MotorcycleControls_Throttle;
    private readonly InputAction m_MotorcycleControls_TurnSignalsOff;
    private readonly InputAction m_MotorcycleControls_Headlight;
    private readonly InputAction m_MotorcycleControls_KillSwitch;
    private readonly InputAction m_MotorcycleControls_KillSwitchKeyboard;
    private readonly InputAction m_MotorcycleControls_ResetScene;
    private readonly InputAction m_MotorcycleControls_TriggerMenu;
    private readonly InputAction m_MotorcycleControls_MainMenu;
    public struct MotorcycleControlsActions
    {
        private @VRInputActions m_Wrapper;
        public MotorcycleControlsActions(@VRInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @GrabHandleBarsRight => m_Wrapper.m_MotorcycleControls_GrabHandleBarsRight;
        public InputAction @GrabHandleBarsLeft => m_Wrapper.m_MotorcycleControls_GrabHandleBarsLeft;
        public InputAction @FrontBrakeGrabbing => m_Wrapper.m_MotorcycleControls_FrontBrakeGrabbing;
        public InputAction @ClutchGrabbing => m_Wrapper.m_MotorcycleControls_ClutchGrabbing;
        public InputAction @FuelInjection => m_Wrapper.m_MotorcycleControls_FuelInjection;
        public InputAction @TurnSignals => m_Wrapper.m_MotorcycleControls_TurnSignals;
        public InputAction @HornButton => m_Wrapper.m_MotorcycleControls_HornButton;
        public InputAction @BackBrakePress => m_Wrapper.m_MotorcycleControls_BackBrakePress;
        public InputAction @ShifterPedalUp => m_Wrapper.m_MotorcycleControls_ShifterPedalUp;
        public InputAction @ShifterPedalDown => m_Wrapper.m_MotorcycleControls_ShifterPedalDown;
        public InputAction @Throttle => m_Wrapper.m_MotorcycleControls_Throttle;
        public InputAction @TurnSignalsOff => m_Wrapper.m_MotorcycleControls_TurnSignalsOff;
        public InputAction @Headlight => m_Wrapper.m_MotorcycleControls_Headlight;
        public InputAction @KillSwitch => m_Wrapper.m_MotorcycleControls_KillSwitch;
        public InputAction @KillSwitchKeyboard => m_Wrapper.m_MotorcycleControls_KillSwitchKeyboard;
        public InputAction @ResetScene => m_Wrapper.m_MotorcycleControls_ResetScene;
        public InputAction @TriggerMenu => m_Wrapper.m_MotorcycleControls_TriggerMenu;
        public InputAction @MainMenu => m_Wrapper.m_MotorcycleControls_MainMenu;
        public InputActionMap Get() { return m_Wrapper.m_MotorcycleControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MotorcycleControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMotorcycleControlsActions instance)
        {
            if (m_Wrapper.m_MotorcycleControlsActionsCallbackInterface != null)
            {
                @GrabHandleBarsRight.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnGrabHandleBarsRight;
                @GrabHandleBarsRight.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnGrabHandleBarsRight;
                @GrabHandleBarsRight.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnGrabHandleBarsRight;
                @GrabHandleBarsLeft.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnGrabHandleBarsLeft;
                @GrabHandleBarsLeft.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnGrabHandleBarsLeft;
                @GrabHandleBarsLeft.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnGrabHandleBarsLeft;
                @FrontBrakeGrabbing.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnFrontBrakeGrabbing;
                @FrontBrakeGrabbing.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnFrontBrakeGrabbing;
                @FrontBrakeGrabbing.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnFrontBrakeGrabbing;
                @ClutchGrabbing.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnClutchGrabbing;
                @ClutchGrabbing.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnClutchGrabbing;
                @ClutchGrabbing.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnClutchGrabbing;
                @FuelInjection.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnFuelInjection;
                @FuelInjection.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnFuelInjection;
                @FuelInjection.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnFuelInjection;
                @TurnSignals.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTurnSignals;
                @TurnSignals.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTurnSignals;
                @TurnSignals.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTurnSignals;
                @HornButton.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnHornButton;
                @HornButton.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnHornButton;
                @HornButton.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnHornButton;
                @BackBrakePress.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnBackBrakePress;
                @BackBrakePress.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnBackBrakePress;
                @BackBrakePress.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnBackBrakePress;
                @ShifterPedalUp.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnShifterPedalUp;
                @ShifterPedalUp.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnShifterPedalUp;
                @ShifterPedalUp.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnShifterPedalUp;
                @ShifterPedalDown.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnShifterPedalDown;
                @ShifterPedalDown.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnShifterPedalDown;
                @ShifterPedalDown.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnShifterPedalDown;
                @Throttle.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnThrottle;
                @TurnSignalsOff.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTurnSignalsOff;
                @TurnSignalsOff.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTurnSignalsOff;
                @TurnSignalsOff.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTurnSignalsOff;
                @Headlight.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnHeadlight;
                @Headlight.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnHeadlight;
                @Headlight.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnHeadlight;
                @KillSwitch.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnKillSwitch;
                @KillSwitch.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnKillSwitch;
                @KillSwitch.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnKillSwitch;
                @KillSwitchKeyboard.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnKillSwitchKeyboard;
                @KillSwitchKeyboard.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnKillSwitchKeyboard;
                @KillSwitchKeyboard.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnKillSwitchKeyboard;
                @ResetScene.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnResetScene;
                @ResetScene.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnResetScene;
                @ResetScene.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnResetScene;
                @TriggerMenu.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTriggerMenu;
                @TriggerMenu.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTriggerMenu;
                @TriggerMenu.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnTriggerMenu;
                @MainMenu.started -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnMainMenu;
                @MainMenu.performed -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnMainMenu;
                @MainMenu.canceled -= m_Wrapper.m_MotorcycleControlsActionsCallbackInterface.OnMainMenu;
            }
            m_Wrapper.m_MotorcycleControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GrabHandleBarsRight.started += instance.OnGrabHandleBarsRight;
                @GrabHandleBarsRight.performed += instance.OnGrabHandleBarsRight;
                @GrabHandleBarsRight.canceled += instance.OnGrabHandleBarsRight;
                @GrabHandleBarsLeft.started += instance.OnGrabHandleBarsLeft;
                @GrabHandleBarsLeft.performed += instance.OnGrabHandleBarsLeft;
                @GrabHandleBarsLeft.canceled += instance.OnGrabHandleBarsLeft;
                @FrontBrakeGrabbing.started += instance.OnFrontBrakeGrabbing;
                @FrontBrakeGrabbing.performed += instance.OnFrontBrakeGrabbing;
                @FrontBrakeGrabbing.canceled += instance.OnFrontBrakeGrabbing;
                @ClutchGrabbing.started += instance.OnClutchGrabbing;
                @ClutchGrabbing.performed += instance.OnClutchGrabbing;
                @ClutchGrabbing.canceled += instance.OnClutchGrabbing;
                @FuelInjection.started += instance.OnFuelInjection;
                @FuelInjection.performed += instance.OnFuelInjection;
                @FuelInjection.canceled += instance.OnFuelInjection;
                @TurnSignals.started += instance.OnTurnSignals;
                @TurnSignals.performed += instance.OnTurnSignals;
                @TurnSignals.canceled += instance.OnTurnSignals;
                @HornButton.started += instance.OnHornButton;
                @HornButton.performed += instance.OnHornButton;
                @HornButton.canceled += instance.OnHornButton;
                @BackBrakePress.started += instance.OnBackBrakePress;
                @BackBrakePress.performed += instance.OnBackBrakePress;
                @BackBrakePress.canceled += instance.OnBackBrakePress;
                @ShifterPedalUp.started += instance.OnShifterPedalUp;
                @ShifterPedalUp.performed += instance.OnShifterPedalUp;
                @ShifterPedalUp.canceled += instance.OnShifterPedalUp;
                @ShifterPedalDown.started += instance.OnShifterPedalDown;
                @ShifterPedalDown.performed += instance.OnShifterPedalDown;
                @ShifterPedalDown.canceled += instance.OnShifterPedalDown;
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @TurnSignalsOff.started += instance.OnTurnSignalsOff;
                @TurnSignalsOff.performed += instance.OnTurnSignalsOff;
                @TurnSignalsOff.canceled += instance.OnTurnSignalsOff;
                @Headlight.started += instance.OnHeadlight;
                @Headlight.performed += instance.OnHeadlight;
                @Headlight.canceled += instance.OnHeadlight;
                @KillSwitch.started += instance.OnKillSwitch;
                @KillSwitch.performed += instance.OnKillSwitch;
                @KillSwitch.canceled += instance.OnKillSwitch;
                @KillSwitchKeyboard.started += instance.OnKillSwitchKeyboard;
                @KillSwitchKeyboard.performed += instance.OnKillSwitchKeyboard;
                @KillSwitchKeyboard.canceled += instance.OnKillSwitchKeyboard;
                @ResetScene.started += instance.OnResetScene;
                @ResetScene.performed += instance.OnResetScene;
                @ResetScene.canceled += instance.OnResetScene;
                @TriggerMenu.started += instance.OnTriggerMenu;
                @TriggerMenu.performed += instance.OnTriggerMenu;
                @TriggerMenu.canceled += instance.OnTriggerMenu;
                @MainMenu.started += instance.OnMainMenu;
                @MainMenu.performed += instance.OnMainMenu;
                @MainMenu.canceled += instance.OnMainMenu;
            }
        }
    }
    public MotorcycleControlsActions @MotorcycleControls => new MotorcycleControlsActions(this);
    public interface IMotorcycleControlsActions
    {
        void OnGrabHandleBarsRight(InputAction.CallbackContext context);
        void OnGrabHandleBarsLeft(InputAction.CallbackContext context);
        void OnFrontBrakeGrabbing(InputAction.CallbackContext context);
        void OnClutchGrabbing(InputAction.CallbackContext context);
        void OnFuelInjection(InputAction.CallbackContext context);
        void OnTurnSignals(InputAction.CallbackContext context);
        void OnHornButton(InputAction.CallbackContext context);
        void OnBackBrakePress(InputAction.CallbackContext context);
        void OnShifterPedalUp(InputAction.CallbackContext context);
        void OnShifterPedalDown(InputAction.CallbackContext context);
        void OnThrottle(InputAction.CallbackContext context);
        void OnTurnSignalsOff(InputAction.CallbackContext context);
        void OnHeadlight(InputAction.CallbackContext context);
        void OnKillSwitch(InputAction.CallbackContext context);
        void OnKillSwitchKeyboard(InputAction.CallbackContext context);
        void OnResetScene(InputAction.CallbackContext context);
        void OnTriggerMenu(InputAction.CallbackContext context);
        void OnMainMenu(InputAction.CallbackContext context);
    }
}
