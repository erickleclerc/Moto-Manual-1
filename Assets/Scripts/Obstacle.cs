using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRRig"))
        {
            if (gameManager.currentState == GameManager.State.DarkLesson)
            {

                //set the velocity of the vrRig to 0
                vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
                vrRig.GetComponent<MotorcycleController>().currentGear = 1;

                //reset the vrRig rotation to forward
                vrRig.GetComponent<TiltLeaning>().rigRotation = Quaternion.Euler(0, 0, 0);

                vrRig.transform.position = gameManager.startingPosition;
                gameManager.audioInstructions.PlayInstruction(18);
            }
        }
    }
}
