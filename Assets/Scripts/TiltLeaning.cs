using UnityEngine;

public class TiltLeaning : MonoBehaviour
{
    public float maxTiltAngle = 45f;        // Maximum angle the motorcycle can lean
    public float maxTurnAngle = 30f;        // Maximum angle the motorcycle can turn
    public float rotationSpeed = .5f;       // Speed of rotation when tilting
    public float turnIntensity = .5f;        // Intensity of the turn

    private float currentTiltAngle = 0f;    // Current angle of motorcycle tilt
    private float currentTurnAngle = 0f;    // Current angle of motorcycle turn

    private Rigidbody rb;

    public GameObject head;
    private float headZRotation;

    float tiltedAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Get the head tilt angle
        float headTiltAngle = GetHeadTiltAngle();

        // Calculate the desired tilt angle for the motorcycle based on the head tilt angle
        float desiredTiltAngle = Mathf.Clamp(headTiltAngle, -maxTiltAngle, maxTiltAngle);


        if (rb.velocity.magnitude > 5)
        {
            // Smoothly rotate the motorcycle towards the desired tilt angle
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, desiredTiltAngle, rotationSpeed * Time.deltaTime);

            // Apply the rotation to the motorcycle
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, currentTurnAngle, currentTiltAngle), rotationSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(0f, currentTurnAngle, currentTiltAngle);

          // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z), rotationSpeed * Time.deltaTime);
            //NEEDS TO BE FIXED*********

            transform.rotation = Quaternion.Euler(0, 0, currentTiltAngle);


            // Calculate the desired turn angle based on the head tilt angle and turn intensity
            float desiredTurnAngle = Mathf.Clamp(headTiltAngle * turnIntensity, -maxTurnAngle, maxTurnAngle);

        }
       
    }

    private float GetHeadTiltAngle()
    {
        headZRotation = head.transform.eulerAngles.z;
        if (headZRotation > 0f && headZRotation < 100)
        {
                tiltedAngle = headZRotation;
        }
        else if (headZRotation > 100f )
        {
             tiltedAngle = headZRotation - 360f;
           
        }
        return tiltedAngle;
    }
}
