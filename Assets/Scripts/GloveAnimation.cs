using UnityEngine;

public class GloveAnimation : MonoBehaviour
{
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
