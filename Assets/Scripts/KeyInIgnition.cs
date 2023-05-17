using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInIgnition : MonoBehaviour
{
    private bool isAttached = false;

    public Vector3 offset;

    void Update()
    {
       // if (isAttached)
        //{
        //    transform.localPosition = offset;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ignition"))
        {
            Debug.Log("Key in ignition");

            transform.SetParent(other.gameObject.transform, true);
           // transform.localScale = Vector3.one;
            
            isAttached = true;
            
            //transform.localRotation = Quaternion.Euler(90, 00, 0); 

            // I want the this gameObject to keep its position and rotation, but be a child of the ignition gameObject
        }
    }
}
