using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR;

public class MotorcycleController : MonoBehaviour
{
    /// <summary>
    /// Throttle, Clutch, Brake, Shifting, etc.
    /// </summary>

    VRInputActions VRInputActions;
    private Rigidbody rb;


    //Moving forward and backward
    [SerializeField] private float accelerationSpeed = 5f;

    //Leaning steering
    [SerializeField] private GameObject head;
    private float initialZRotation;
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




    [Header  ("Lights")]
    [Space(5)]
    //Light
    [SerializeField] private Light headlight;
    [SerializeField] private Light[] brakelight;
    private Light rightSignalLight;
    private Light leftSignalLight;
    [SerializeField] private Material brakeLightMaterial;

    private float headlightAxis;


    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialZRotation = head.transform.eulerAngles.x;

    }

    void Update()
    {
       
        ////The lean angle on the local z axis is the rotation of the head
        //zRotation = head.transform.eulerAngles.z;
        ////Debug.Log($"Z Rotation: {zRotation}");
        //if (rb.velocity.magnitude > 0 && zRotation > 5 && zRotation < 65)
        //{
        //    angularSensitivity = zRotation;
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -90, 0f), rotationSensitivity * Time.deltaTime);

        //    //Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, -1, 0f), zRotation * Time.deltaTime);
        //}
        //else if (rb.velocity.magnitude > 0 && zRotation > 295 && zRotation < 355)
        //{
        //    angularSensitivity = zRotation - 290;
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0f), angularSensitivity * Time.deltaTime);
        //}


        //rotate this gameObject in the direction of the head's tilt on the z axis smoothly
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, zRotation, 0f), rotationSensitivity * Time.deltaTime);





        //Throttle is also A key on keyboard and B button on Oculus controller for now
        if (VRInputActions.MotorcycleControls.Throttle.IsPressed())
        {
            rb.AddForce(transform.forward * accelerationSpeed, ForceMode.Acceleration);

            //include wheel rotation
        }

        //Front Brake is also the S Key and right trigger on Oculus controller or Back Brake is also the D key and USB car pedal
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
            // Check if the motorcycle is moving forward
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

        //Front Brake is also the S Key and right trigger on Oculus controller or Back Brake is also the D key and USB car pedal
        if (VRInputActions.MotorcycleControls.FrontBrakeGrabbing.WasReleasedThisFrame() || VRInputActions.MotorcycleControls.BackBrakePress.WasReleasedThisFrame())
        {
            //turn off brake light
            brakeLightMaterial.DisableKeyword("_EMISSION");
            brakeLightMaterial.SetColor("_EmissionColor", Color.red);
            brakelight[0].enabled = false;
            brakelight[1].enabled = false;
        }


            //Pulling in the clutch. Change with sensitivity amount/axis threshold. Also C key on keyboard and left trigger on Oculus controller
            if (VRInputActions.MotorcycleControls.ClutchGrabbing.IsPressed())
        {
            isClutchIn = true;
        }
        else if ((VRInputActions.MotorcycleControls.ClutchGrabbing.WasReleasedThisFrame()))
        {
            isClutchIn = false;
        }

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

        Debug.Log(isClutchIn);
        Debug.Log($"Current gear is {currentGear}");
    }





    //Turn on Heaedlight using the L key on keyboard or Y axis on left Oculus joystick controller

}
