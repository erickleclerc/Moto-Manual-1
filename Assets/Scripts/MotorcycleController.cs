using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
   
        //Throttle is also A key on keyboard and B button on Oculus controller for now
        if (VRInputActions.MotorcycleControls.Throttle.IsPressed())
        {
            rb.AddForce(transform.forward * accelerationSpeed, ForceMode.Acceleration);

            //include wheel rotation
        }

        //Front Brake is also the S Key and right trigger on Oculus controller
        if (VRInputActions.MotorcycleControls.BackBrakePress.IsPressed())
        {
            rb.AddForce(transform.forward * -accelerationSpeed, ForceMode.Acceleration);
        }
    }
}
