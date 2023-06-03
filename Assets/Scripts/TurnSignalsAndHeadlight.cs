using UnityEngine;

public class TurnSignalsAndHeadlight : MonoBehaviour
{
    VRInputActions VRInputActions;
    private float yAxisJoystick;

    [SerializeField] private Light headlight;
    [SerializeField] private Light[] turnLights;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }

    void Update()
    {
        //Headlight
        yAxisJoystick = (float)VRInputActions.MotorcycleControls.Headlight.ReadValue<float>();
        //Debug.Log($"Y Axis is {yAxisJoystick}");
        if (VRInputActions.MotorcycleControls.Headlight.ReadValue<float>() > 0.5f)
        {
           headlight.enabled = false;
        }
        else if (VRInputActions.MotorcycleControls.Headlight.ReadValue<float>() < -0.5f)
        {
            headlight.enabled = true;
        }

        //Turn Signals
        if (VRInputActions.MotorcycleControls.TurnSignals.ReadValue<float>() > 0.5f)
        {
            //right side lights
            turnLights[0].enabled = false;
            turnLights[1].enabled = false;
            turnLights[2].enabled = true;
            turnLights[3].enabled = true;
        }
        else if (VRInputActions.MotorcycleControls.TurnSignals.ReadValue<float>() < -0.5f)
        {
            //left side lights
            turnLights[0].enabled = true;
            turnLights[1].enabled = true;
            turnLights[2].enabled = false;
            turnLights[3].enabled = false;
        }
        else if (VRInputActions.MotorcycleControls.TurnSignalsOff.IsPressed())
        {
            for (int i = 0; i < turnLights.Length; i++)
            {
                turnLights[i].enabled = false;
            }
        }
    }
}
