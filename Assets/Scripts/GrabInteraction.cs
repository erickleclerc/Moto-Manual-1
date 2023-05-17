using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    VRInputActions VRInputActions;
    Rigidbody heldObject;
    bool wasDropped;

    Vector3 previousPosition;
    Vector3 velocity;
    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }

    void Update()
    {
        wasDropped = false;

        if (heldObject != null)  //holding onto something
        {
            if (VRInputActions.MotorcycleControls.GrabHandleBars.WasPressedThisFrame())
            {
                heldObject.transform.parent = null;
                heldObject.isKinematic = false;


                                                                        //REMOVE VELOCITY?
                heldObject.velocity = velocity;
                heldObject = null;

                wasDropped = true;
            }
        }
    }

    private void FixedUpdate()
    {
                                                                    //REMOVE VELOCITY?
        if (heldObject != null)  //holding onto something
        {
            Vector3 displacement = heldObject.transform.position - previousPosition;

            velocity = displacement / Time.deltaTime;

            previousPosition = heldObject.transform.position;
        }

    }
    private void OnTriggerStay(Collider otherObject)
    {
        if (wasDropped == true)
        {
            return;
        }

        if (heldObject == null)
        {
            Rigidbody rb = otherObject.GetComponent<Rigidbody>();
            //Debug.Log(otherObject.gameObject.name);

            if (rb != null && otherObject.gameObject.CompareTag("Key") || rb != null && otherObject.gameObject.CompareTag("Helmet"))
            {
                if (VRInputActions.MotorcycleControls.GrabHandleBars.WasPressedThisFrame())
                {
                    otherObject.transform.parent = transform;
                    rb.isKinematic = true;

                    heldObject = rb;
                }
            }
        }
    }
}

