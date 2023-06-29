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
            if (VRInputActions.MotorcycleControls.GrabHandleBarsRight.WasReleasedThisFrame())
            {

                //heldObject.transform.parent = null;

                heldObject = null;

                wasDropped = true;
            }
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
            Debug.Log(otherObject.gameObject.name);

            if (rb != null && otherObject.gameObject.CompareTag("Key") || rb != null && otherObject.gameObject.CompareTag("Helmet"))
            {
                if (VRInputActions.MotorcycleControls.GrabHandleBarsRight.WasPressedThisFrame())
                {
                    otherObject.transform.parent = transform;
                    rb.isKinematic = true;

                    heldObject = rb;
                }
            }
            //if (rb != null && otherObject.gameObject.CompareTag("HandleBar"))
            //{
            //    if (VRInputActions.MotorcycleControls.GrabHandleBarsRight.WasPressedThisFrame())
            //    {
            //        otherObject.transform.parent = transform;
            //        rb.isKinematic = true;

            //        heldObject = rb;
            //    }
            //}
        }
    }
}

