using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInIgnition : MonoBehaviour
{
    private bool isAttached = false;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttached)
        {
            transform.localPosition = offset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ignition"))
        {
            Debug.Log("Key in ignition");

            transform.SetParent(other.gameObject.transform);
            //transform.position = other.transform.position;

            isAttached = true;
            
            //transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 90, 0); ;

            
        }
    }
}
