// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Grounded"",
            ""id"": ""e8fe549b-c0d9-4d22-b9c8-6b663d7ba912"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f70dbb4a-7799-478d-9529-4bbd53b4db82"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""a093e77f-70dc-4f3a-a180-b59da4874b75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""844675b9-7402-464a-93ed-20472b1af916"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AimDirection"",
                    ""type"": ""Button"",
                    ""id"": ""443dcdd4-8425-431a-9487-94d99ced1380"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""MoveAxis"",
                    ""id"": ""955a6c32-4540-433d-a7de-da754c1e42ca"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a76f930d-46f0-4b19-8223-879dd304ea76"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b12690ba-9215-4920-8cba-eeacc5932504"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0af160c2-cda0-44fe-8b8f-8a9f550403a0"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2eb3fa11-3c17-4f13-bd53-d70eeb90ed3a"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be797f31-aad0-488c-818e-8c702e7065fb"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Grounded
        m_Grounded = asset.FindActionMap("Grounded", throwIfNotFound: true);
        m_Grounded_Move = m_Grounded.FindAction("Move", throwIfNotFound: true);
        m_Grounded_Jump = m_Grounded.FindAction("Jump", throwIfNotFound: true);
        m_Grounded_Aim = m_Grounded.FindAction("Aim", throwIfNotFound: true);
        m_Grounded_AimDirection = m_Grounded.FindAction("AimDirection", throwIfNotFound: true);
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

    // Grounded
    private readonly InputActionMap m_Grounded;
    private IGroundedActions m_GroundedActionsCallbackInterface;
    private readonly InputAction m_Grounded_Move;
    private readonly InputAction m_Grounded_Jump;
    private readonly InputAction m_Grounded_Aim;
    private readonly InputAction m_Grounded_AimDirection;
    public struct GroundedActions
    {
        private @PlayerControls m_Wrapper;
        public GroundedActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Grounded_Move;
        public InputAction @Jump => m_Wrapper.m_Grounded_Jump;
        public InputAction @Aim => m_Wrapper.m_Grounded_Aim;
        public InputAction @AimDirection => m_Wrapper.m_Grounded_AimDirection;
        public InputActionMap Get() { return m_Wrapper.m_Grounded; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GroundedActions set) { return set.Get(); }
        public void SetCallbacks(IGroundedActions instance)
        {
            if (m_Wrapper.m_GroundedActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnJump;
                @Aim.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnAim;
                @AimDirection.started -= m_Wrapper.m_GroundedActionsCallbackInterface.OnAimDirection;
                @AimDirection.performed -= m_Wrapper.m_GroundedActionsCallbackInterface.OnAimDirection;
                @AimDirection.canceled -= m_Wrapper.m_GroundedActionsCallbackInterface.OnAimDirection;
            }
            m_Wrapper.m_GroundedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @AimDirection.started += instance.OnAimDirection;
                @AimDirection.performed += instance.OnAimDirection;
                @AimDirection.canceled += instance.OnAimDirection;
            }
        }
    }
    public GroundedActions @Grounded => new GroundedActions(this);
    public interface IGroundedActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnAimDirection(InputAction.CallbackContext context);
    }
}
