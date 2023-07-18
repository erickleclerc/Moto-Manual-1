using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class MotorcycleController : MonoBehaviour
{
    /// <summary>
    /// Throttle, Clutch, Brake, Shifting, etc.
    /// </summary>

    VRInputActions VRInputActions;
    private Rigidbody rb;
    public GameManager gameManager;

    [SerializeField] Animator animatorLeftHand, animationRightHand;
    

    //Kill Switch
    public bool isKeyIn = false;
    [SerializeField] private bool isKillSwitchReady = false;
    [SerializeField] private bool isFuelInjected = false;
    [SerializeField] public bool isReadyToRide = false;
    [SerializeField] private GameObject killSwitchObject;


    [SerializeField] private AudioSource engineAudioSource;
    [SerializeField] private bool startEngineAudio = false;
    [SerializeField] private AudioClip[] engineSoundClips;


    //Moving forward and backward
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private float accelerationSpeed = 10f;
    [SerializeField] private ThrottleSpeed throttleSpeed;


    //Clutch
    [SerializeField] private bool isClutchIn = false;


    //Gears
    private int currentGear = 1;
    private int minGear = 0; //0 is first gear, 1 is neutral
    private int maxGear = 6;
    [SerializeField] private TextMeshProUGUI gearText;


    //Headlight + Brake Lights + Horn
    [Header("Lights")]
    [Space(5)]
    [SerializeField] private Light headlight;
    [SerializeField] private Light[] brakelight;
    [SerializeField] private Material brakeLightMaterial;
    [SerializeField] private AudioSource hornSource;
    [SerializeField] private AudioClip hornAudioClip;


    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gearText.gameObject.SetActive(false);
        speedometerText.gameObject.SetActive(false);
    }

    void Update()
    {
        #region KillSwitch & Fuel Injection
        if (VRInputActions.MotorcycleControls.KillSwitch.ReadValue<float>() > 0.5f)
        {
            isKillSwitchReady = false;

            killSwitchObject.transform.localEulerAngles = new Vector3(159.042f, 63.951f, 52.497f);

        }
        // also R on keyboard
        else if (VRInputActions.MotorcycleControls.KillSwitch.ReadValue<float>() < -0.5f || VRInputActions.MotorcycleControls.KillSwitchKeyboard.IsPressed())
        {
            isKillSwitchReady = true;

            //only if the kill switch is ready, FIX THIS
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.KillSwitch);

            killSwitchObject.transform.localEulerAngles = new Vector3(159.042f, 63.951f, 10f);
        }

        //Kill Switch must be ready first
        if (isKillSwitchReady == true)
        {
            //also T key on keyboard
            if (VRInputActions.MotorcycleControls.FuelInjection.ReadValue<float>() > 0.5f && isKillSwitchReady == true)
            {
                isFuelInjected = true;

                //Idle sound
                engineAudioSource.clip = engineSoundClips[0];

                if (startEngineAudio == false)
                {
                    engineAudioSource.Play();
                    InvokeRepeating("StartEngine", 0f, .2f);
                }
                startEngineAudio = true;


                InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.FuelInjector);
            }

            //Release control and leave into idle sound loop
            if (VRInputActions.MotorcycleControls.FuelInjection.ReadValue<float>() < 0.5f && startEngineAudio == true)
            {
                CancelInvoke("StartEngine");
                engineAudioSource.Play();
                startEngineAudio = false;
            }
        }

        #endregion

        #region Ready to Ride
        //Ready to ride
        if (isKeyIn == true && isKillSwitchReady == true && isFuelInjected == true)
        {
            isReadyToRide = true;
            gearText.gameObject.SetActive(true);
            speedometerText.gameObject.SetActive(true);
        }
        #endregion

        #region Gripping Anim
        if (VRInputActions.MotorcycleControls.GrabHandleBarsLeft.ReadValue<float>() > 0.2f)
        {
            animatorLeftHand.SetBool("isGripping", true);
        }
        else
        {
            animatorLeftHand.SetBool("isGripping", false);
        }

        if (VRInputActions.MotorcycleControls.GrabHandleBarsRight.ReadValue<float>() > 0.2f)
        {
            animationRightHand.SetBool("isGripping", true);
        }
        else
        {
            animationRightHand.SetBool("isGripping", false);
        }

        #endregion

        #region Throttling
        //Throttle is also A key on keyboard and B button on Oculus controller for now
        //Must be ready to ride = true && not in neutral gear
        if (isReadyToRide == true && currentGear != 1)
        {

            if (VRInputActions.MotorcycleControls.Throttle.IsPressed())
            {
                rb.AddForce(transform.forward * accelerationSpeed, ForceMode.Acceleration);
                engineAudioSource.pitch = throttleSpeed.clampedValue * 3f;

                //include wheel rotation
            }

            //Accelerating by rolling the throttle
            if (VRInputActions.MotorcycleControls.GrabHandleBarsRight.ReadValue<float>() > 0.2f)
            {
                rb.AddForce(transform.forward * accelerationSpeed * throttleSpeed.clampedValue, ForceMode.Acceleration);
                engineAudioSource.pitch = throttleSpeed.clampedValue * 3f;
            }
        }
        #endregion

        #region Braking
        //Front Brake = S Key and right trigger on Oculus controller or Back Brake = D key and USB car pedal
        if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.ReadValue<float>() > 0.2f)
        {
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.FrontBrake);
        }

        if (VRInputActions.MotorcycleControls.BackBrakePress.ReadValue<float>() > 0.2f)
        {
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.BackBrake);
        }

        //Actual Braking Deceleration
        if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.ReadValue<float>() > 0.2f || VRInputActions.MotorcycleControls.BackBrakePress.ReadValue<float>() > 0.2f)
        {

            //Will adding this multiplier make the braking to jarring for new users?
            //frontBrakingMultiplier = VRInputActions.MotorcycleControls.FrontBrakeGrabbing.ReadValue<float>();
            // backBrakingMultiplier = VRInputActions.MotorcycleControls.BackBrakePress.ReadValue<float>();

            // Check if the motorcycle is moving forward
            if (rb.velocity.magnitude > 0)
            {
                // Calculate the braking force direction opposite to the motorcycle's velocity
                Vector3 brakingDirection = -rb.velocity.normalized;

                // Calculate the braking force magnitude based on the current speed and braking force
                float currentSpeed = rb.velocity.magnitude;
                float brakingMagnitude = Mathf.Clamp(accelerationSpeed, 0, currentSpeed);

                // Apply the deceleration force
                rb.AddForce(brakingDirection * brakingMagnitude, ForceMode.Acceleration);

                if (rb.velocity.magnitude < 0.1f)
                {
                    rb.velocity = Vector3.zero;
                }
            }

            //Brake Light
            brakeLightMaterial.EnableKeyword("_EMISSION");
            brakeLightMaterial.SetColor("_EmissionColor", Color.red);
            brakelight[0].enabled = true;
            brakelight[1].enabled = true;
        }
        else if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.ReadValue<float>() > 0.2f && VRInputActions.MotorcycleControls.BackBrakePress.ReadValue<float>() > 0.2f) //enhanced braking
        {
            //the motorcycle is moving forward
            if (rb.velocity.magnitude > 0)
            {
                // Calculate the braking force direction opposite to the motorcycle's velocity
                Vector3 brakingDirection = -rb.velocity.normalized;

                // Calculate the braking force magnitude based on the current speed and braking force
                float currentSpeed = rb.velocity.magnitude;
                float brakingMagnitude = Mathf.Clamp(accelerationSpeed, 0, currentSpeed);

                // Apply the deceleration force
                rb.AddForce(brakingDirection * brakingMagnitude * 1.5f, ForceMode.Acceleration);

                if (rb.velocity.magnitude < 0.1f)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }

        //Front Brake = S Key and right trigger on Oculus controller or Back Brake = D key and USB car pedal
        if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.WasReleasedThisFrame() || VRInputActions.MotorcycleControls.BackBrakePress.WasReleasedThisFrame())
        {
            //turn off brake light
            brakeLightMaterial.DisableKeyword("_EMISSION");
            brakeLightMaterial.SetColor("_EmissionColor", Color.red);
            brakelight[0].enabled = false;
            brakelight[1].enabled = false;
        }
        #endregion

        #region Clutch
        //Pulling in the clutch. Change with sensitivity amount/axis threshold. Also C key on keyboard and left trigger on Oculus controller
        //Bike must be READY TO RIDE first = true
        if (isReadyToRide == true)
        {
            if (VRInputActions.MotorcycleControls.ClutchGrabbing.ReadValue<float>() > 0.5f)
            {
                isClutchIn = true;

                InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.Clutch);
            }
            else if ((VRInputActions.MotorcycleControls.ClutchGrabbing.ReadValue<float>() < 0.5f))
            {
                isClutchIn = false;
            }
        }
        #endregion

        #region Shifting
        //Shifting Up with Clutch In. Also up arrow on keyboard 
        if (VRInputActions.MotorcycleControls.ShifterPedalUp.WasPressedThisFrame() && isClutchIn)
        {
            if (currentGear < maxGear)
            {
                currentGear++;
            }

            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.ShifterUp);

        }

        //Shifting Down with Clutch In. Also down arrow on keyboard
        if (VRInputActions.MotorcycleControls.ShifterPedalDown.WasPressedThisFrame() && isClutchIn)
        {
            if (currentGear > minGear)
            {
                currentGear--;
            }
            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.ShifterDown);

        }
        Debug.Log($"Clutch is: {isClutchIn} Current gear is {currentGear}");


        //Display Gear & Change Acceleration Speed
        switch (currentGear)
        {
            case 0:
                gearText.text = "1";
                accelerationSpeed = 30f;
                break;
            case 1:
                gearText.text = "N";
                accelerationSpeed = 0f;
                break;
            case 2:
                gearText.text = "2";
                accelerationSpeed = 35f;
                break;
            case 3:
                gearText.text = "3";
                accelerationSpeed = 40f;
                break;
            case 4:
                gearText.text = "4";
                accelerationSpeed = 45f;
                break;
            case 5:
                gearText.text = "5";
                accelerationSpeed = 50f;
                break;
            case 6:
                gearText.text = "6";
                accelerationSpeed = 55f;
                break;
            default:
                break;
        }

        #endregion

        #region Stalling
        //Stalling the bike when velocity it too low and clutch is not in. 
        //Maybe a feature in free roam

        //if (rb.velocity.magnitude < 0.1f && isClutchIn == false)
        //{
        //isReadyToRide = false;
        //

        #endregion

        #region Horn
        if (VRInputActions.MotorcycleControls.HornButton.IsPressed())
        {
            if (isReadyToRide == true)
            hornSource.PlayOneShot(hornAudioClip);
            //Debug.Log("Horn is pressed");

            InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.Horn);
        }
        else if (VRInputActions.MotorcycleControls.HornButton.WasReleasedThisFrame())
        {
            hornSource.Stop();
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

            if (gameManager.currentStep == GameManager.Step.Horn)
            {
                gameManager.stateIsComplete = true;
            }
        }
    }

  private void StartEngine()
    {
        engineAudioSource.Stop();
        engineAudioSource.Play();
    }
   
}

