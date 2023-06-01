using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInIgnition : MonoBehaviour
{
    private bool isAttached;
    public GameObject ignition;


    public Vector3 offset;

    private void Start()
    {
        isAttached = false;
    }

    void Update()
    {
        if (isAttached)
        {

            transform.parent = ignition.transform;
           // transform.position = ignition.transform.position + offset;
            //transform.rotation = Quaternion.Euler(65, -90, -90);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ignition"))
        {
            Debug.Log("Key in ignition");

            //transform.SetParent(other.gameObject.transform, true);

            //ignition = other.GetComponent<GameObject>();


            //ftransform.position = other.gameObject.transform.position;
            //set the parent of this game object to the ignition gameObject
            //transform.parent = other.gameObject.transform;
            //transform.localPosition = Vector3.zero;


            isAttached = true;

            //transform.localRotation = Quaternion.Euler(90, 00, 0); 

        }
    }
}
