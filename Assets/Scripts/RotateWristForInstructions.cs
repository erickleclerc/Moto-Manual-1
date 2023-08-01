using UnityEngine;

public class RotateWristForInstructions : MonoBehaviour
{
    [SerializeField] private GameObject controlsImage;

    VRInputActions VRInputActions;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }

    void Update()
    {
        // Get the wrist rotation as a quaternion
        Quaternion wristRotation = transform.localRotation;

        // Activate/deactivate the image GameObject based on the wrist rotation

        //NOT CURRENTLY WORKING
        //if (wristRotation.x > 0.5f && wristRotation.x < 0.7f)
        //    controlsImage.SetActive(true);
        //else controlsImage.SetActive(false);

        //Debug.Log(wristRotation);

        if (VRInputActions.MotorcycleControls.DisplayControlsMap.IsPressed())
        {
            controlsImage.SetActive(true);
        }
        else controlsImage.SetActive(false);


    }
}
