using System.Collections;
using UnityEngine;

public class RotateWristForInstructions : MonoBehaviour
{
    [SerializeField] private GameObject[] controlsImage;
    public GameManager gameManager;

    VRInputActions VRInputActions;

    private void Awake()
    {
        VRInputActions = new VRInputActions();
        VRInputActions.Enable();
    }

    void Update()
    {
        if (VRInputActions.MotorcycleControls.DisplayControlsMap.IsPressed())
        {
            controlsImage[0].SetActive(true);
            controlsImage[1].SetActive(true);
            StartCoroutine(InputActionStep(GameManager.State.IdentifyComponents, GameManager.Step.ReferenceImages));
        }
        else
        {
            controlsImage[0].SetActive(false);
            controlsImage[1].SetActive(false);
        }
    }

    private IEnumerator InputActionStep(GameManager.State state, GameManager.Step step)
    {
        yield return new WaitForSeconds(1f);

        if (gameManager.currentState == state)
        {
            if (gameManager.currentStep == step)
            {
                gameManager.stepIsComplete = true;
            }
        }
    }
}
