using UnityEngine;

public class KeyInIgnition : MonoBehaviour
{
    private bool isAttached;
    public GameObject ignition;
    public Vector3 offset;
    public Vector3 rotationOffset;

    [SerializeField] private MotorcycleController motorcycleController;
    [SerializeField] private GameManager gameManager;


    private void Start()
    {
        isAttached = false;
    }

    void Update()
    {
        if (isAttached)
        {
            //transform.position = Vector3.zero;
            transform.parent = ignition.transform;
            transform.localPosition = Vector3.zero + offset;
            transform.localEulerAngles = rotationOffset;



        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ignition"))
        {
            Debug.Log("Key in ignition");

            isAttached = true;
            motorcycleController.isKeyIn = true;

            gameManager.canPlayInstruction = true;
            gameManager.currentState = GameManager.State.IdentifyComponents;
        }
    }
}
