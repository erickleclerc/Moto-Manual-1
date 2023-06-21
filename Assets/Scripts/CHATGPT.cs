using UnityEngine;

public class CHATGPT : MonoBehaviour
{
    public float maxTiltAngle = 45f;        // Maximum angle the motorcycle can lean
    public float rotationSpeed = .5f;       // Speed of rotation when tilting

    private Rigidbody rb;
    private Quaternion initialRotation;     // Initial rotation of the game object
    private Quaternion targetRotation;      // Target rotation for smooth transition
    private Quaternion currentRotation;     // Current rotation

    public GameObject head;
    private float headZRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;     // Store the initial rotation of the game object
        targetRotation = initialRotation;         // Set the target rotation to the initial rotation
        currentRotation = initialRotation;        // Set the current rotation to the initial rotation
    }

    private void Update()
    {
        float headAngle = GetHeadTiltAngle();

        if (headAngle > 180)
        {
            headAngle = headAngle - 360;
        }

        float desiredTiltAngle = Mathf.Clamp(headAngle, -maxTiltAngle, maxTiltAngle);

        Quaternion roll = Quaternion.AngleAxis(desiredTiltAngle, Vector3.forward);
        Quaternion yaw = Quaternion.AngleAxis(-headAngle * 2, Vector3.up);

        Quaternion rigRotation = yaw * roll;

        if (rb.velocity.magnitude > 2)
        {
            // Apply the rotation directly
            targetRotation = rigRotation * Quaternion.FromToRotation(initialRotation * Vector3.forward, transform.forward);
        }
        else
        {
            // Smoothly rotate towards the target rotation
            Quaternion targetRotationWithoutRoll = Quaternion.LookRotation(targetRotation * Vector3.forward, transform.up);
            targetRotation = Quaternion.Slerp(currentRotation, targetRotationWithoutRoll, rotationSpeed * Time.deltaTime);
        }

        // Update the current rotation
        currentRotation = targetRotation;

        // Apply the rotation
        transform.rotation = currentRotation;
    }

    private float GetHeadTiltAngle()
    {
        headZRotation = head.transform.eulerAngles.z;
        return headZRotation;
    }
}
