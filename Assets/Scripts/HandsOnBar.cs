using UnityEngine;

public class HandsOnBar : MonoBehaviour
{
    [SerializeField] KeepHandOnHandleBar keepHandOnHandleBarScript;

    private void OnTriggerStay(Collider other)
    {
        HandsOnBarChecker(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        HandsOnBarChecker(other, false);
    }

    private void HandsOnBarChecker(Collider other, bool yesOrNo)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            keepHandOnHandleBarScript.isLeftHandOnHandleBar = yesOrNo;
        }
        else if (other.gameObject.tag == "RightHand")
        {
            keepHandOnHandleBarScript.isRightHandOnHandleBar = yesOrNo;
        }
    }
}
