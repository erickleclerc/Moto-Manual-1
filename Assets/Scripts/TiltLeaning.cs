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
            Quaternion pitch = Quaternion.AngleAxis(0, Vector3.right);

            float angularVelocity = -desiredTiltAngle;

            currentYaw += angularVelocity * Time.deltaTime;

            Quaternion yaw = Quaternion.AngleAxis(currentYaw, Vector3.up);

            // Tilt and lean, yaw ALWAYS comes before roll in Quaternions
            rigRotation = yaw * roll * pitch;

            //Smooth out the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rigRotation, rotationSpeed * Time.deltaTime);

            //Stop from flying off the ground or running into the ground
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);

        }
        else
        {
            // Keep the bike upright when moving under 2km/h
            Quaternion upright = Quaternion.AngleAxis(0, Vector3.forward);
            yaw = Quaternion.Euler(0, 0, 0);
            currentYaw = 0;

            rigRotation = yaw * upright;
            transform.rotation = Quaternion.Slerp(transform.rotation, rigRotation, rotationSpeed * Time.deltaTime);
            
            
            //Stop from flying off the ground or running into the ground
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            //Debug.Log(transform.position.y);
        }
    }
}
