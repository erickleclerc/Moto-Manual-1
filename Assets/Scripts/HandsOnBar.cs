using UnityEngine;

public class HandsOnBar : MonoBehaviour
{
    [SerializeField] KeepHandOnHandleBar keepHandOnHandleBarScript;
    [SerializeField] Animator animatorLeftHand, animationRightHand;

    private void OnTriggerStay(Collider other)
    {
        HandsOnBarChecker(other, true);

    }

    private void OnTriggerExit(Collider other)
    {
        HandsOnBarChecker(other, false);
        animationRightHand.SetBool("isGripping", false);
        animatorLeftHand.SetBool("isGripping", false);
    }

    private void HandsOnBarChecker(Collider other, bool yesOrNo)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            keepHandOnHandleBarScript.isLeftHandOnHandleBar = yesOrNo;
            animatorLeftHand.SetBool("isGripping", true);
        }
        else if (other.gameObject.tag == "RightHand")
        {
            keepHandOnHandleBarScript.isRightHandOnHandleBar = yesOrNo;
            animationRightHand.SetBool("isGripping", true);
        }
    }
}
