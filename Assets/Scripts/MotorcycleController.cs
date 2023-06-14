using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    //Kill Switch
    private bool isKillSwitchOn = false;
    private bool isFuelInjected = false;
    [SerializeField] private GameObject killSwitchObject;


    //Moving forward and backward
    [SerializeField] private float accelerationSpeed = 10f;
    [SerializeField] private ThrottleSpeed throttleSpeed;

    //Leaning steering
    [SerializeField] private GameObject head;
    public float zRotation;
    public float rotationDifference;
    public float rotationSensitivity = 1f;
    private float angularDifference;
    private float angularSensitivity;


    //Clutch
    private bool isClutchIn = false;
    

    //Gears
    private int currentGear = 1;
    private int minGear = 0; //0 is first gear, 1 is neutral
    private int maxGear = 6;
    [SerializeField] private TextMeshProUGUI gearText;


    //Headlight + Brake Lights
    [Header  ("Lights")]
    [Space(5)]
    [SerializeField] private Light headlight;
    [SerializeField] private Light[] brakelight;
    [SerializeField] private Material brakeLightMaterial;


    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region Throttling
        //Throttle is also A key on keyboard and B button on Oculus controller for now
        if (VRInputActions.MotorcycleControls.Throttle.IsPressed())
        {
            rb.AddForce(transform.forward * accelerationSpeed, ForceMode.Acceleration);

            //include wheel rotation
        }

        //Accelerating by rolling the throttle
        {
            rb.AddForce(transform.forward * accelerationSpeed * throttleSpeed.clampedValue, ForceMode.Acceleration);
        }
        #endregion

        #region Braking
        //Front Brake = S Key and right trigger on Oculus controller or Back Brake = D key and USB car pedal
        if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.IsPressed() || VRInputActions.MotorcycleControls.BackBrakePress.IsPressed())
        {
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
        else if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.IsPressed() && VRInputActions.MotorcycleControls.BackBrakePress.IsPressed()) //enhanced braking
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
        if (VRInputActions.MotorcycleControls.ClutchGrabbing.ReadValue<float>() > 0.5f)
        {
            isClutchIn = true;
            
        }
        else if ((VRInputActions.MotorcycleControls.ClutchGrabbing.ReadValue<float>() < 0.5f))
        {
            isClutchIn = false;
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
        }

        //Shifting Down with Clutch In. Also down arrow on keyboard
        if (VRInputActions.MotorcycleControls.ShifterPedalDown.WasPressedThisFrame() && isClutchIn)
        {
            if (currentGear > minGear)
            {
                currentGear--;
            }
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

        #region KillSwitch & Fuel Injection
        if (VRInputActions.MotorcycleControls.KillSwitch.ReadValue<float>() > 0.5f)
        {
            isKillSwitchOn = false;

            killSwitchObject.transform.localEulerAngles = new Vector3(-14.418f,-10.407f, 6.069f);

        }
        else if (VRInputActions.MotorcycleControls.KillSwitch.ReadValue<float>() < -0.5f)
        {
            isKillSwitchOn = true;
            killSwitchObject.transform.localEulerAngles = new Vector3 (16.803f, 2.182f, -6.273f);
        }   

        if (VRInputActions.MotorcycleControls.FuelInjection1.ReadValue<float>() > 0.5f || isKillSwitchOn == true)
        {
            isFuelInjected = true;
        }

        #endregion

    }
}
