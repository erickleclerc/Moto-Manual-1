using UnityEngine;
using TMPro;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI outOfBoundsText;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VRRig"))
        {
            outOfBoundsText.text = "Out of bounds!";
            //Debug.Log(errorMessageText.text);
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
