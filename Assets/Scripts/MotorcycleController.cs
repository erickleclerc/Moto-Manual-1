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
    [SerializeField] private float accelerationSpeed = 10f;

    //Leaning steering
    [SerializeField] private GameObject head;
    private float initialZRotation;
    public float zRotation;
    public float rotationDifference;
    public float rotationSensitivity = 1f;
    private float angularDifference;


    //Clutch
    private bool isClutchIn = false;


    //Gears

    private int currentGear = 1;
    private int minGear = 0; //0 is first gear, 1 is neutral
    private int maxGear = 6;

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
            }
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
            }
        }

        //Turning based on Leaning
        //zRotation = head.transform.eulerAngles.x;
        //rotationDifference = zRotation - initialZRotation;
        //if (rb.velocity.magnitude > 0)
        //{
        //    //transform.Rotate(0, -rotationDifference * rotationSensitivity, 0);//Turn more when leaning more

        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, rotationDifference, 0f), rotationSensitivity * Time.deltaTime);

        //}

        //angularDifference = Vector3.Angle(Vector3.up, transform.up);
        //if (rb.velocity.magnitude > 0 && angularDifference > 5)
        //{
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, angularDifference, 0f), rotationSensitivity * Time.deltaTime);
        //}


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
}
