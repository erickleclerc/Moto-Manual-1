using UnityEngine;

public class RotateWristForInstructions : MonoBehaviour
{
    [SerializeField] private GameObject controlsImage;


    private Quaternion palmUpRotation = Quaternion.Euler(.51f, .44f, -.42f); // Adjust the Euler angles as needed

    void Update()
    {
        // Get the wrist rotation as a quaternion
        Quaternion wristRotation = transform.localRotation;

        // Activate/deactivate the image GameObject based on the wrist rotation
        if (wristRotation.x > 0.5f && wristRotation.x < 0.7f)
            controlsImage.SetActive(true);
        else controlsImage.SetActive(false);

        Debug.Log(wristRotation);
    }
}
