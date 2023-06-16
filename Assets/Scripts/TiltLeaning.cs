using UnityEngine;

public class TiltLeaning : MonoBehaviour
{
    public float maxTiltAngle = 45f;        // Maximum angle the motorcycle can lean
    public float rotationSpeed = .5f;       // Speed of rotation when tilting

    private Rigidbody rb;

    public GameObject head;
    private float headZRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        Quaternion yaw = Quaternion.AngleAxis(-desiredTiltAngle, Vector3.up);

        // Tilt and lean, yaw ALWAYS come before roll in Quaternions
        Quaternion rigRotation = yaw * roll;


        if (rb.velocity.magnitude > 2)
        {
            //Smooth out the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rigRotation, rotationSpeed * Time.deltaTime);
            
            
        }
        else
        {
            // Keep the bike upright when moving under 5km/h
            Quaternion upright = Quaternion.AngleAxis(0, Vector3.forward);
            transform.rotation = upright;


        }
    }

    private float GetHeadTiltAngle()
    {
        headZRotation = head.transform.eulerAngles.z;
      

        return headZRotation;
    }
}
