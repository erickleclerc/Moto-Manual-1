using UnityEngine;

public class LessonTwoComplete : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject vrRig;

    private bool reachedGear = false;


    void Update()
    {
        if (vrRig.GetComponent<MotorcycleController>().currentGear == 4)
        {
            reachedGear = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (reachedGear)
        {
            if (gameManager.currentState == GameManager.State.GearLesson)
            {
                gameManager.stateIsComplete = true;

                Reset();
                Destroy(gameObject);
            }
        }
        else
        {
            Reset();
            gameManager.audioInstructions.PlayInstruction(18);
        }
    }

    private void Reset()
    {
        vrRig.GetComponent<Rigidbody>().velocity = Vector3.zero;
        vrRig.GetComponent<MotorcycleController>().currentGear = 1;
        vrRig.transform.position = gameManager.startingPosition;
    }
}
