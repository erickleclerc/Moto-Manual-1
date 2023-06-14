using UnityEngine;

public class ThrottleSpeed : MonoBehaviour
{
    private float handZRotation;

    public float clampedValue;

    void Update()
    {
        Quaternion rotation = transform.rotation;

        Vector3 eulerAngles = rotation.eulerAngles;

        float clampedZRotation = Mathf.Clamp(eulerAngles.z, 70f, 160f);

        float normalizedValue = Mathf.InverseLerp(90f, 180f, clampedZRotation);

        clampedValue = Mathf.Lerp(0f, 1f, normalizedValue);

        //Debug.Log("Clamped Z Rotation: " + clampedValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            gameObject.transform.localEulerAngles = new Vector3(-21.526f, -239.948f, 0);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            handZRotation = other.gameObject.transform.rotation.eulerAngles.z;
            gameObject.transform.localEulerAngles = new Vector3(-21.526f, -239.948f, handZRotation);

           // Debug.Log("Clamped" + throttleAngle);
           //Debug.Log("Throttle Speed: " + gameObject.transform.eulerAngles.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            gameObject.transform.localEulerAngles = new Vector3(-21.526f, -239.948f, 0);
        }
    }
    
}
