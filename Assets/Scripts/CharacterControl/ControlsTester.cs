using UnityEngine;
using Scripts;
using UnityEngine.InputSystem;

namespace Scripts.CharacterControl
{
    /// <summary>
    /// Place this script anywhere on the scene to test controls
    /// </summary>
    public class ControlsTester : MonoBehaviour
    {
        private Controls _inputActions;

        void Awake()
        {
            _inputActions = new Controls();
            _inputActions.Test.ButtonTest.performed += _ => PerformButtonDown();
            _inputActions.Test.ButtonTest.canceled += _ => PerformButtonUp();
        }

        private void OnEnable() => _inputActions.Enable();

        private void PerformButtonDown()
        {
            Debug.Log($"[Right Joystick(Button)] Button Down");
        }

        private void PerformButtonUp()
        {
            Debug.Log($"Right Joystick(Button)] Button Up ");
        }

        private void TryPerformButtonPress(float context)
        {
            if(context > 0)
                Debug.Log($"[Right Joystick(Button)] Button pressed ({context})");
        }

        private void TryPerformRightJoystickMovement(Vector2 context)
        {
            if (context != Vector2.zero)
                Debug.Log($"[Right joystick(Joystick)] Joystick moving {context}");
        }

        private void TryPerformLeftJoystickMovement(Vector2 context)
        {
            if (context != Vector2.zero)
                Debug.Log($"[Left Joystick] Joystick moving {context}");
        }

        void Update()
        {
            TryPerformButtonPress(_inputActions.Test.ButtonTest.ReadValue<float>());
            TryPerformLeftJoystickMovement(_inputActions.Test.Joystick2.ReadValue<Vector2>());
            TryPerformRightJoystickMovement(_inputActions.Test.JoystickTest.ReadValue<Vector2>());
        }
        
        private void OnDisable() => _inputActions.Disable();
    }

}
