using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachHelmet : MonoBehaviour
{
    private bool isAttached = false;

    public Vector3 offset;

    private void Update()
    {
        if (isAttached)
        {
            transform.localPosition = offset;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            Debug.Log("Trigger");

            transform.SetParent(other.gameObject.transform);
            transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 90, 0); ;

            isAttached = true;
        }
    }
}
