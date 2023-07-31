using UnityEngine;

public class HandsOnBar : MonoBehaviour
{
    [SerializeField] KeepHandOnHandleBar keepHandOnHandleBarScript;
    [SerializeField] Animator animatorLeftHand, animationRightHand;

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            if (gameManager.currentState == GameManager.State.IdentifyComponents)
            {
                if (gameManager.currentStep == GameManager.Step.Throttle)
                {
                    gameManager.stepIsComplete = true;
                }
            }
        }
    }

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
