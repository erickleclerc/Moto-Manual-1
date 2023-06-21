using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandleBar") || other.CompareTag("Throttle"))
        {
            GetComponent<Animator>().SetBool("isGripping", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HandleBar") || other.CompareTag("Throttle"))
        {
            GetComponent<Animator>().SetBool("isGripping", false);
        }
    }
}
