using UnityEngine;

public class TiltLeaning : MonoBehaviour
{
    public float maxTiltAngle = 45f;        // Maximum angle the motorcycle can lean
    public float rotationSpeed = .5f;       // Speed of rotation when tilting
    private Rigidbody rb;
    public GameObject head;

    private float currentYaw;

    public Quaternion rigRotation;
    public Quaternion yaw;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float headAngle = head.transform.eulerAngles.z;
        if (headAngle > 180)
        {
            headAngle -= 360;
        }

        float desiredTiltAngle = Mathf.Clamp(headAngle, -maxTiltAngle, maxTiltAngle);

        if (rb.velocity.magnitude > 2)
        {
            Quaternion roll = Quaternion.AngleAxis(desiredTiltAngle, Vector3.forward);

            float angularVelocity = -desiredTiltAngle;

            currentYaw += angularVelocity * Time.deltaTime;

            Quaternion yaw = Quaternion.AngleAxis(currentYaw, Vector3.up);

            // Tilt and lean, yaw ALWAYS comes before roll in Quaternions
            rigRotation = yaw * roll;

            //Smooth out the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rigRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Keep the bike upright when moving under 2km/h
            Quaternion upright = Quaternion.AngleAxis(0, Vector3.forward);
            yaw = Quaternion.Euler(0, 0, 0);
            currentYaw = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, upright, rotationSpeed * Time.deltaTime);

            //face the player forward
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
        }
    }
}
