using UnityEngine;
using TMPro;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;


    [SerializeField] TextMeshProUGUI outOfBoundsText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VRRig"))
        {
            outOfBoundsText.text = "Out of bounds!";

            if (gameManager.currentState == GameManager.State.SpeedLesson || gameManager.currentState == GameManager.State.GearLesson)
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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VRRig"))
        {
            outOfBoundsText.text = "";
        }
    }
}
