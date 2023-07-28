using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHATGPTDRIFT : MonoBehaviour
{
  
    public float maxTiltAngle = 45f;        // Maximum angle the motorcycle can lean
    public float rotationSpeed = 0.5f;     // Speed of rotation when tilting
    public float damping = 5f;             // Damping factor for currentYaw

    private Rigidbody rb;
    public GameObject head;

    private float currentYaw;
    private float currentTiltAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float headAngle = head.transform.eulerAngles.z;

        if (headAngle > 180)
        {
            headAngle = headAngle - 360;
        }

        float desiredTiltAngle = Mathf.Clamp(headAngle, -maxTiltAngle, maxTiltAngle);

        if (rb.velocity.magnitude > 2)
        {
            // Smoothly update the desired tilt angle
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, desiredTiltAngle, rotationSpeed * Time.deltaTime);

            Quaternion roll = Quaternion.AngleAxis(currentTiltAngle, Vector3.forward);

            float angularVelocity = -desiredTiltAngle;

            // Apply damping to reduce drift
            currentYaw = Mathf.Lerp(currentYaw, angularVelocity, Time.deltaTime * damping);

            Quaternion yaw = Quaternion.AngleAxis(currentYaw, Vector3.up);

            // Tilt and lean, yaw ALWAYS come before roll in Quaternions
            Quaternion rigRotation = yaw * roll;

            // Smooth out the rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, rigRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Keep the bike upright when moving under 2km/h
            Quaternion upright = Quaternion.AngleAxis(0, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, upright, rotationSpeed * Time.deltaTime);

            // Reset currentYaw and currentTiltAngle when not moving
            currentYaw = 0f;
            currentTiltAngle = 0f;
        }
    }
}
