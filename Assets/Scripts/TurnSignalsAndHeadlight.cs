using UnityEngine;

public class TurnSignalsAndHeadlight : MonoBehaviour
{
    VRInputActions VRInputActions;
    private float yAxisJoystick;

    [SerializeField] private Light headlight;
    [SerializeField] private Light[] turnLights;
    [SerializeField] private GameObject headlightSwitchObject;
    public GameManager gameManager;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }

    void Update()
    {

        #region Headlight
        //yAxisJoystick = (float)VRInputActions.MotorcycleControls.Headlight.ReadValue<float>();
        //Debug.Log($"Y Axis is {yAxisJoystick}");
        if (VRInputActions.MotorcycleControls.Headlight.ReadValue<float>() > 0.5f)
        {
           headlight.enabled = false;

            headlightSwitchObject.transform.localEulerAngles = new Vector3(206.462f, 112.107f, 25.202f);
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.HeadlightOff);
        }
        else if (VRInputActions.MotorcycleControls.Headlight.ReadValue<float>() < -0.5f)
        {
            headlight.enabled = true;

            headlightSwitchObject.transform.localEulerAngles = new Vector3(206.462f, 112.107f, 55f);
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.HeadlightOn);
        }
        #endregion

        #region TurnSignals
        if (VRInputActions.MotorcycleControls.TurnSignals.ReadValue<float>() > 0.5f)
        {
            //right side lights
            turnLights[0].enabled = false;
            turnLights[1].enabled = false;
            turnLights[2].enabled = true;
            turnLights[3].enabled = true;
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.RightTurnSignal);
        }
        else if (VRInputActions.MotorcycleControls.TurnSignals.ReadValue<float>() < -0.5f)
        {
            //left side lights
            turnLights[0].enabled = true;
            turnLights[1].enabled = true;
            turnLights[2].enabled = false;
            turnLights[3].enabled = false;
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.LeftTurnSignal);
        }
        else if (VRInputActions.MotorcycleControls.TurnSignalsOff.IsPressed())
        {
            for (int i = 0; i < turnLights.Length; i++)
            {
                turnLights[i].enabled = false;
            }
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.TurnSignalOff);
        }
        #endregion

    }


    private void InputActionStep(GameManager.State state, GameManager.Step step)
    {
        if (gameManager.currentState == state)
        {
            if (gameManager.currentStep == step)
            {
                gameManager.stepIsComplete = true;
            }
        }
    }
}
