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

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ignition"))
        {
            Debug.Log("Key in ignition");

            isAttached = true;
        }
    }
}
