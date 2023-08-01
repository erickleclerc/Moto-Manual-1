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

            if (gameManager.currentState == GameManager.State.SpeedLesson)
            {

                //set the velocity of the vrRig to 0
                vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
                vrRig.GetComponent<MotorcycleController>().currentGear = 1;

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
