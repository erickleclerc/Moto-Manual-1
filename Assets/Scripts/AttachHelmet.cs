using UnityEngine;

public class AttachHelmet : MonoBehaviour
{
    public bool isAttached = false;
    public Vector3 offset;

    [SerializeField] private GameManager gameManager;

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
            transform.SetParent(other.gameObject.transform);
            transform.rotation = transform.parent.rotation * Quaternion.Euler(0, 90, 0); ;

            isAttached = true;

            //This keeps skipping to last state
            //gameManager.stateIsComplete = true; 
            //temporary fix
            if (gameManager.currentState == GameManager.State.DonHelmet)
            {
                gameManager.canPlayInstruction = true;
            }
            gameManager.currentState = GameManager.State.Key;
        }
    }
}
