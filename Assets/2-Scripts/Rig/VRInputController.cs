using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class VRInputController : MonoBehaviour
{
    private VRInputActions actions;
    public bool debugging;


    public Vector2 JoystickLeft;
    public Vector2 JoystickRight;
    public bool ThumbPressedLeft;


    private void OnValidate()
    {
        JoystickLeft = Vector3.ClampMagnitude(JoystickLeft, 1);
        JoystickRight = Vector3.ClampMagnitude(JoystickRight, 1);
    }

    private void Awake()
    {
        actions = new VRInputActions();
        actions.Enable();
    }

    private void Update()
    {
        XRHMD hmd = InputSystem.GetDevice<XRHMD>();

       

    }
}
